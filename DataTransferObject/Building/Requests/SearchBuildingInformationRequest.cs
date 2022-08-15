using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Building.Requests
{
    /*
     * DTO For Searching A Home Information
     */
    public class SearchBuildingInformationRequest
    {
        public int Id { get; set; }
        public bool IsSettled { get; set; }
        public string HomeType { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }
    }
}
