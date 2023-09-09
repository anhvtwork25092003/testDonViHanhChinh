using Microsoft.EntityFrameworkCore;
using testDonViHanhChinh.Data;

namespace testDonViHanhChinh.Repository.impl
{
    public class ProviceRepository : IProviceRepository
    {
        private readonly DataDbContext _context;

        public ProviceRepository(DataDbContext context)
        {
            _context = context;
        }

        public void Add(Province province)
        {
            _context.Provinces.Add(province);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var province = _context.Provinces.FirstOrDefault(p => p.Id == id);
            if (province != null)
            {
                _context.Provinces.Remove(province);
                _context.SaveChanges();
            }
        }

        public List<Province> GetProvinceWithDistrict()
        {
            return _context.Provinces
                .Include(p => p.Districts).
                ToList();
        }
        public List<Province> GetListProvince()
        {
            return _context.Provinces
              .
                ToList();
        }

        public Province GetById(int id)
        {
            return _context.Provinces.Include(p => p.Districts).
                  ThenInclude(p => p.Wards).
                FirstOrDefault(p => p.Id == id);
        }

        public List<Province> GetByName(string name)
        {
            return _context.Provinces.Where(p => p.Name.Equals(name))
                .Include(p => p.Districts).
                ThenInclude(p => p.Wards).ToList();
        }

        public void Update(Province province)
        {
            _context.Entry(province).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
