using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Enozom_task.Data;
using Enozom_task.Models;

namespace Enozom_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryHolidaysController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CountryHolidaysController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CountryHolidays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryHoliday>>> GetCHolidays()
        {
            return await _context.CHolidays.ToListAsync();
        }

        // GET: api/CountryHolidays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryHoliday>> GetCountryHoliday(int id)
        {
            var countryHoliday = await _context.CHolidays.FindAsync(id);

            if (countryHoliday == null)
            {
                return NotFound();
            }

            return countryHoliday;
        }

        // PUT: api/CountryHolidays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountryHoliday(int id, CountryHoliday countryHoliday)
        {
            if (id != countryHoliday.Id)
            {
                return BadRequest();
            }

            _context.Entry(countryHoliday).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryHolidayExists(id))
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

        // POST: api/CountryHolidays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryHoliday>> PostCountryHoliday(CountryHoliday countryHoliday)
        {
            _context.CHolidays.Add(countryHoliday);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountryHoliday", new { id = countryHoliday.Id }, countryHoliday);
        }

        // DELETE: api/CountryHolidays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryHoliday(int id)
        {
            var countryHoliday = await _context.CHolidays.FindAsync(id);
            if (countryHoliday == null)
            {
                return NotFound();
            }

            _context.CHolidays.Remove(countryHoliday);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryHolidayExists(int id)
        {
            return _context.CHolidays.Any(e => e.Id == id);
        }
    }
}
