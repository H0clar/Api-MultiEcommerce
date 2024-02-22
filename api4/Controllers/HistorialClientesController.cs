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
    public class HistorialClientesController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public HistorialClientesController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/HistorialClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialCliente>>> GetHistorialClientes()
        {
            return await _context.HistorialClientes.ToListAsync();
        }

        // GET: api/HistorialClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialCliente>> GetHistorialCliente(int id)
        {
            var historialCliente = await _context.HistorialClientes.FindAsync(id);

            if (historialCliente == null)
            {
                return NotFound();
            }

            return historialCliente;
        }

        // PUT: api/HistorialClientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialCliente(int id, HistorialCliente historialCliente)
        {
            if (id != historialCliente.Idhistorial)
            {
                return BadRequest();
            }

            _context.Entry(historialCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialClienteExists(id))
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

        // POST: api/HistorialClientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistorialCliente>> PostHistorialCliente(HistorialCliente historialCliente)
        {
            _context.HistorialClientes.Add(historialCliente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HistorialClienteExists(historialCliente.Idhistorial))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHistorialCliente", new { id = historialCliente.Idhistorial }, historialCliente);
        }

        // DELETE: api/HistorialClientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialCliente(int id)
        {
            var historialCliente = await _context.HistorialClientes.FindAsync(id);
            if (historialCliente == null)
            {
                return NotFound();
            }

            _context.HistorialClientes.Remove(historialCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialClienteExists(int id)
        {
            return _context.HistorialClientes.Any(e => e.Idhistorial == id);
        }
    }
}
