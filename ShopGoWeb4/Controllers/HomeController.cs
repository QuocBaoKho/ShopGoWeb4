using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopGoWeb4.Models;
using System.Diagnostics;
using X.PagedList;

namespace ShopGoWeb4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private QlbanVaLiContext _lbanVaLiContext;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _lbanVaLiContext = new QlbanVaLiContext();
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNum = page==null||page < 0? 1 : page.Value;
            var ds = _lbanVaLiContext.TDanhMucSps.AsNoTracking().OrderBy(d=>d.TenSp);
            PagedList<TDanhMucSp> list = new PagedList<TDanhMucSp>(ds, pageNum, pageSize);
            return View(list);
        }
        public IActionResult Sanphamtheoloai(string maLoai, int? page)
        {
            int pageSize = 8;
            int pageNum = page == null || page < 0 ? 1 : page.Value;
            var listSPLoai = _lbanVaLiContext.TDanhMucSps.AsNoTracking().Where(dm=>dm.MaLoai.Equals(maLoai)).OrderBy(dm=>dm.TenSp);
            PagedList<TDanhMucSp> list = new PagedList<TDanhMucSp>(listSPLoai, pageNum, pageSize);
            ViewBag.MaLoai = maLoai;
            return View(list);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
