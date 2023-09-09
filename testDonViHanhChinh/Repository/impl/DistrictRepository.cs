using Microsoft.EntityFrameworkCore;
using testDonViHanhChinh.Data;

namespace testDonViHanhChinh.Repository.impl
{
    public class DistrictRepository:IDistrictRepository
    {
        private readonly DataDbContext _context;

        public DistrictRepository(DataDbContext context)
        {
            _context = context;
        }

        public List<District> GetAllDistricts()
        {
            return _context.Districts.ToList();
        }

        public District GetDistrictById(int id)
        {
            return _context.Districts.Include(d => d.Wards).FirstOrDefault(d => d.Id == id);
        }

        public List<District> GetDistrictByName(string name)
        {
            return _context.Districts.Include(d => d.Wards).
                Where(d => d.Name == name).ToList();
        }

        public void AddDistrict(District district)
        {
            if (district == null)
            {
                throw new ArgumentNullException(nameof(district));
            }

            _context.Districts.Add(district);
            _context.SaveChanges();
        }

        public void UpdateDistrict(District district)
        {
            if (district == null)
            {
                throw new ArgumentNullException(nameof(district));
            }

            _context.Entry(district).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteDistrict(int id)
        {
            var district = _context.Districts.Find(id);
            if (district != null)
            {
                _context.Districts.Remove(district);
                _context.SaveChanges();
            }
        }
    }

}
