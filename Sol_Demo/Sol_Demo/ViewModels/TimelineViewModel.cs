using Sol_Demo.Models;
using Sol_Demo.TagHelpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.ViewModels
{
    public class TimelineViewModel
    {
        public List<TimelineTagHelperModel> TimeLineTagHelperM { get; set; }

        public TimelineModel TimelineM { get; set; }
    }
}