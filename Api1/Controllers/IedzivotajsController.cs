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
    public class IedzivotajsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

public IedzivotajsController(ApplicationDbContext context, IMapper mapper)
{
    _context = context;
    _mapper = mapper;
}

        // GET: api/Iedzivotajs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Iedzivotajs_DTO>>> GetIedzivotajsItems()
        {
            var Iedzivotaji = await _context.Iedzivotaji.ToListAsync();
            var IedzivotajiDTO = _mapper.Map<IEnumerable<Iedzivotajs_DTO>>(Iedzivotaji);
            return Ok(IedzivotajiDTO);
        }

        // GET: api/Iedzivotajs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Iedzivotajs_DTO>> GetIedzivotajs(int id)
        {
            var Iedzivotajs = await _context.Iedzivotaji.FindAsync(id);

            if (Iedzivotajs == null)
            {
                return NotFound();
            }

            var IedzivotajsDTO = _mapper.Map<Iedzivotajs_DTO>(Iedzivotajs);
            return Ok(IedzivotajsDTO);
        }

        // PUT: api/Iedzivotajs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIedzivotajs(int id, Iedzivotajs_DTO IedzivotajsDTO)
        {
            if (id != IedzivotajsDTO.Id)
            {
                return BadRequest();
            }

            var Iedzivotajs = _mapper.Map<Iedzivotajs>(IedzivotajsDTO);
            _context.Entry(Iedzivotajs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IedzivotajsExists(id))
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

        // POST: api/Iedzivotajs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Iedzivotajs_DTO>> PostIedzivotajs(Iedzivotajs_DTO IedzivotajsDTO)
        {
            var Iedzivotajs = _mapper.Map<Iedzivotajs>(IedzivotajsDTO);
            _context.Iedzivotaji.Add(Iedzivotajs);
            await _context.SaveChangesAsync();

            var createdIedzivotajsDTO = _mapper.Map<Iedzivotajs_DTO>(Iedzivotajs);
            return CreatedAtAction(nameof(GetIedzivotajs), new { id = Iedzivotajs.Id }, createdIedzivotajsDTO);
        }

        // DELETE: api/Iedzivotajs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIedzivotajs(int id)
        {
            var Iedzivotajs = await _context.Iedzivotaji.FindAsync(id);
            if (Iedzivotajs == null)
            {
                return NotFound();
            }

            _context.Iedzivotaji.Remove(Iedzivotajs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IedzivotajsExists(int id)
        {
            return _context.Iedzivotaji.Any(e => e.Id == id);
        }
    }
}
