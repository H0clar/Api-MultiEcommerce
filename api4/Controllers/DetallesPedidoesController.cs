﻿using System;
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
    public class DetallesPedidoesController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public DetallesPedidoesController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/DetallesPedidoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallesPedido>>> GetDetallesPedidos()
        {
            return await _context.DetallesPedidos.ToListAsync();
        }

        // GET: api/DetallesPedidoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallesPedido>> GetDetallesPedido(int id)
        {
            var detallesPedido = await _context.DetallesPedidos.FindAsync(id);

            if (detallesPedido == null)
            {
                return NotFound();
            }

            return detallesPedido;
        }

        // PUT: api/DetallesPedidoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallesPedido(int id, DetallesPedido detallesPedido)
        {
            if (id != detallesPedido.IddetallePedido)
            {
                return BadRequest();
            }

            _context.Entry(detallesPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesPedidoExists(id))
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

        // POST: api/DetallesPedidoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallesPedido>> PostDetallesPedido(DetallesPedido detallesPedido)
        {
            _context.DetallesPedidos.Add(detallesPedido);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DetallesPedidoExists(detallesPedido.IddetallePedido))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDetallesPedido", new { id = detallesPedido.IddetallePedido }, detallesPedido);
        }

        // DELETE: api/DetallesPedidoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallesPedido(int id)
        {
            var detallesPedido = await _context.DetallesPedidos.FindAsync(id);
            if (detallesPedido == null)
            {
                return NotFound();
            }

            _context.DetallesPedidos.Remove(detallesPedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallesPedidoExists(int id)
        {
            return _context.DetallesPedidos.Any(e => e.IddetallePedido == id);
        }
    }
}
