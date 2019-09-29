using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/cart")]
    public class CartController : ApiController
    {
        private ProductRepository productRepository = new ProductRepository();
        private CartRepository cartRepository = new CartRepository();

        [AcceptVerbs("POST")]
        [Route("AddCart")]
        public string AddCart(Cart cart)
        {
            try
            {
                cartRepository.Create(cart);
                return $"Cart added! CartID={cart.ID}";
            }
            catch (Exception)
            {
                throw;
            }
        }

        [AcceptVerbs("PUT")]
        [Route("AddProduct/{cartId}/{productId}")]
        public string AddProduct(int cartId, int productId)
        {
            try
            {
                Cart cart = cartRepository.Restore(cartId);
                if (cart == null)
                    throw new Exception("Cart not found");

                Product product = productRepository.Restore(productId);

                if (product == null)
                    throw new Exception("Product not found");

                cart.Products.Add(product);

                cartRepository.Update(cart);

                return "Product added in cart with sucess!";
            }
            catch (Exception)
            {

                throw;
            }
        }


        [AcceptVerbs("Delete")]
        [Route("RemoveProduct/{cartId}/{productID}")]
        public string RemoveProduct(int cartId, int productId)
        {
            try
            {
                Cart cart = cartRepository.Restore(cartId);
                if (cart == null)
                    throw new Exception("Cart not found");

                Product product = cart.Products.Where(x => x.ID == productId).FirstOrDefault();

                if (product == null)
                    throw new Exception("Product not found");

                cart.Products.Remove(product);

                cartRepository.Update(cart);

                return "Product removed with sucess!";
            }
            catch (Exception)
            {

                throw;
            }
        }

        [AcceptVerbs("DELETE")]
        [Route("DeleteCart/{id}")]
        public string DeleteCart(int id)
        {
            try
            {
                cartRepository.Delete(cartRepository.Restore(id));

                return "Cart Deleted";
            }
            catch (Exception)
            {

                throw;
            }

        }

        [AcceptVerbs("GET")]
        [Route("GetCartByID/{id}")]
        public Cart GetCartByID(int id)
        {
            try
            {
                return cartRepository.Restore(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [AcceptVerbs("GET")]
        [Route("GetAllCarts")]
        public IList<Cart> GetAllCarts()
        {
            try
            {
                return cartRepository.RestoreAll();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
