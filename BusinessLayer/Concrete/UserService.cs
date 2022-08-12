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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public CommandResponse DeleteUserInfo (User user)
        {
            _userRepository.Delete(user);
            return new CommandResponse()
            {
                Status = true,
                Message = "Kullanıcı Başarıyla Silindi"
            };
        }

        public IEnumerable<SearchUserRequest> getAllUserInfo()
        {
            var data = _userRepository.GetAll();
            var mapper = data.Select(x=> _mapper.Map<SearchUserRequest>(x)).ToList();
            return mapper;
        }

        public CommandResponse InsertUserInfo(CreateHomeOwnerRequest request)
        {
            var validator = new CreateHomeOwnerRequestValidator();
            validator.Validate(request).ThrowIfException();
            
            var entity = _mapper.Map<User>(request);
            _userRepository.Add(entity);
            _userRepository.SaveChages();

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

            var entity = _userRepository.Get(x => x.Id == request.Id);

            if(entity == null)
            {
                return new CommandResponse()
                {
                    Status = false,
                    Message = "Böyle bir ID Bilgisine Sahip Kullanıcı Bulunamadı"
                };
            }

            var mappedEnt = _mapper.Map(request, entity);

            _userRepository.Update(mappedEnt);

            return new CommandResponse()
            {
                Status = true,
                Message = "Kullanıcı Başarılı Bir Şekilde Güncellendi !"
            };
        }

        public CommandResponse Register(CreateUserRegisterRequest request)
        {
            byte[] passwordSalt, passwordHash;

            HashHelper.CreatePasswordHash(request.UserPassword, out passwordSalt, out passwordHash);

            var user = _mapper.Map<User>(request);

            user.Password = new UserPassword()
            {
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };

            _userRepository.Add(user);
            _userRepository.SaveChages();

            return new CommandResponse()
            {
                Status = true,
                Message = "Kullanıcı Kaydı Başarılı Bir Şekilde Gerçekleşti"
            };

        }
    }
}
