using BackgroundJobs.Abstract;
using BusinessLayer.Abstract;
using Models.EmailEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobs.Concrete
{
    public class HangFireJobService : IHangFireJobService
    {
        private readonly IMailService _mailService;
        private readonly IHomeOwnerService _ownerService;

        public HangFireJobService(IMailService mailService, IHomeOwnerService ownerService)
        {
            _ownerService = ownerService;
            _mailService = mailService;
        }

        public void DelayedJob(int userId, string userName, TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        public void FireAndForget(int userId)
        {
            var info = new MailRequest()
            {
                Subject = "İşlem Başarılı Maili",
                Body = "İşlem Gerçekleşti",
                ToEmail = _ownerService.GetbyId(userId).Email
            };
            Hangfire.BackgroundJob.Enqueue(() => _mailService.SendEmailAsync(info));
        }

        public void ReccuringJob()
        {
            throw new NotImplementedException();
        }
    }
}
