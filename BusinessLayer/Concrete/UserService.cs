using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Configuration.Auth;
using BusinessLayer.Configuration.CommandResponse;
using DataAccessLayer.Abstract;
using DataTransferObject.User.Requests;
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
     * User Service
     */
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
