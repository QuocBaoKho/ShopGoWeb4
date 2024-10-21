using ShopGoWeb4.Models;

namespace ShopGoWeb4.ViewModels
{
    public class HomeProductDetailsViewModel
    {
        public TDanhMucSp danhMucSp;
        public List<TAnhSp> anhSp;
        public HomeProductDetailsViewModel(TDanhMucSp anhMucSp, List<TAnhSp> anhSp)
        {
            danhMucSp = anhMucSp;
            this.anhSp = anhSp;
        }
    }
}
