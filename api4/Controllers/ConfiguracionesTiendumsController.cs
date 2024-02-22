using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api4.Models;

namespace api4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionesTiendumsController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public ConfiguracionesTiendumsController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/ConfiguracionesTiendums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfiguracionesTiendum>>> GetConfiguracionesTienda()
        {
            return await _context.ConfiguracionesTienda.ToListAsync();
        }

        // GET: api/ConfiguracionesTiendums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfiguracionesTiendum>> GetConfiguracionesTiendum(int id)
        {
            var configuracionesTiendum = await _context.ConfiguracionesTienda.FindAsync(id);

            if (configuracionesTiendum == null)
            {
                return NotFound();
            }

            return configuracionesTiendum;
        }

        // PUT: api/ConfiguracionesTiendums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfiguracionesTiendum(int id, ConfiguracionesTiendum configuracionesTiendum)
        {
            if (id != configuracionesTiendum.Idconfiguracion)
            {
                return BadRequest();
            }

            _context.Entry(configuracionesTiendum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfiguracionesTiendumExists(id))
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

        // POST: api/ConfiguracionesTiendums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConfiguracionesTiendum>> PostConfiguracionesTiendum(ConfiguracionesTiendum configuracionesTiendum)
        {
            _context.ConfiguracionesTienda.Add(configuracionesTiendum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConfiguracionesTiendumExists(configuracionesTiendum.Idconfiguracion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConfiguracionesTiendum", new { id = configuracionesTiendum.Idconfiguracion }, configuracionesTiendum);
        }

        // DELETE: api/ConfiguracionesTiendums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfiguracionesTiendum(int id)
        {
            var configuracionesTiendum = await _context.ConfiguracionesTienda.FindAsync(id);
            if (configuracionesTiendum == null)
            {
                return NotFound();
            }

            _context.ConfiguracionesTienda.Remove(configuracionesTiendum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfiguracionesTiendumExists(int id)
        {
            return _context.ConfiguracionesTienda.Any(e => e.Idconfiguracion == id);
        }
    }
}
