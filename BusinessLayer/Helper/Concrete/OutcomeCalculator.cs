using AutoMapper;
using BusinessLayer.Configuration.CommandResponse;
using BusinessLayer.Helper.Abstract;
using DataAccessLayer.Abstract;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Helper
{
    /*
     * Apartment Fee Calculator Class
     */
    public class OutcomeCalculator:IOutcomeCalculator
    {
        private readonly IHomeRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OutcomeCalculator(IHomeRepository ownerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ownerRepository = ownerRepository;
        }

        public decimal BillCalculator(decimal price, int cnt)
        {
            if (price < 0)
            {
                return 0;
            }
            else
            {
                decimal bill = price / cnt;
                return bill;
            }
        }

        public void BillAssigner(decimal price)
        {
            var data = _ownerRepository.GetAll();
            int cnt = data.Count();
            foreach (var entity in data)
            {
                entity.Bill = BillCalculator(price,cnt);
                _mapper.Map<HomeOwner>(entity);
                _ownerRepository.Update(entity);
            }
            _ownerRepository.SaveChages();
            
        }
    }
}
