using FloristMary.Infrastructure;
using FloristMary.Models;
using FloristMary.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FloristMary.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _context;
        public CartController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index() //This action returns the view for the cart page
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };

            return View(cartVM);
        
        }
        //In this code, the Add action is marked with the async keyword, which indicates that it is an asynchronous method.
        public async Task<IActionResult> Add(long id)  // This action adds a product to the cart. It uses a product id to look up the product in the database, and then adds it to the cart. The cart is stored in the session, using a custom extension method called SetJson.
        {
            Product product = await _context.Products.FindAsync(id); 

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>(); 

            CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            TempData["Success"] = "The product has been added!";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Decrease(long id) //This action decreases the quantity of a product in the cart by one. If the quantity becomes zero, the product is removed from the cart.
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.ProductId == id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "The product has been removed!";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(long id) //This action removes a product from the cart completely.
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(p => p.ProductId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "The product has been removed!";

            return RedirectToAction("Index");
        }

        public IActionResult Clear() //This action clears the entire cart.
        {
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index");
        }
        
        public IActionResult Thanks() // This action returns the view for the "thank you" page, which is displayed after the user has completed a purchase.
        {
            return View();
        }
        public IActionResult Checkout() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(User user)  //This action handles the checkout process. It displays a form for the user to enter their details, and then saves the user's information to the database when the form is submitted.
        {
            if (ModelState.IsValid)
            {
                
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Thanks",user);
            }
            return View(user);
        }





    }
}
