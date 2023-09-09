using testDonViHanhChinh.Data;

namespace testDonViHanhChinh.Repository.impl
{
    public class Wardrepository: IWardrepository
    {
        private readonly DataDbContext _context;

        public Wardrepository(DataDbContext context)
        {
            _context = context;
        }

        public List<Ward> GetAllWards()
        {
            return _context.Wards.ToList();
        }

        public Ward GetWardById(int id)
        {
            return _context.Wards.FirstOrDefault(w => w.Id == id);
        }

        public List<Ward> GetWardsByName(string name)
        {
            return _context.Wards.Where(w => w.Name.Contains(name)).ToList();
        }

        public List<Ward> GetWardsByDistrictId(int districtId)
        {
            return _context.Wards.Where(w => w.DistrictId == districtId).ToList();
        }

        public List<Ward> GetWardsByProvinceId(int provinceId)
        {
            return _context.Wards.Where(w => w.District.ProvinceId == provinceId).ToList();
        }

        public void AddWard(Ward ward)
        {
            _context.Wards.Add(ward);
            _context.SaveChanges();
        }

        public void UpdateWard(Ward ward)
        {
            _context.Wards.Update(ward);
            _context.SaveChanges();
        }

        public void DeleteWard(int id)
        {
            var wardToDelete = _context.Wards.FirstOrDefault(w => w.Id == id);
            if (wardToDelete != null)
            {
                _context.Wards.Remove(wardToDelete);
                _context.SaveChanges();
            }
        }
    }
}
