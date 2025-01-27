using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_L_U_M_E_R_I_A.Data;
using P_L_U_M_E_R_I_A.Models;

namespace P_L_U_M_E_R_I_A.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _Context;


        public HomeController(ApplicationDBContext context)
        {
            _Context = context;

        }

        public IActionResult Index()
        {
            var index = _Context.Products.ToList();
            return View(index);
        }
      
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Payment()
        {
            return View(); 
        }


        public IActionResult Skincare()
        {
            // ����� �������� ���� ����� ��� ��� ""
            var skincareCategory = _Context.ProductsCate.FirstOrDefault(c => c.Name == "������� �������");

            if (skincareCategory != null)
            {
                var skincare = _Context.Products.Where(p => p.ProductsCate_id == skincareCategory.Id).ToList();
                return View(skincare);
            }

            return View(); // �� ��� ��� ���� ��� 
        }

        public IActionResult Gifts()
        {

            // ����� �������� ���� ����� ��� ��� "
            var giftseCategory = _Context.ProductsCate.FirstOrDefault(c => c.Name == "�������");

            if (giftseCategory != null)
            {
                var gifts = _Context.Products.Where(p => p.ProductsCate_id == giftseCategory.Id).ToList();
                return View(gifts);
            }

            return View(); 
        }

        public ActionResult Candles()
        {
            // ����� �������� ���� ����� ��� ��� "����"
            var candleCategory = _Context.ProductsCate.FirstOrDefault(c => c.Name == "������");

            if (candleCategory != null)
            {
                var candles = _Context.Products.Where(p => p.ProductsCate_id == candleCategory.Id).ToList();
                return View(candles);
            }

            return View(); // �� ��� ��� ���� ��� "����"
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
