using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    { 
        private readonly dbAdvertiseFaresContext _context;

        public CurrenciesController(dbAdvertiseFaresContext context)
        {
            _context = context;
        }

        // GET: api/Currencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCurrency>>> GetTblCurrency()
        {
            return await _context.TblCurrency.ToListAsync();
        }

        // GET: api/Currencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCurrency>> GetTblCurrency(int id)
        {
            var tblCurrency = await _context.TblCurrency.FindAsync(id);

            if (tblCurrency == null)
            {
                return NotFound();
            }

            return tblCurrency;
        }

        // PUT: api/Currencies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCurrency(int id, TblCurrency tblCurrency)
        {
            if (id != tblCurrency.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCurrency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCurrencyExists(id))
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

        // POST: api/Currencies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblCurrency>> PostTblCurrency(TblCurrency tblCurrency)
        {
            _context.TblCurrency.Add(tblCurrency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCurrency", new { id = tblCurrency.Id }, tblCurrency);
        }

        // DELETE: api/Currencies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblCurrency>> DeleteTblCurrency(int id)
        {
            var tblCurrency = await _context.TblCurrency.FindAsync(id);
            if (tblCurrency == null)
            {
                return NotFound();
            }

            _context.TblCurrency.Remove(tblCurrency);
            await _context.SaveChangesAsync();

            return tblCurrency;
        }

        private bool TblCurrencyExists(int id)
        {
            return _context.TblCurrency.Any(e => e.Id == id);
        }
    }
}
