﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GICDashboardMicroservices.Models;

namespace GICDashboardMicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        Models.LmsDbMyHclContext _context = new Models.LmsDbMyHclContext();


        //public ProductsController(LmsDbMyHclContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> GetProduct()
        {
            return _context.Product;
        }


        // GET: api/Products
        [HttpGet]
        public  Dashboard GetDashboard()
        {
            //int companycount = await _context.CompanyId.CountAsync();
            //var dashboard =  new Dashboard { CustomerCount =companycount, LastCustomerAdded = _context.CompanyId.Last().ContactName, LastProductAdded = _context.Product.Last().ProductName, ProductCount = _context.Product.Count(), LastUserAdded = _context.UsersInfo.Last().UserName, UserCount = _context.UsersInfo.Count() };


            return new Dashboard { CustomerCount = _context.CompanyId.Count(), LastCustomerAdded = _context.CompanyId.Last().ContactName, LastProductAdded = _context.Product.Last().ProductName, ProductCount = _context.Product.Count(), LastUserAdded = _context.UsersInfo.Last().UserName, UserCount = _context.UsersInfo.Count() };
        }


        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}