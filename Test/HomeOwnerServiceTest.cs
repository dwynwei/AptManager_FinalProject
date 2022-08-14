using AutoMapper;
using BusinessLayer.Concrete;
using BusinessLayer.Configuration.Mapper;
using DataAccessLayer.Abstract;
using DataTransferObject.User;
using FluentAssertions;
using Models.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class HomeOwnerServiceTest
    {
        [Fact]
        public void HomeOwnerServiceCreate_Success()
        {
            var homeOwnerMock = new Mock<IHomeRepository>();
            homeOwnerMock.Setup(x => x.Add(It.IsAny<HomeOwner>()));

            MapperConfiguration mapConf = new MapperConfiguration(conf =>
            {
                conf.AddProfile(new MapperProfile());
            });

            IMapper mapper = new Mapper(mapConf);
            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            var ownerService = new HomeOwnerService(homeOwnerMock.Object, mapper);

            var ownerRequest = new CreateHomeOwnerRequest()
            {
                Name = "Çağatay",
                LastName = "Şahin",
                NationalityId = "11155577799",
                Email = "mail@cagataysahin.com",
                CarPlateId = "06-CC-606",
                PhoneNumber = "+905551234567"
            };

            var resp = ownerService.InsertUserInfo(ownerRequest);
            resp.Status.Should().BeTrue();
        }
    }
}
