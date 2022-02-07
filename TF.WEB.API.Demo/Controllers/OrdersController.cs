using GestionStockCore.DAL;
using GestionStockCore.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TF.WEB.API.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly StockContext _context;

        public OrdersController(StockContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrder()
        {
            return await _context.Orders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOne(string id)
        {
            try
            {
                Order order = await _context.Orders.FindAsync(id);
                if (order is null) return NotFound();
                return order;
            }
            catch (BadHttpRequestException e)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if (_context.Orders.Any(o => o.Reference == order.Reference)) return Conflict();
                throw e;
            }
            return CreatedAtAction("GetOne", new { id = order.Reference }, new { result = order });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(string id, Order order)
        {
            if (id != order.Reference) return BadRequest();

            _context.Entry(order).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!_context.Orders.Any(o => o.Reference == order.Reference)) return Conflict();
                throw e;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelOrder(string id)
        {
            Order order = await _context.Orders.FindAsync(id);
            if (order is null) return NotFound();
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
