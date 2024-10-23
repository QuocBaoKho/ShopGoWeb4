using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopGoWeb4.Models;

namespace ShopGoWeb4.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        private QlbanVaLiContext db = new QlbanVaLiContext();

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("productlist")]

        public IActionResult Product_List() 
        {
            var plist = db.TDanhMucSps.Include(p=>p.MaChatLieuNavigation)
                .Include(p=>p.MaHangSxNavigation).ToList();
            return View(plist); 
        }
    }
}
