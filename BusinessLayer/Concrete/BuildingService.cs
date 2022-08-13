using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Configuration.CommandResponse;
using BusinessLayer.Configuration.Exception;
using BusinessLayer.Configuration.Validator.BuildingRequest;
using DataAccessLayer.Abstract;
using DataTransferObject.Building.Requests;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;


        public BuildingService(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public CommandResponse DeleteBuildingInfo(int buildingId)
        {
            _buildingRepository.Delete(buildingId);

            return new CommandResponse()
            {
                Status = true,
                Message = "Kat Bilgisi Başarıyla Silindi"
            };
        }

        public IEnumerable<SearchBuildingInformationRequest> GetAllBuildingInfo()
        {
            var data = _buildingRepository.GetAll();
            var mapperData = data.Select(x=> _mapper.Map<SearchBuildingInformationRequest>(x)).ToList();
            return mapperData;
        }

        public CommandResponse InsertBuildingInfo(CreateBuildingInformationRequest buildingReq)
        {
            var validator = new CreateBuildingInformationRequestValidator();
            validator.Validate(buildingReq).ThrowIfException();

            var buildingEntity = _mapper.Map<Building>(buildingReq);
            _buildingRepository.Add(buildingEntity);
            _buildingRepository.SaveChages();

            return new CommandResponse()
            {
                Status = true,
                Message = "Kat bilgisi başarıyla eklendi"
            };
        }

        public CommandResponse UpdateBuildingInfo(UpdateBuildingInformationRequest buildingReq)
        {
            var validator = new UpdateBuildingInformationRequestValidator();
            validator.Validate(buildingReq);

            var entity = _buildingRepository.Get(x => x.Id == buildingReq.Id);

            if (entity == null)
            {
                return new CommandResponse()
                {
                    Status = false,
                    Message = "Böyle bir ID Bilgisine Sahip Kat bilgisi Bulunamadı"
                };
            }

            var mappedEnt = _mapper.Map(buildingReq, entity);

            _buildingRepository.Update(mappedEnt);
            _buildingRepository.SaveChages();

            return new CommandResponse()
            {
                Status = true,
                Message = "Kat Bilgisi Başarılı Bir Şekilde Güncellendi !"
            };
        }

        public CommandResponse GetBuildingInfoById(int buildingId)
        {
            var resp = _buildingRepository.Get(x => x.Id == buildingId);

            if (resp == null)
                return new CommandResponse()
                {
                    Status = false,
                    Message = $"{buildingId}'e Ait Kat bilgisi Bulunamadı!"
                };
            resp.ToString();
            return new CommandResponse()
            {
                Status = true,
                Message = $"{buildingId}'e ait Kat bilgisi getirildi"
            };
        }
    }
}
