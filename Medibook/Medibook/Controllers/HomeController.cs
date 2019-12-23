using Medibook.App_Classes;
using Medibook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medibook.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("~/")]
        public ActionResult Index(string searchString)
        {
            var data = from n in db.Books.ToList()
                       select n;

            if (!String.IsNullOrEmpty(searchString))
            {
                data = data.Where(x => x.Name.ToLower().Contains(searchString) || x.Author.ToLower().Contains(searchString) ||
                x.Category.Name.ToLower().Contains(searchString));

                return View(data.ToList());
            }

            List<Book> list = db.Books.ToList();
            return View(list);
        }

      
        [Route("~/category/{id}/{name}")]
        public ActionResult GetByCategory(int? id)
        {
            List<Book> books = db.Books.ToList().Where(
                x => x.Category.Id == id).ToList();

            return View("Index", books);
        }

        [Route("~/bookdetail/{id}/{name}")]
        public ActionResult BookDetail(int id)
        {
            Book item = db.Books.Find(id);

            item.Ratio++;
            db.SaveChanges();


            return View(item);


        }

        public void AddToBasket(int id)
        {
            BasketItem bi = new BasketItem();

            Book book = db.Books.FirstOrDefault(x => x.Id == id);

            bi.Book = book;
            bi.Quantity = 1;
            Basket b = new Basket();
            b.AddToBasket(bi);

            BasketWidget();
        }


        public PartialViewResult BasketWidget()
        {
            if (HttpContext.Session["ActiveBasket"] != null)
            {
                return PartialView((Basket)HttpContext.Session["ActiveBasket"]);

            }

            else
            {
                return PartialView();
            }
        }

        public ActionResult Basket()
        {
            if (HttpContext.Session["ActiveBasket"] != null)
            {
                return View((Basket)HttpContext.Session["ActiveBasket"]);

            }

            else
            {
                return View();
            }
        }

        public void ReduceBasketItem(int id) {

            if (HttpContext.Session["ActiveBasket"] != null)
            {
                Basket basket = (Basket)HttpContext.Session["ActiveBasket"];

                if (basket.Items.FirstOrDefault(x => x.Book.Id == id).Quantity > 1)
                {
                    basket.Items.FirstOrDefault(x => x.Book.Id == id).Quantity--;
                }
                else
                {
                    BasketItem bi = basket.Items.FirstOrDefault(x => x.Book.Id == id);
                    basket.Items.Remove(bi);
                }
            }

           
        }

        public void OrderVerify()
        {

            if (HttpContext.Session["ActiveBasket"] != null)
            {
                Session.Clear();
            }


        }
    }
}