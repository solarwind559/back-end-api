using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api1.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MajaController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Maja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maja_DTO>>> GetMajaItems()
        {
            var Majas = await _context.Majas.ToListAsync();

            var MajasDTO = _mapper.Map<IEnumerable<Maja_DTO>>(Majas);
            return Ok(MajasDTO);
        }

        // GET: api/Maja/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Maja_DTO>> GetMaja(int? id)
        {
            var Maja = await _context.Majas.FindAsync(id);

            if (Maja == null)
            {
                return NotFound();
            }

            var MajaDTO = _mapper.Map<Maja_DTO>(Maja);
            return Ok(MajaDTO);
        }

        // New endpoint to fetch apartments related to a house
        // GET: api/Maja/5/Dzivokli
        [HttpGet("{id}/Dzivokli")]
        public async Task<ActionResult<IEnumerable<Dzivoklis_DTO>>> GetDzivokliByMaja(int? id)
        {
            var dzivokli = await _context.Majas
                .Where(m => m.Id == id)
                .SelectMany(m => m.Majas_Dzivokli)
                .Select(md => md.Dzivoklis)
                .ToListAsync();

            if (dzivokli == null || !dzivokli.Any())
            {
                return NotFound();
            }

            var dzivokliDTO = _mapper.Map<IEnumerable<Dzivoklis_DTO>>(dzivokli);
            return Ok(dzivokliDTO);
        }

        // PUT: api/Maja/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaja(int? id, Maja_DTO MajaDTO)
        {
            if (id != MajaDTO.Id)
            {
                return BadRequest();
            }

            var Maja = _mapper.Map<Maja>(MajaDTO);
            _context.Entry(Maja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MajaExists(id))
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

        // POST: api/Maja
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Maja_DTO>> PostMaja(Maja_DTO MajaDTO)
        {
            var Maja = _mapper.Map<Maja>(MajaDTO);
            _context.Majas.Add(Maja);
            await _context.SaveChangesAsync();

            var createdMajaDTO = _mapper.Map<Maja_DTO>(Maja);
            return CreatedAtAction(nameof(GetMaja), new { id = Maja.Id }, createdMajaDTO);
        }

        // DELETE: api/Maja/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaja(int? id)
        {
            var Maja = await _context.Majas.FindAsync(id);
            if (Maja == null)
            {
                return NotFound();
            }

            _context.Majas.Remove(Maja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MajaExists(int? id)
        {
            return _context.Majas.Any(e => e.Id == id);
        }
    }
}
