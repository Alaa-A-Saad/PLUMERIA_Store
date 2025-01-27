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
            // ÊÕÝíÉ ÇáãäÊÌÇÊ ÇáÊí ÊäÊãí Åáì ÝÆÉ ""
            var skincareCategory = _Context.ProductsCate.FirstOrDefault(c => c.Name == "ÇáÚäÇíÉ ÈÇáÈÔÑÉ");

            if (skincareCategory != null)
            {
                var skincare = _Context.Products.Where(p => p.ProductsCate_id == skincareCategory.Id).ToList();
                return View(skincare);
            }

            return View(); // Ýí ÍÇá ÚÏã æÌæÏ ÝÆÉ 
        }

        public IActionResult Gifts()
        {

            // ÊÕÝíÉ ÇáãäÊÌÇÊ ÇáÊí ÊäÊãí Åáì ÝÆÉ "
            var giftseCategory = _Context.ProductsCate.FirstOrDefault(c => c.Name == "ÇáåÏÇíÇ");

            if (giftseCategory != null)
            {
                var gifts = _Context.Products.Where(p => p.ProductsCate_id == giftseCategory.Id).ToList();
                return View(gifts);
            }

            return View(); 
        }

        public ActionResult Candles()
        {
            // ÊÕÝíÉ ÇáãäÊÌÇÊ ÇáÊí ÊäÊãí Åáì ÝÆÉ "ÔãæÚ"
            var candleCategory = _Context.ProductsCate.FirstOrDefault(c => c.Name == "ÇáÔãæÚ");

            if (candleCategory != null)
            {
                var candles = _Context.Products.Where(p => p.ProductsCate_id == candleCategory.Id).ToList();
                return View(candles);
            }

            return View(); // Ýí ÍÇá ÚÏã æÌæÏ ÝÆÉ "ÔãæÚ"
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
