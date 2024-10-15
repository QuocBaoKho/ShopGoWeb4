using ShopGoWeb4.Models;

namespace ShopGoWeb4.Repositories
{
    public class LoaiSPRepository : ILoaiSPRepository
    {
        private readonly QlbanVaLiContext _context;
        public LoaiSPRepository(QlbanVaLiContext context)
        {
            _context = context;
        }

        public TLoaiSp Add(TLoaiSp entity)
        {
            _context.TLoaiSps.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TLoaiSp Delete(string loaiSP)
        {
            TLoaiSp deleted = _context.TLoaiSps.Find(loaiSP);
            _context.SaveChanges();
            return deleted;
        }

        public TLoaiSp Get(string loaiSP)
        {
            return _context.TLoaiSps.Find(loaiSP);
        }

        public IEnumerable<TLoaiSp> GetAll()
        {
            return _context.TLoaiSps;
        }

        public TLoaiSp Update(TLoaiSp entity)
        {
            _context.TLoaiSps.Update(entity);
            _context.SaveChanges();
            return entity; 
        }
    }
}
