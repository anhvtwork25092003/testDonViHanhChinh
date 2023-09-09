using Microsoft.AspNetCore.Mvc;
using testDonViHanhChinh.Model.Request;
using testDonViHanhChinh.Model.Response;
using testDonViHanhChinh.Service;

namespace testDonViHanhChinh.Controllers
{
    public class WardController : Controller
    {
        private readonly IWardService _wardService;

        public WardController(IWardService wardService)
        {
            _wardService = wardService;
        }

        [HttpGet("get-list-ward")]
        public ActionResult<List<WardResponse>> GetAllWards()
        {
            var wards = _wardService.GetAllWards();
            return Ok(wards);
        }

        [HttpGet("get-ward-by-id/{id}")]
        public ActionResult<WardResponse> GetWardById(int id)
        {
            var ward = _wardService.GetWardById(id);
            if (ward != null)
            {
                return Ok(ward);
            }
            return NotFound(); // Trả về mã lỗi 404 nếu không tìm thấy
        }

        [HttpGet("getwardbyname")]
        public ActionResult<List<WardResponse>> GetWardsByName(string name)
        {
            var wards = _wardService.GetWardsByName(name);
            return Ok(wards);
        }

        [HttpGet("getwardbydistrict/{districtId}")]
        public ActionResult<List<WardResponse>> GetWardsByDistrictId(int districtId)
        {
            var wards = _wardService.GetWardsByDistrictId(districtId);
            return Ok(wards);
        }

        [HttpGet("getwardbyprovince/{provinceId}")]
        public ActionResult<List<WardResponse>> GetWardsByProvinceId(int provinceId)
        {
            var wards = _wardService.GetWardsByProvinceId(provinceId);
            return Ok(wards);
        }

        [HttpPost("addward")]
        public IActionResult AddWard([FromBody] WardRequest wardRequest)
        {
            _wardService.AddWard(wardRequest);
            return Ok(); // Trả về mã lỗi 200 OK sau khi thêm thành công
        }

        [HttpPut("updateward")]
        public IActionResult UpdateWard([FromBody] WardRequest wardRequest)
        {
            _wardService.UpdateWard(wardRequest);
            return Ok(); // Trả về mã lỗi 200 OK sau khi cập nhật thành công
        }

        [HttpDelete("deleteward/{id}")]
        public IActionResult DeleteWard(int id)
        {
            _wardService.DeleteWard(id);
            return Ok(); // Trả về mã lỗi 200 OK sau khi xóa thành công
        }
    }
}
