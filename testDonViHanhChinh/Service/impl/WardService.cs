using System.Xml.Linq;
using testDonViHanhChinh.Data;
using testDonViHanhChinh.Model.Request;
using testDonViHanhChinh.Model.Response;
using testDonViHanhChinh.Repository;

namespace testDonViHanhChinh.Service.impl
{
    public class WardService : IWardService
    {

        private readonly IWardrepository _wardRepository;
        private readonly IDistrictService _districtService;
        private readonly IProvincesService _provincesService;

        public WardService(IWardrepository wardRepository, IDistrictService districtService, IProvincesService provincesServic)
        {
            _wardRepository = wardRepository;
            _districtService = districtService;
            _provincesService=provincesServic;
        }
        public void AddWard(WardRequest wardRequest)
        {
            var ward = new Ward
            {
                Name = wardRequest.Name,

                DistrictId = wardRequest.DistrictId
                // Ánh xạ các thuộc tính khác nếu cần
            };

            _wardRepository.AddWard(ward);
        }

        public void DeleteWard(int id)
        {
            _wardRepository.DeleteWard(id);
        }

        public List<WardResponse> GetAllWards()
        {
            var wards = _wardRepository.GetAllWards();
            var wardResponses = wards.Select(ward => new WardResponse
            {
                Id = ward.Id,
                Name = ward.Name,

           

                DistrictName = _districtService.GetDistrictById(ward.DistrictId).Name

            }).ToList();

            return wardResponses;
        }

        public WardResponse GetWardById(int id)
        {
            var wards = _wardRepository.GetWardById(id);
            var wardResponses = new WardResponse
            {
                Id = wards.Id,
                Name = wards.Name,


                DistrictName = _districtService.GetDistrictById(wards.DistrictId).Name

            };

            return wardResponses;
        }

        public List<WardResponse> GetWardsByDistrictId(int districtId)
        {
            var wards = _wardRepository.GetWardsByDistrictId(districtId);
            var wardResponses = wards.Select(ward => new WardResponse
            {
                Id = ward.Id,
                Name = ward.Name,


                DistrictName = _districtService.GetDistrictById(ward.DistrictId).Name

            }).ToList();

            return wardResponses;
        }

        public List<WardResponse> GetWardsByName(string name)
        {
            var wards = _wardRepository.GetWardsByName(name);
            var wardResponses = wards.Select(ward => new WardResponse
            {
                Id = ward.Id,
                Name = ward.Name,


                DistrictName = _districtService.GetDistrictById(ward.DistrictId).Name

            }).ToList();

            return wardResponses;
        }

        public List<WardResponse> GetWardsByProvinceId(int provinceId)
        {
            var wards = _wardRepository.GetWardsByProvinceId(provinceId);
            var wardResponses = wards.Select(ward => new WardResponse
            {
                Id = ward.Id,
                Name = ward.Name,


                DistrictName = _districtService.GetDistrictById(ward.DistrictId).Name

            }).ToList();

            return wardResponses;
        }

        public void UpdateWard(WardRequest wardRequest)
        {
            var wardToUpdate = _wardRepository.GetWardById(wardRequest.Id);

            if (wardToUpdate != null)
            {
                wardToUpdate.Name = wardRequest.Name;
                wardToUpdate.DistrictId = wardRequest.DistrictId;

                _wardRepository.UpdateWard(wardToUpdate);
            }
        }
    }
}
