using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Configuration.Auth;
using BusinessLayer.Configuration.CommandResponse;
using BusinessLayer.Configuration.Exception;
using BusinessLayer.Configuration.Validator.UserRequest;
using DataAccessLayer.Abstract;
using DataTransferObject.User;
using DataTransferObject.User.Requests;
using FluentValidation;
using Models;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    /*
     * HomeOwner Service
     */
    public class HomeOwnerService : IHomeOwnerService
    {
        private readonly IHomeRepository _ownerRepository;
        private readonly IMapper _mapper;
        //private readonly IHangFireJobService _jobService;

        public HomeOwnerService(IHomeRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        public CommandResponse DeleteUserInfo (int id)
        {
            var data = _ownerRepository.Get(x=>x.Id == id);
            _ownerRepository.Delete(data);
            _ownerRepository.SaveChages();
            return new CommandResponse()
            {
                Status = true,
                Message = "Kullanıcı Başarıyla Silindi"
            };
        }

        public IEnumerable<SearchOwnerRequest> getAllUserInfo()
        {
            var data = _ownerRepository.GetAll();
            var mapper = data.Select(x=> _mapper.Map<SearchOwnerRequest>(x)).ToList();
            return mapper;
        }

        public CommandResponse InsertUserInfo(CreateHomeOwnerRequest request)
        {
            var validator = new CreateHomeOwnerRequestValidator();
            validator.Validate(request).ThrowIfException();
            
            var entity = _mapper.Map<HomeOwner>(request);
            _ownerRepository.Add(entity);
            _ownerRepository.SaveChages();

            return new CommandResponse()
            {
                Status = true,
                Message = "Kullanıcı Başarılı Bir Şekilde Eklendi !"
            };
        }

        public CommandResponse UpdateUserInfo(UpdateHomeOwnerRequest request)
        {
            var validator = new UpdateHomeOwnerRequestValidation();
            validator.Validate(request);

            var entity = _ownerRepository.Get(x => x.Id == request.Id);

            if(entity == null)
            {
                return new CommandResponse()
                {
                    Status = false,
                    Message = "Böyle bir ID Bilgisine Sahip Kullanıcı Bulunamadı"
                };
            }

            var mappedEnt = _mapper.Map(request, entity);

            _ownerRepository.Update(mappedEnt);
            _ownerRepository.SaveChages();

            return new CommandResponse()
            {
                Status = true,
                Message = "Kullanıcı Başarılı Bir Şekilde Güncellendi !"
            };
        }

        HomeOwner IHomeOwnerService.GetbyId(int id)
        {
            var data = _ownerRepository.Get(x=>x.Id == id);
            return data;
        }
    }
}
