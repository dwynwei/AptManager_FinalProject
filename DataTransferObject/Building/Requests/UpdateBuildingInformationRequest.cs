using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Building.Requests
{
    public class UpdateBuildingInformationRequest
    {
        public int Id { get; set; }
        public bool IsSettled { get; set; }
        public string HomeType { get; set; } = string.Empty;
        public string Floor { get; set; } = string.Empty;
        public string DoorNumber { get; set; } = string.Empty;
        ICollection<HomeOwner> Owner { get; set; }
    }
}
