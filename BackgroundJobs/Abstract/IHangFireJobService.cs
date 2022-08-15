using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobs.Abstract
{
    /*
     * HangFire Jobs Interface to use in HangFire Class
     */
    public interface IHangFireJobService
    {
        void DelayedJob(int userId, string userName, TimeSpan timeSpan);
        void FireAndForget(int userId);
        void ReccuringJob();
    }
}
