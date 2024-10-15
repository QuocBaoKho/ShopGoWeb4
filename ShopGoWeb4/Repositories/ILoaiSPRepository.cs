using ShopGoWeb4.Models;

namespace ShopGoWeb4.Repositories
{
    public interface ILoaiSPRepository
    {
        TLoaiSp Add(TLoaiSp entity);
        TLoaiSp Update(TLoaiSp entity);
        TLoaiSp Delete(string loaiSP);
        TLoaiSp Get(string loaiSP);
        IEnumerable<TLoaiSp> GetAll();
    }
}
