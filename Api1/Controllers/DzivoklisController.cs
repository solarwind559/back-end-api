using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api1.Models;
using AutoMapper;

namespace Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DzivoklisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DzivoklisController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Dzivoklis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dzivoklis_DTO>>> GetDzivoklisItems()
        {
            var Dzivokli = await _context.Dzivokli.ToListAsync();
            var DzivokliDTO = _mapper.Map<IEnumerable<Dzivoklis_DTO>>(Dzivokli);
            return Ok(DzivokliDTO);
        }

        // GET: api/Dzivoklis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dzivoklis_DTO>> GetDzivoklis(int id)
        {
            var Dzivoklis = await _context.Dzivokli.FindAsync(id);

            if (Dzivoklis == null)
            {
                return NotFound();
            }

            var DzivoklisDTO = _mapper.Map<Dzivoklis_DTO>(Dzivoklis);
            return Ok(DzivoklisDTO);
        }

        // PUT: api/Dzivoklis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDzivoklis(int id, Dzivoklis_DTO DzivoklisDTO)
        {
            if (id != DzivoklisDTO.Id)
            {
                return BadRequest();
            }

            var Dzivoklis = _mapper.Map<Dzivoklis>(DzivoklisDTO);
            _context.Entry(Dzivoklis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DzivoklisExists(id))
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

        // POST: api/Dzivoklis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dzivoklis_DTO>> PostDzivoklis(Dzivoklis_DTO DzivoklisDTO)
        {
            var Dzivoklis = _mapper.Map<Dzivoklis>(DzivoklisDTO);
            _context.Dzivokli.Add(Dzivoklis);
            await _context.SaveChangesAsync();

            var createdDzivoklisDTO = _mapper.Map<Dzivoklis_DTO>(Dzivoklis);
            return CreatedAtAction(nameof(GetDzivoklis), new { id = Dzivoklis.Id }, createdDzivoklisDTO);
        }

        // DELETE: api/Dzivoklis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDzivoklis(int id)
        {
            var Dzivoklis = await _context.Dzivokli.FindAsync(id);
            if (Dzivoklis == null)
            {
                return NotFound();
            }

            _context.Dzivokli.Remove(Dzivoklis);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //remove api point if issues:

        [HttpGet("{id}/Iedzivotaji")]
        public async Task<ActionResult<IEnumerable<Iedzivotajs_DTO>>> GetResidentsByApartment(int id)
        {
            try
            {
                var dzivoklis = await _context.Dzivokli
                    .Include(d => d.Iedzivotaja_Dzivokli)
                    .ThenInclude(id => id.Iedzivotajs)
                    .FirstOrDefaultAsync(d => d.Id == id);

                if (dzivoklis == null)
                {
                    return NotFound();
                }

                var residents = dzivoklis.Iedzivotaja_Dzivokli.Select(dz => dz.Iedzivotajs).ToList();
                var residentsDTO = _mapper.Map<IEnumerable<Iedzivotajs_DTO>>(residents);

                return Ok(residentsDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private bool DzivoklisExists(int id)
        {
            return _context.Dzivokli.Any(e => e.Id == id);
        }
    }
}
