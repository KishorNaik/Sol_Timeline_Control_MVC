using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.TagHelpers.Models
{
    public class TimelineTagHelperModel
    {
        public String Year { get; set; }

        public String Title { get; set; }

        public String Description { get; set; }

        public TimelineTagHelperUIModel TimelineUI { get; set; }
    }
}