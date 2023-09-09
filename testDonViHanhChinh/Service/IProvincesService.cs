using testDonViHanhChinh.Data;
using testDonViHanhChinh.Model.Request;
using testDonViHanhChinh.Model.Response;
using testDonViHanhChinh.Repository;

namespace testDonViHanhChinh.Service
{
    public interface IProvincesService
    {
        List<ProvinceResponse> GetListProvince();

        List<Province> GetProvinceWithDistrict();
        Province GetById(int id);
        List<Province> GetByName(string name);
        void Add(ProvinceRequest provinceRequest);
        void Update(ProvinceRequest provinceRequest);
        void Delete(int id);
    }
}
