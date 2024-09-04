using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI_Marjorie_Falcone__20240904.Data;
using WebAPI_Marjorie_Falcone__20240904.Model;

namespace WebAPI_Marjorie_Falcone__20240904.Controllers
{
    public class FollowersController : Controller
    {
        private readonly WebAPI_Marjorie_Falcone__20240904Context _context;

        public FollowersController(WebAPI_Marjorie_Falcone__20240904Context context)
        {
            _context = context;
        }

        // GET: Followers
        public async Task<IActionResult> Index()
        {
            var webAPI_Marjorie_Falcone__20240904Context = _context.Follower.Include(f => f.User);
            return View(await webAPI_Marjorie_Falcone__20240904Context.ToListAsync());
        }

        // GET: Followers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Follower == null)
            {
                return NotFound();
            }

            var follower = await _context.Follower
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FollowerId == id);
            if (follower == null)
            {
                return NotFound();
            }

            return View(follower);
        }

        // GET: Followers/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
            return View();
        }

        // POST: Followers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FollowerId,UserId")] Follower follower)
        {
            if (ModelState.IsValid)
            {
                _context.Add(follower);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", follower.UserId);
            return View(follower);
        }

        // GET: Followers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Follower == null)
            {
                return NotFound();
            }

            var follower = await _context.Follower.FindAsync(id);
            if (follower == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", follower.UserId);
            return View(follower);
        }

        // POST: Followers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FollowerId,UserId")] Follower follower)
        {
            if (id != follower.FollowerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(follower);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FollowerExists(follower.FollowerId))
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
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", follower.UserId);
            return View(follower);
        }

        // GET: Followers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Follower == null)
            {
                return NotFound();
            }

            var follower = await _context.Follower
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FollowerId == id);
            if (follower == null)
            {
                return NotFound();
            }

            return View(follower);
        }

        // POST: Followers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Follower == null)
            {
                return Problem("Entity set 'WebAPI_Marjorie_Falcone__20240904Context.Follower'  is null.");
            }
            var follower = await _context.Follower.FindAsync(id);
            if (follower != null)
            {
                _context.Follower.Remove(follower);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FollowerExists(int id)
        {
          return (_context.Follower?.Any(e => e.FollowerId == id)).GetValueOrDefault();
        }
    }
}
