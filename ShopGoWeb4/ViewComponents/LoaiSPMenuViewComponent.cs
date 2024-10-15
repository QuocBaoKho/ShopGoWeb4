using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopGoWeb4.Repositories;

namespace ShopGoWeb4.ViewComponents
{
    public class LoaiSPMenuViewComponent:ViewComponent
    {
        ILoaiSPRepository repository;
        public LoaiSPMenuViewComponent(ILoaiSPRepository repository)
        {
            this.repository = repository;
        }
        public IViewComponentResult Invoke()
        {
            var loai = repository.GetAll().OrderBy(x => x.Loai);
            return View(loai);
        }
    } 
}
