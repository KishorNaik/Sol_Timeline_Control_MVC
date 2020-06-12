﻿using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Repository
{
    public interface ITimelineRepository
    {
        Task<List<TimelineModel>> GetTimeLineDataAsync();
    }
}