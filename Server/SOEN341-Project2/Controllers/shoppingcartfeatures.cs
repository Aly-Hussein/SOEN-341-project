using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using items.Models;

namespace items.Logic
{
  public class ShoppingCartActions : IDisposable
  {
    public string shopping_card_id { get; set; }

    private ProductContext _db = new ProductContext();

    public const string CartSessionKey = "CartId";

    public void AddToCart(int id)
    {
      // Retrieve the product from the database.           
      shopping_card_id = get_card_id();

      var cart_item = _db.shpping_cart_item.SingleOrDefault(
          c => c.CartId == shopping_card_id
          && c.ProductId == id);
      if (cart_item == null)
      {
        // Create a new cart item if no cart item exists.                 
        cart_item = new cart_item
        {
          ItemId = Guid.NewGuid().ToString(),
          ProductId = id,
          CartId = shopping_card_id,
          Product = _db.Products.SingleOrDefault(
           p => p.ProductID == id),
          Quantity = 1,
          DateCreated = DateTime.Now
        };

        _db.shpping_cart_item.Add(cart_item);
      }
      else
      {
        // If the item does exist in the cart,                  
        // then add one to the quantity.                 
        cart_item.Quantity++;
      }
      _db.SaveChanges();
    }

    public void Dispose()
    {
      if (_db != null)
      {
        _db.Dispose();
        _db = null;
      }
    }

    public string get_card_id()
    {
      if (HttpContext.Current.Session[CartSessionKey] == null)
      {
        if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
        {
          HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
        }
        else
        {
          // Generate a new random GUID using System.Guid class.     
          Guid tempCartId = Guid.NewGuid();
          HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
        }
      }
      return HttpContext.Current.Session[CartSessionKey].ToString();
    }

    public List<> get_cart_items()
    {
      shopping_card_id = get_card_id();

      return _db.shpping_cart_item.Where(
          c => c.CartId == shopping_card_id).ToList();
    }
  }
}
