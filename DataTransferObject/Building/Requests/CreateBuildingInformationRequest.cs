using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject.User;
using Models.Entities;

namespace DataTransferObject.Building.Requests
{
    public class CreateBuildingInformationRequest
    {
        public bool IsSettled { get; set; }
        public string HomeType { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }
        public CreateHomeOwnerRequest Owner { get; set; }
    }
}
