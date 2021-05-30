using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using ShopBridge.Dtos;
using ShopBridge.Models;

namespace ShopBridge.Controllers
{
    public class ProductsController : ApiController
    {
        private ShopBridgeDbContext _context;

        public ProductsController()
        {
            _context = new ShopBridgeDbContext();
        }


        /// <summary>
        /// Get the list of products present in the database
        /// </summary>
        /// <returns></returns>
        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            //Returns the list of products
            return _context.Products.ToList();
        }


        /// <summary>
        /// Get the details info about the perticular product 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Products/5
        [HttpGet]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            //Find the product in database using id.
            Product product = _context.Products.SingleOrDefault(p => p.Id == id);

            //If product not found with given id then return NotFound response.
            if (product == null)
            {
                return NotFound();
            }

            //If product found with given id then returns returns OK response with Product info.
            return Ok(product);
        }


        /// <summary>
        /// Add New Product
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        // POST: api/Products
        [HttpPost]
        [ResponseType(typeof(Product))]
        public IHttpActionResult AddProduct(ProductDto newProduct)
        {
            //Check the modelstate is valid or not, If not return Response as BadRequest.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Take the ProductDto and Map to Product Model.
            var product = Mapper.Map<ProductDto, Product>(newProduct);
            product.CreatedOn = product.LastModifiedOn = DateTime.Now;
            product.Image = (newProduct.ImageContent != null && newProduct.ImageContent.Length > 0) ? Convert.FromBase64String(newProduct.ImageContent) : null;

            //Product added to the database.
            _context.Products.Add(product);
            _context.SaveChanges();

            //After new product added to the database return with created response and the created product JSON.
            return Created("SB_ProductApi", product);
        }


        /// <summary>
        /// Update product based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedProduct"></param>
        /// <returns></returns>
        // PUT: api/Products/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateProduct(int id, ProductDto updatedProduct)
        {
            //Check the modelstate is valid or not, If not return Response as BadRequest.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Find the product in database using id.
            var productInDb = _context.Products.SingleOrDefault(p => p.Id == id);

            //If product not found with given id then return NotFound response.
            if (productInDb == null)
            {
                return NotFound();
            }

            //Take the ProductDto with updated info and Map to Product Model.
            Mapper.Map(updatedProduct, productInDb);
            productInDb.LastModifiedOn = DateTime.Now;
            productInDb.Image = (updatedProduct.ImageContent != null && updatedProduct.ImageContent.Length > 0) ? Convert.FromBase64String(updatedProduct.ImageContent) : null;

            //Update product in the database.
            _context.SaveChanges();

            //After product updated successfully to the database returns NoContent response.
            return StatusCode(HttpStatusCode.NoContent);
        }


        /// <summary>
        /// Delete a specific product based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Products/5
        [HttpDelete]
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            //Find the product in database using id.
            var productInDb = _context.Products.SingleOrDefault(p => p.Id == id);

            //If product not found with given id then return NotFound response.
            if (productInDb == null)
            {
                return NotFound();
            }

            //Remove product from the database.
            _context.Products.Remove(productInDb);
            _context.SaveChanges();

            //After product removed from the database returns OK response and the deleted product JSON.
            return Ok(productInDb);
        }

    }
}