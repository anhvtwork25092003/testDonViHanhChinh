using Microsoft.AspNetCore.Mvc;
using testDonViHanhChinh.Model.Request;
using testDonViHanhChinh.Service;

namespace testDonViHanhChinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvincesService _provinceService;

        public ProvinceController(IProvincesService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet]
        public IActionResult GetAllProvinces()
        {
            var provinces = _provinceService.GetAll();
            return Ok(provinces);
        }

        [HttpGet("{id}")]
        public IActionResult GetProvinceById(int id)
        {
            var province = _provinceService.GetById(id);
            if (province == null)
            {
                return NotFound("Tỉnh/Thành phố không tồn tại.");
            }
            return Ok(province);
        }

        [HttpGet("search")]
        public IActionResult SearchProvinceByName([FromQuery] string name)
        {
            var provinces = _provinceService.GetByName(name);
            return Ok(provinces);
        }

        [HttpPost]
        public IActionResult CreateProvince([FromBody] ProvinceRequest provinceRequest)
        {
            _provinceService.Add(provinceRequest);
            return CreatedAtAction(nameof(GetProvinceById), new { id = provinceRequest.Id }, provinceRequest);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProvince(int id, [FromBody] ProvinceRequest provinceRequest)
        {
            provinceRequest.Id = id;
            _provinceService.Update(provinceRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProvince(int id)
        {
            _provinceService.Delete(id);
            return NoContent();
        }
    }
}
