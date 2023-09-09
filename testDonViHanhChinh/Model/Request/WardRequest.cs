using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using testDonViHanhChinh.Data;

namespace testDonViHanhChinh.Model.Request
{
    public class WardRequest
    {


        public int Id { get; set; }


        public string Name { get; set; }


        public int DistrictId { get; set; }


    }
}
