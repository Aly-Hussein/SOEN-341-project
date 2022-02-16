//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Newtonsoft.Json;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using BudgetAmazon.Models;
//namespace BudgetAmazon.Controllers
//{
//    public class ProductController : Controller
//    {
//        private EFDataContext _db;
//        // GET: Shop
//        public ProductController(EFDataContext db)
//        {
//            this._db = db;
//        }
//        public ActionResult Index()
//        {

//            var _product = getAllProduct();
//            ViewBag.product = _product;
//            return View();
//        }

//        //GET ALL PRODUCT
//        public List<Product> getAllProduct()
//        {
//            return _db.Products.ToList();
//        }

//        //GET DETAIL PRODUCT
//        public Product getDetailProduct(int id)
//        {
//            var product = _db.Products.Find(id);
//            return product;
//        }

//        //ADD CART
//        public IActionResult addCart(int id)
//        {
//            var cart = HttpContext.Session.GetString("cart");//get key cart
//            if (cart == null)
//            {
//                var product = getDetailProduct(id);
//                List<Cart> listCart = new List<Cart>()
//                {
//                    new Cart
//                    {
//                        Product = product,
//                        Quantity = 1
//                    }
//                };
//                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCart));

//            }
//            else
//            {
//                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
//                bool check = true;
//                for (int i = 0; i < dataCart.Count; i++)
//                {
//                    if (dataCart[i].Product.idProduct == id)
//                    {
//                        dataCart[i].Quantity++;
//                        check = false;
//                    }
//                }
//                if (check)
//                {
//                    dataCart.Add(new Cart
//                    {
//                        Product = getDetailProduct(id),
//                        Quantity = 1
//                    });
//                }
//                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
//                // var cart2 = HttpContext.Session.GetString("cart");//get key cart
//                //  return Json(cart2);
//            }

//            return RedirectToAction(nameof(Index));

//        }

//        public IActionResult ListCart()
//        {
//            var cart = HttpContext.Session.GetString("cart");//get key cart
//            if (cart != null)
//            {
//                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
//                if (dataCart.Count > 0)
//                {
//                    ViewBag.carts = dataCart;
//                    return View();
//                }
//            }
//            return RedirectToAction(nameof(Index));
//        }

//        [HttpPost]
//        public IActionResult updateCart(int id, int quantity)
//        {
//            var cart = HttpContext.Session.GetString("cart");
//            if (cart != null)
//            {
//                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
//                if (quantity > 0)
//                {
//                    for (int i = 0; i < dataCart.Count; i++)
//                    {
//                        if (dataCart[i].Product.idProduct == id)
//                        {
//                            dataCart[i].Quantity = quantity;
//                        }
//                    }


//                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
//                }
//                var cart2 = HttpContext.Session.GetString("cart");
//                return Ok(quantity);
//            }
//            return BadRequest();

//        }

//        public IActionResult deleteCart(int id)
//        {
//            var cart = HttpContext.Session.GetString("cart");
//            if (cart != null)
//            {
//                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);

//                for (int i = 0; i < dataCart.Count; i++)
//                {
//                    if (dataCart[i].Product.idProduct == id)
//                    {
//                        dataCart.RemoveAt(i);
//                    }
//                }
//                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
//                return RedirectToAction(nameof(ListCart));
//            }
//            return RedirectToAction(nameof(Index));
//        }


//    }
//}
