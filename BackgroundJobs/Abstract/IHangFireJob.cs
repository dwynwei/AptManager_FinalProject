﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobs.Abstract
{
    public interface IHangFireJob
    {
        void DelayedJob(int userId, string userName, TimeSpan timeSpan);
        void FireAndForget(int userId);
        void ReccuringJob();
    }
}
