using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using testDonViHanhChinh.Data;

namespace testDonViHanhChinh.Model.Request
{
    public class DistrictRequest
    {

        public int Id { get; set; }


        public string Name { get; set; }


        public int ProvinceId { get; set; }


    }
}
