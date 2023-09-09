using Microsoft.AspNetCore.Mvc;
using testDonViHanhChinh.Data;
using testDonViHanhChinh.Model.Request;
using testDonViHanhChinh.Service;

namespace testDonViHanhChinh.Controllers
{
    public class DistrictController : Controller
    {
        private readonly IDistrictService _districtService;
        
        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpGet("Get-list-district")]
        public ActionResult<IEnumerable<District>> GetAllDistricts()
        {
            var districts = _districtService.GetAllDistricts();
            return Ok(districts);
        }

        [HttpGet("get-district-by-id{id}")]
        public ActionResult<District> GetDistrictById(int id)
        {
            var district = _districtService.GetDistrictById(id);
            if (district == null)
            {
                return NotFound();
            }
            return Ok(district);
        }

        [HttpGet("get-district-by-name/{name}")]
        public ActionResult<IEnumerable<District>> GetDistrictByName(string name)
        {
            var districts = _districtService.GetDistrictByName(name);
            return Ok(districts);
        }

        [HttpPost("add-district")]
        public IActionResult AddDistrict([FromBody] DistrictRequest districtRequest)
        {
            try
            {
                _districtService.AddDistrict(districtRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi HTTP 500 hoặc tùy chọn khác
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDistrict(int id, [FromBody] DistrictRequest districtRequest)
        {
            try
            {
                var existingDistrict = _districtService.GetDistrictById(id);
                if (existingDistrict == null)
                {
                    return NotFound();
                }

                districtRequest.Id = id; // Đảm bảo ID không bị thay đổi
                _districtService.UpdateDistrict(districtRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi HTTP 500 hoặc tùy chọn khác
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDistrict(int id)
        {
            try
            {
                var existingDistrict = _districtService.GetDistrictById(id);
                if (existingDistrict == null)
                {
                    return NotFound();
                }

                _districtService.DeleteDistrict(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về lỗi HTTP 500 hoặc tùy chọn khác
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("byprovince/{provinceId}")]
        public ActionResult<IEnumerable<District>> GetDistrictsByProvinceId(int provinceId)
        {
            var districts = _districtService.GetDistrictsByProvinceId(provinceId);
            if (districts == null || !districts.Any())
            {
                return NotFound();
            }
            return Ok(districts);
        }
    }
}
