using testDonViHanhChinh.Data;

namespace testDonViHanhChinh.Repository
{
    public interface IDistrictRepository
    {

        // Lấy tất cả các huyện
        List<District> GetAllDistricts();

        // Lấy huyện bằng ID
        District GetDistrictById(int id);

        // Lấy huyện bằng tên
        List<District> GetDistrictByName(string name);

        // Thêm huyện mới
        void AddDistrict(District district);

        // Sửa thông tin huyện
        void UpdateDistrict(District district);

        // Xóa huyện
        void DeleteDistrict(int id);
    }
}
