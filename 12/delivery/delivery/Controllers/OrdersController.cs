using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using delivery.Models;

namespace delivery.Controllers
{
    public class OrdersController : Controller
    {
        private readonly MyDbContext _context;

        public OrdersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Orders.Include(o => o.ClientNavigation).Include(o => o.EmployeeNavigation).Include(o => o.StatusNavigation);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.ClientNavigation)
                .Include(o => o.EmployeeNavigation)
                .Include(o => o.StatusNavigation)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["Client"] = new SelectList(_context.Clients, "ClientId", "ClientId");
            ViewData["Employee"] = new SelectList(_context.Employees, "EmployeesId", "EmployeesId");
            ViewData["Status"] = new SelectList(_context.OrderStatuses, "OrderStatusId", "OrderStatusId");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,Employee,Client,Status,Address,Cost")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Client"] = new SelectList(_context.Clients, "ClientId", "ClientId", order.Client);
            ViewData["Employee"] = new SelectList(_context.Employees, "EmployeesId", "EmployeesId", order.Employee);
            ViewData["Status"] = new SelectList(_context.OrderStatuses, "OrderStatusId", "OrderStatusId", order.Status);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["Client"] = new SelectList(_context.Clients, "ClientId", "ClientId", order.Client);
            ViewData["Employee"] = new SelectList(_context.Employees, "EmployeesId", "EmployeesId", order.Employee);
            ViewData["Status"] = new SelectList(_context.OrderStatuses, "OrderStatusId", "OrderStatusId", order.Status);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,Employee,Client,Status,Address,Cost")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Client"] = new SelectList(_context.Clients, "ClientId", "ClientId", order.Client);
            ViewData["Employee"] = new SelectList(_context.Employees, "EmployeesId", "EmployeesId", order.Employee);
            ViewData["Status"] = new SelectList(_context.OrderStatuses, "OrderStatusId", "OrderStatusId", order.Status);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.ClientNavigation)
                .Include(o => o.EmployeeNavigation)
                .Include(o => o.StatusNavigation)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
