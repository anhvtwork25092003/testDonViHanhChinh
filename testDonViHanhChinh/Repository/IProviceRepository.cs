using testDonViHanhChinh.Data;

namespace testDonViHanhChinh.Repository
{
    public interface IProviceRepository
    {

        // chi lay danh sach cac tinh/thanh pho
        List<Province> GetListProvince();


        // lay danh sach thanh pho kem cac quan/huyen truc thuoc
        List<Province> GetProvinceWithDistrict();

        // lay ra thong tin cua tinh boi id
        Province GetById(int id);

        // lay ra thong tin tinh bang ten
        List<Province> GetByName(string name);


        void Add(Province province);
        void Update(Province province);
        void Delete(int id);
    }
}
