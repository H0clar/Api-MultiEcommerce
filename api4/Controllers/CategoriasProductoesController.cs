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
    public class CategoriasProductoesController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public CategoriasProductoesController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/CategoriasProductoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriasProducto>>> GetCategoriasProductos()
        {
            return await _context.CategoriasProductos.ToListAsync();
        }

        // GET: api/CategoriasProductoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriasProducto>> GetCategoriasProducto(int id)
        {
            var categoriasProducto = await _context.CategoriasProductos.FindAsync(id);

            if (categoriasProducto == null)
            {
                return NotFound();
            }

            return categoriasProducto;
        }

        // PUT: api/CategoriasProductoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriasProducto(int id, CategoriasProducto categoriasProducto)
        {
            if (id != categoriasProducto.Idcategoria)
            {
                return BadRequest();
            }

            _context.Entry(categoriasProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriasProductoExists(id))
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

        // POST: api/CategoriasProductoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriasProducto>> PostCategoriasProducto(CategoriasProducto categoriasProducto)
        {
            _context.CategoriasProductos.Add(categoriasProducto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoriasProductoExists(categoriasProducto.Idcategoria))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategoriasProducto", new { id = categoriasProducto.Idcategoria }, categoriasProducto);
        }

        // DELETE: api/CategoriasProductoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriasProducto(int id)
        {
            var categoriasProducto = await _context.CategoriasProductos.FindAsync(id);
            if (categoriasProducto == null)
            {
                return NotFound();
            }

            _context.CategoriasProductos.Remove(categoriasProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriasProductoExists(int id)
        {
            return _context.CategoriasProductos.Any(e => e.Idcategoria == id);
        }
    }
}
