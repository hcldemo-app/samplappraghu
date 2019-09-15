using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GICDashboardMicroservices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GICDashboardMicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardsController : ControllerBase
    {

        Models.LmsDbMyHclContext _context = new Models.LmsDbMyHclContext();


        //public ProductsController(LmsDbMyHclContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Products
        //[HttpGet]
        //public IEnumerable<Product> GetProduct()
        //{
        //    return _context.Product;
        //}


        // GET: api/Products
        [HttpGet]
        public Dashboard GetDashboard()
        {
            //int companycount = await _context.CompanyId.CountAsync();
            //var dashboard =  new Dashboard { CustomerCount =companycount, LastCustomerAdded = _context.CompanyId.Last().ContactName, LastProductAdded = _context.Product.Last().ProductName, ProductCount = _context.Product.Count(), LastUserAdded = _context.UsersInfo.Last().UserName, UserCount = _context.UsersInfo.Count() };


            return new Dashboard { CustomerCount = _context.CompanyId.Count(), LastCustomerAdded = _context.CompanyId.Last().ContactName, LastProductAdded = _context.Product.Last().ProductName, ProductCount = _context.Product.Count(), LastUserAdded = _context.UsersInfo.Last().UserName, UserCount = _context.UsersInfo.Count() };
        }
    }
}