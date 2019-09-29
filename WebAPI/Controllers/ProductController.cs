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
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private ProductRepository productRepository = new ProductRepository();

        [AcceptVerbs("POST")]
        [Route("AddProduct")]
        public string AddProduct(Product product)
        {
            try
            {
                productRepository.Create(product);
                return "Product added!";
            }
            catch (Exception)
            {
                throw;
            }
        }

        [AcceptVerbs("PUT")]
        [Route("AlterProduct")]
        public string AlterProduct(Product product)
        {
            try
            {
                productRepository.Update(product);
                return "Product updated!";
            }
            catch (Exception)
            {

                throw;
            }
        }

        [AcceptVerbs("DELETE")]
        [Route("DeleteProduct/{id}")]
        public string DeleteProduct(int id)
        {
            try
            {
                productRepository.Delete(productRepository.Restore(id));

                return "Product Deleted";
            }
            catch (Exception)
            {

                throw;
            }

        }

        [AcceptVerbs("GET")]
        [Route("GetProductByID/{id}")]
        public Product GetProductByID(int id)
        {
            try
            {
                return productRepository.Restore(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [AcceptVerbs("GET")]
        [Route("GetAllProducts")]
        public IList<Product> GetAllProducts()
        {
            try
            {
                return productRepository.RestoreAll();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
