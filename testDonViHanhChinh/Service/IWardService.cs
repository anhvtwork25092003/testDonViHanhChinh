using testDonViHanhChinh.Data;
using testDonViHanhChinh.Model.Request;
using testDonViHanhChinh.Model.Response;

namespace testDonViHanhChinh.Service
{
    public interface IWardService
    {
        List<WardResponse> GetAllWards();
        WardResponse GetWardById(int id);
        List<WardResponse> GetWardsByName(string name);
        List<WardResponse> GetWardsByDistrictId(int districtId);
        List<WardResponse> GetWardsByProvinceId(int provinceId);
        void AddWard(WardRequest wardRequest);
        void UpdateWard(WardRequest wardRequest);
        void DeleteWard(int id);
    }
}
