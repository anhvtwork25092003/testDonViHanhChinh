using testDonViHanhChinh.Data;
using testDonViHanhChinh.Model.Request;
using testDonViHanhChinh.Model.Response;

namespace testDonViHanhChinh.Service
{
    public interface IDistrictService
    {
       

            // Lấy tất cả các huyện
            List<DistrictResponse> GetAllDistricts();

            // Lấy huyện bằng ID
            District GetDistrictById(int id);

            // Lấy huyện bằng tên
            List<District> GetDistrictByName(string name);

            // Thêm huyện mới
            void AddDistrict(DistrictRequest districtRequest);

            // Sửa thông tin huyện
            void UpdateDistrict(DistrictRequest districtRequest);

            // Xóa huyện
            void DeleteDistrict(int id);
        
    }
}
