using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Repository
{
    public class TimelineRepository : ITimelineRepository
    {
        Task<List<TimelineModel>> ITimelineRepository.GetTimeLineDataAsync()
        {
            var listTimelineObj = new List<TimelineModel>();

            listTimelineObj.Add(new TimelineModel()
            {
                Id = 1,
                Year = "2017",
                Title = "Web Designing",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer males uada tellus lorem, et condimentum neque commodo"
            });

            listTimelineObj.Add(new TimelineModel()
            {
                Id = 2,
                Year = "2018",
                Title = "Javascript",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer males uada tellus lorem, et condimentum neque commodo"
            });

            listTimelineObj.Add(new TimelineModel()
            {
                Id = 3,
                Year = "2019",
                Title = "Web Development using Server Side",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer males uada tellus lorem, et condimentum neque commodo"
            });

            listTimelineObj.Add(new TimelineModel()
            {
                Id = 4,
                Year = "2020",
                Title = "Web Development using Client Side",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer males uada tellus lorem, et condimentum neque commodo"
            });

            return Task.FromResult<List<TimelineModel>>(listTimelineObj);
        }
    }
}