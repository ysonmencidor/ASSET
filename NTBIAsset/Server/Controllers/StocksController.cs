using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTBIAsset.Server.Data;
using NTBIAsset.Server.Helpers;
using NTBIAsset.Shared;

namespace NTBIAsset.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public StocksController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Stocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> Getstocks([FromQuery] PaginationDTO pagination,[FromQuery] string code)
        {
            var queryable = _context.stocks.AsQueryable();
            if (!string.IsNullOrEmpty(code))
            {
                queryable = queryable.Where(x => x.Fixed_Asset_Code.Contains(code));
            }
            await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.QuantityPerPage);
            return await queryable.Paginate(pagination).ToListAsync();
        }

        [Route("~/api/GetActiveStocks")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetActiveStocks()
        {
            return await _context.stocks.Where(x=>x.IsActive.Equals(true)).ToListAsync();
        }

        // GET: api/Stocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetStock(int id)
        {
            var stock = await _context.stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return stock;
        }

        [Route("~/api/ToPrintAsync")]
        [HttpGet]
        public async Task<IEnumerable<Stock>> ToPrintAsync()
        {
            return await _context.stocks.ToListAsync();
        }

        // PUT: api/Stocks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id, Stock stock)
        {
            if (id != stock.Id)
            {
                return BadRequest();
            }

            _context.Entry(stock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
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

        // POST: api/Stocks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(Stock stock)
        {
            _context.stocks.Add(stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStock", new { id = stock.Id }, stock);
        }

        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stock>> DeleteStock(int id)
        {
            var stock = await _context.stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return stock;
        }

        private bool StockExists(int id)
        {
            return _context.stocks.Any(e => e.Id == id);
        }
    }
}
