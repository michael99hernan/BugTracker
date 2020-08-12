using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tracker.Data;
using Tracker.Models;
using Tracker.ViewModels;

namespace BugTracker.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ticket.Include(t => t.Project).Include(t => t.Status).Include(t => t.UserCreated);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> MyTickets()
        {
            var applicationDbContext = _context.Ticket.Include(t => t.Project).Include(t => t.Status).Include(t => t.UserCreated).Where(u => u.TrackerUserId == User.Identity.GetUserId());
            return View(await applicationDbContext.ToListAsync());
        }
        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var vm = new TicketDetailViewModel();
            vm.His = await _context.TicketHistories.ToListAsync();
            //vm.currComment.TrackerUserId = User.Identity.GetUserId();

            if (id == null)
            {
                return NotFound();
            }
            vm.Com = await _context.Comments.Where(p => p.TicketId == id).Include(p => p.Owner).ToListAsync();
            vm.Tic = await _context.Ticket
                .Include(t => t.Project)
                .Include(t => t.Status)
                .Include(t => t.UserCreated)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vm == null)
            {
                return NotFound();
            }
            //vm.currComment.TicketId = vm.Tic.Id;
            ViewData["TrackerUserId"] = new SelectList(_context.Set<TrackerUser>(), "Id", "Id");
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id");
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Details(TicketDetailViewModel vm)
        {
            //  comment.TicketId = id;
            vm.currComment.TrackerUserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                _context.Add(vm.currComment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Tickets", vm.currComment.TicketId.ToString());
            }
            ViewData["TrackerUserId"] = new SelectList(_context.Set<TrackerUser>(), "Id", "Id");
            ViewData["TicketId"] = new SelectList(_context.Ticket, "Id", "Id");
            return RedirectToAction("Details", "Tickets", vm.currComment.TicketId.ToString());
        }
        // GET: Tickets/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Title");
            ViewData["StatusUpdatesId"] = new SelectList(_context.Set<StatusUpdates>(), "Id", "Desc");
            ViewData["TrackerUserId"] = new SelectList(_context.Set<TrackerUser>(), "Id", "Email");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ProjectId,Description")] Ticket ticket)
        {
            ticket.DateCreated = DateTime.Now;
            ticket.StatusUpdatesId = 2;
            ticket.TrackerUserId = User.Identity.GetUserId();


            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Project"] = new SelectList(_context.Projects, "Id", "Title", ticket.ProjectId);
            ViewData["StatusUpdatesId"] = new SelectList(_context.Set<StatusUpdates>(), "Id", "Id", ticket.StatusUpdatesId);
            ViewData["User"] = new SelectList(_context.Set<TrackerUser>(), "Id", "Id", ticket.TrackerUserId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Title", ticket.ProjectId);
            ViewData["StatusUpdatesId"] = new SelectList(_context.Set<StatusUpdates>(), "Id", "Desc", ticket.StatusUpdatesId);
            ViewData["TrackerUserId"] = new SelectList(_context.Set<TrackerUser>(), "Id", "Email", ticket.TrackerUserId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,DateCreated,TrackerUserId,StatusUpdatesId,ProjectId,Description")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Title", ticket.ProjectId);
            ViewData["StatusUpdatesId"] = new SelectList(_context.Set<StatusUpdates>(), "Id", "Desc", ticket.StatusUpdatesId);
            ViewData["TrackerUserId"] = new SelectList(_context.Set<TrackerUser>(), "Id", "Id", ticket.TrackerUserId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        [Authorize(Roles="Admin,Project Lead, Developer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.Project)
                .Include(t => t.Status)
                .Include(t => t.UserCreated)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
