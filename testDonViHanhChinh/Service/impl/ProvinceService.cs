using testDonViHanhChinh.Data;
using testDonViHanhChinh.Model.Request;
using testDonViHanhChinh.Model.Response;
using testDonViHanhChinh.Repository;
using testDonViHanhChinh.Repository.impl;

namespace testDonViHanhChinh.Service.impl
{
    public class ProvinceService : IProvincesService
    {
        private readonly IProviceRepository _proviceRepository;

        public ProvinceService(IProviceRepository provinceRepository)
        {
            _proviceRepository = provinceRepository;
        }

        public void Add(ProvinceRequest provinceRequest)
        {
            // Chuyển đổi từ ProvinceRequest sang Province
            var newProvince = new Province
            {
                Name = provinceRequest.Name
                // Các thuộc tính khác của Province nếu cần
            };

            _proviceRepository.Add(newProvince);
        }

        public void Delete(int id)
        {
            _proviceRepository.Delete(id);
        }

        public List<Province> GetProvinceWithDistrict()
        {
            return _proviceRepository.GetProvinceWithDistrict();
        }
        public List<ProvinceResponse> GetListProvince()
        {
            var pronvinces = _proviceRepository.GetListProvince().ToList();
            var provincesResponse = pronvinces.Select(pronvinces => new ProvinceResponse
            {
                Id= pronvinces.Id,
                Name= pronvinces.Name,
            }).ToList();
            return provincesResponse;
        }

        public Province GetById(int id)
        {
            return _proviceRepository.GetById(id);
        }

        public List<Province> GetByName(string name)
        {
            return _proviceRepository.GetByName(name);
        }

        public void Update(ProvinceRequest provinceRequest)
        {
            // Tìm tỉnh/thành phố cần cập nhật
            var existingProvince = _proviceRepository.GetById(provinceRequest.Id);

            if (existingProvince != null)
            {
                // Cập nhật thông tin từ ProvinceRequest
                existingProvince.Name = provinceRequest.Name;
                // Cập nhật các thuộc tính khác nếu cần

                _proviceRepository.Update(existingProvince);
            }
        }
    }
}
