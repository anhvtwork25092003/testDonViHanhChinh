using testDonViHanhChinh.Data;

namespace testDonViHanhChinh.Repository
{
    public interface IWardrepository
    {
        List<Ward> GetAllWards();
        Ward GetWardById(int id);
        List<Ward> GetWardsByName(string name);
        List<Ward> GetWardsByDistrictId(int districtId);
        List<Ward> GetWardsByProvinceId(int provinceId);
        void AddWard(Ward ward);
        void UpdateWard(Ward ward);
        void DeleteWard(int id);
    }
}
