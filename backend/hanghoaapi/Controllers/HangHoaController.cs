using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hanghoaapi.Models;
using Microsoft.Data.SqlClient;

namespace hanghoaapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly HangHoaContext _context;

        public HangHoaController(HangHoaContext context)
        {
            _context = context;
        }

        // GET: api/HangHoa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HangHoa>>> GetHangHoas()
        {
            try
            {
                return await _context.HangHoas.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/HangHoa/5
        [HttpGet("{ma_hanghoa}")]
        public async Task<ActionResult<HangHoa>> GetHangHoa(string ma_hanghoa)
        {
            try
            {
                var hangHoa = await _context.HangHoas.FindAsync(ma_hanghoa);

                if (hangHoa == null)
                {
                    return NotFound();
                }

                return hangHoa;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/HangHoa/5
        [HttpPut("{ma_hanghoa}")]
        public async Task<IActionResult> PutHangHoa(string ma_hanghoa, HangHoa hangHoa)
        {
            hangHoa.ma_hanghoa = ma_hanghoa;
            _context.Entry(hangHoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HangHoaExists(ma_hanghoa))
                {
                    return NotFound();
                }
                else
                {
                    return Conflict("A concurrency issue occurred.");
                }
            }
            catch (DbUpdateException ex)
            {
                Console.Error.WriteLine(ex);

                return BadRequest("A database error occurred.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);

                return StatusCode(500, "Internal server error");
            }

            return NoContent();
        }

        // POST: api/HangHoa
        [HttpPost]
        public async Task<ActionResult<HangHoa>> PostHangHoa(HangHoa hangHoa)
        {
            try
            {
                _context.HangHoas.Add(hangHoa);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetHangHoa", new { ma_hanghoa = hangHoa.ma_hanghoa }, hangHoa);
            }
            catch (DbUpdateException ex)
            {
                Console.Error.WriteLine(ex);

                if (ex.InnerException is SqlException sqlException && sqlException.Number == 2627)
                {
                    return Conflict("A record with this ID already exists.");
                }

                return BadRequest("An error occurred while saving the HangHoa.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);

                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/HangHoa/5
        [HttpDelete("{ma_hanghoa}")]
        public async Task<IActionResult> DeleteHangHoa(string ma_hanghoa)
        {
            try
            {
                var hangHoa = await _context.HangHoas.FindAsync(ma_hanghoa);
                if (hangHoa == null)
                {
                    return NotFound();
                }
                _context.HangHoas.Remove(hangHoa);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                Console.Error.WriteLine(ex);
                return BadRequest("An error occurred while deleting the HangHoa.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);

                return StatusCode(500, "Internal server error");
            }
        }

        private bool HangHoaExists(string ma_hanghoa)
        {
            return _context.HangHoas.Any(e => e.ma_hanghoa == ma_hanghoa);
        }
    }
}
