using Medibook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medibook.App_Classes
{
    public class Basket
    {
        public static Basket ActiveBasket
        {
            get
            {
                HttpContext ctx = HttpContext.Current;

                if (ctx.Session["ActiveBasket"] == null)
                {
                    ctx.Session["ActiveBasket"] = new Basket();
                }
                return (Basket)ctx.Session["ActiveBasket"];
            }
        }


        private List<BasketItem> items = new List<BasketItem>();

        public List<BasketItem> Items
        {
            get { return items; }
            set { items = value; }
        }

        public void AddToBasket(BasketItem bi)
        {

            if (HttpContext.Current.Session["ActiveBasket"] != null)
            {
                Basket basket = (Basket)HttpContext.Current.Session["ActiveBasket"];


                if (basket.Items.Any(x => x.Book.Id == bi.Book.Id))
                {
                    basket.Items.FirstOrDefault(x => x.Book.Id == bi.Book.Id).Quantity++; //Eğer kitap sepette mevcutsa adetini arttır
                }
                else
                {
                    basket.Items.Add(bi); //Değilse ekle
                }
            }

            else {
                Basket basket = new Basket();
                basket.Items.Add(bi);

                HttpContext.Current.Session["ActiveBasket"] = basket;
            }

        }

        public double GrandTotal
        {
            get {
                return Items.Sum(x => x.Total);
            }
        }
    }
    public class BasketItem
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public double Total
        {
            get
            {
                return Book.Price * Quantity;
            }
        }
    }
}



