using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_L_U_M_E_R_I_A.Data;
using P_L_U_M_E_R_I_A.Models;

namespace P_L_U_M_E_R_I_A.Controllers
{
    public class DashBoardController : Controller

    {
        private readonly ApplicationDBContext _Context;
        private IWebHostEnvironment _webHostEnvironment;
        public DashBoardController(ApplicationDBContext context, IWebHostEnvironment WebHostEnvironment)
        {
            _Context = context;
            _webHostEnvironment = WebHostEnvironment;

        }

        public IActionResult Index()
        {
            return View();
        }

        // دوال المنتج  
        public IActionResult Products()
        {
            var getdata = _Context.ProductsCate.ToList();
            ViewBag.getdata = getdata;
            var Products = _Context.Products.ToList();

            var getdatapro = _Context.Products.Join(
                _Context.ProductsCate,

                Products => Products.ProductsCate_id,
                ProductsCate => ProductsCate.Id,

                (Products, ProductsCate) => new
                {
                    Id = Products.Id,
                    Categores = ProductsCate.Name,
                    Name = Products.Name,
                    Description = Products.Description,
                    Images = Products.Images,
                    Price = Products.Price,
                }).ToList();

            ViewBag.getdatapro = getdatapro;
            return View(Products);
        }

        public IActionResult CreatNewProducts(Products Creatnewproducts, IFormFile photo) //اضافة
        {

            if (photo == null || photo.Length == 0)
            {
                return Content("Fill not Selected");
            }
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "img/prod", photo.FileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(stream);
                stream.Close();
            }

            Creatnewproducts.Images = photo.FileName;
            _Context.Add(Creatnewproducts);
            _Context.SaveChanges();
            return RedirectToAction("Products");
        }

        public IActionResult DeletProducts(int id)   //حذف
        {
            var products = _Context.Products.SingleOrDefault(c => c.Id == id);

            if (products != null)
            {
                _Context.Products.Remove(products);
                _Context.SaveChanges();
            }
            return RedirectToAction("Products");
        }

        //دوال فئة المنتج
        public IActionResult ProductsCate()
        {
            var getdata = _Context.ProductsCate.ToList();
            return View(getdata);

        }

        public IActionResult CreatNewProductsCate(ProductsCate creatnewproducts)  //اضافة
        {

            _Context.Add(creatnewproducts);
            _Context.SaveChanges();
            return RedirectToAction("ProductsCate");
        }

        public IActionResult DeletProductsCate(int id)   //حذف
        {
            var prod = _Context.ProductsCate.SingleOrDefault(c => c.Id == id);

            if (prod != null)
            {
                _Context.ProductsCate.Remove(prod);
                _Context.SaveChanges();
            }

            var prods =_Context.ProductsCate.ToList();

            return PartialView("_partial/productscate" , prods);

       }

        public IActionResult Editprodcat(int id)
        {
            var editprodcat = _Context.ProductsCate.SingleOrDefault(e => e.Id == id);
            return View(editprodcat);  
        }

        public IActionResult Updateprodcat(ProductsCate productscate)
        {
            _Context.ProductsCate.Update(productscate);
            _Context.SaveChanges();

            return RedirectToAction("ProductsCate");
        //  if (ModelState.IsValid)  // التأكد من أن البيانات المدخلة صحيحة
        //   {
        //  var product = _Context.ProductsCate.SingleOrDefault(p => p.Id == updatedProductsCate.Id);
        //
        //   if (product != null)
        //   {
        // product.Name = updatedProductsCate.Name;
        //             _Context.SaveChanges();

        //          return RedirectToAction("ProductsCate");
        //}
        //     else
        //     {
        //  ModelState.AddModelError("", "المنتج غير موجود");
        //     }
        // }
        //return View(updatedProductsCate);  // إظهار النموذج مع الأخطاء
        }


    }
}
   
