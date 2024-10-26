using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [Route("add")]
        [HttpGet]
        public IActionResult ThemSanPham()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus, "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes, "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia, "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps, "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts, "MaDt", "TenLoai");
            return View();
        }
        [Route("add")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPham(TDanhMucSp sanp)
        {
            if(ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sanp);
                db.SaveChanges();
                return RedirectToAction("Product_List");
            }
            return View(sanp);
        }
        [Route("update")]
        [HttpGet]
        public IActionResult ChinhSuaSanPham(string MaSP)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus, "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes, "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia, "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps, "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts, "MaDt", "TenLoai");
            var updated = db.TDanhMucSps.Find(MaSP);
            return View(updated);
        }
        [Route("update")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChinhSuaSanPham(TDanhMucSp sp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Product_List", "homeadmin");
            }
            return View(sp);
        }
        [Route("delete")]
        [HttpGet]
        public IActionResult Delete(string MaSp)
        {
            TempData["message"] = string.Empty;
            var chiTiets = db.TChiTietSanPhams.Where(ct=>ct.MaSp.Equals(MaSp)).ToList();
            if(chiTiets.Count > 0)
            {
                TempData["message"] = "Can't remove this product";
                return RedirectToAction("Product_List", "homeadmin");
            }
            var anhSPs = db.TAnhSps.Where(anh=>anh.MaSp.Equals(MaSp)).ToList();
            if(anhSPs.Any())
            {
                db.RemoveRange(anhSPs);
            }
            db.Remove(db.TDanhMucSps.Find(MaSp));
            db.SaveChanges();
            TempData["message"] = "Remove Product Successfully";
            return RedirectToAction("Product_List", "homeadmin");
        }
    }
}
