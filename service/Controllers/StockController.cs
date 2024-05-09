using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using service.Data;

namespace service.Controllers
{
    [Route("service/stock")]
    [ApiController]
    public class StockController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<StockController> _logger;

        public StockController(ApplicationDbContext context, ILogger<StockController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks.ToList();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stocks = _context.Stocks.Find(id);
            if (stocks == null) 
            {
                return NotFound();
            }
            return Ok(stocks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}