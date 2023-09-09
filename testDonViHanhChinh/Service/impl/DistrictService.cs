using Microsoft.EntityFrameworkCore;
using testDonViHanhChinh.Data;
using testDonViHanhChinh.Model.Request;
using testDonViHanhChinh.Model.Response;
using testDonViHanhChinh.Repository;

namespace testDonViHanhChinh.Service.impl
{
    public class DistrictService: IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;

        public DistrictService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public List<DistrictResponse> GetAllDistricts()
        {
            var districts = _districtRepository.GetAllDistricts().ToList();

            // Ánh xạ từ District sang DistrictResponse
            var districtResponses = districts.Select(district => new DistrictResponse
            {
                Id = district.Id,
                Name = district.Name,
                // Sao chép các thuộc tính khác nếu cần
            }).ToList();

            return districtResponses;
        }

        public District GetDistrictById(int id)
        {
            return _districtRepository.GetDistrictById(id);
        }

        public List<District> GetDistrictByName(string name)
        {
            return _districtRepository.GetDistrictByName(name).ToList();
        }

        public void AddDistrict(DistrictRequest districtRequest)
        {
            if (districtRequest == null)
            {
                throw new ArgumentNullException(nameof(districtRequest));
            }


            var district = new District
            {
                Name = districtRequest.Name,
                ProvinceId = districtRequest.ProvinceId,

            };

            _districtRepository.AddDistrict(district);
        }

        public void UpdateDistrict(DistrictRequest districtRequest)
        {
            if (districtRequest == null)
            {
                throw new ArgumentNullException(nameof(districtRequest));
            }

            var existingDistrict = _districtRepository.GetDistrictById(districtRequest.Id);

            if (existingDistrict != null)
            {
                existingDistrict.Name = districtRequest.Name;
                existingDistrict.ProvinceId = districtRequest.ProvinceId;
                _districtRepository.UpdateDistrict(existingDistrict);
            }
        }

        public void DeleteDistrict(int id)
        {
            _districtRepository.DeleteDistrict(id);
        }
    }
}
