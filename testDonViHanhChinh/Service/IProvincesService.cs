using testDonViHanhChinh.Data;
using testDonViHanhChinh.Model.Request;
using testDonViHanhChinh.Repository;

namespace testDonViHanhChinh.Service
{
    public interface IProvincesService
    {


        List<Province> GetAll();
        Province GetById(int id);
        List<Province> GetByName(string name);
        void Add(ProvinceRequest provinceRequest);
        void Update(ProvinceRequest provinceRequest);
        void Delete(int id);
    }
}
