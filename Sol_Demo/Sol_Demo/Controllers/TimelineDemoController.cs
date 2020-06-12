using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sol_Demo.Repository;
using Sol_Demo.TagHelpers.Models;
using Sol_Demo.ViewModels;

namespace Sol_Demo.Controllers
{
    public class TimelineDemoController : Controller
    {
        private readonly ITimelineRepository timelineRepository = null;

        public TimelineDemoController(ITimelineRepository timelineRepository)
        {
            this.timelineRepository = timelineRepository;
            TimelineVM = new TimelineViewModel();
        }

        [BindProperty]
        public TimelineViewModel TimelineVM { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        private async Task BindTimeLineDataAsync()
        {
            var getTimeLineContent = await this.timelineRepository.GetTimeLineDataAsync();

            var timelineHelperModelObj =
                 getTimeLineContent
                 ?.AsEnumerable()
                 ?.Select((leTimelineModel) =>
                 {
                     var redirectUrl = @$"/TimelineDemo/OnSelectedTimeline/{leTimelineModel.Id}";

                     var icon = "fa fa-globe";

                     var timeLineTagHelperModel = new TimelineTagHelperModel()
                     {
                         Year = leTimelineModel.Year,
                         Title = leTimelineModel.Title,
                         Description = leTimelineModel.Content,
                         TimelineUI = new TimelineTagHelperUIModel()
                         {
                             IconCss = icon,
                             RedirectUrl = redirectUrl
                         }
                     };

                     return timeLineTagHelperModel;
                 })
                 ?.OrderByDescending((leTimeLineTagHelper) => leTimeLineTagHelper.Year)
                 ?.ToList();

            TimelineVM.TimeLineTagHelperM = timelineHelperModelObj;
        }

        public async Task<IActionResult> Index()
        {
            await this.BindTimeLineDataAsync();

            return View(TimelineVM);
        }

        [HttpGet]
        public async Task<IActionResult> OnSelectedTimeline()
        {
            var getTimeLineContent = await this.timelineRepository.GetTimeLineDataAsync();

            TimelineVM.TimelineM = getTimeLineContent
                .FirstOrDefault((leTimeLineModel) => leTimeLineModel.Id == Id);

            return View(TimelineVM);
        }
    }
}