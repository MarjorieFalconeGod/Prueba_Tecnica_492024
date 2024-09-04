using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPP_Marjorie_Falcone_20240904.Data;
using WebAPP_Marjorie_Falcone_20240904.Models;

namespace WebAPP_Marjorie_Falcone_20240904.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly WebAPP_Marjorie_Falcone_20240904Context _context;

        public NotificationsController(WebAPP_Marjorie_Falcone_20240904Context context)
        {
            _context = context;
        }

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            var webAPP_Marjorie_Falcone_20240904Context = _context.Notification.Include(n => n.RelatedComment).Include(n => n.RelatedPost).Include(n => n.User);
            return View(await webAPP_Marjorie_Falcone_20240904Context.ToListAsync());
        }

        // GET: Notifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notification == null)
            {
                return NotFound();
            }

            var notification = await _context.Notification
                .Include(n => n.RelatedComment)
                .Include(n => n.RelatedPost)
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NotificationId == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // GET: Notifications/Create
        public IActionResult Create()
        {
            ViewData["RelatedCommentId"] = new SelectList(_context.Set<Comment>(), "CommentId", "CommentId");
            ViewData["RelatedPostId"] = new SelectList(_context.Post, "PostId", "PostId");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
            return View();
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NotificationId,Text,DateSent,UserId,RelatedPostId,RelatedCommentId")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RelatedCommentId"] = new SelectList(_context.Set<Comment>(), "CommentId", "CommentId", notification.RelatedCommentId);
            ViewData["RelatedPostId"] = new SelectList(_context.Post, "PostId", "PostId", notification.RelatedPostId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", notification.UserId);
            return View(notification);
        }

        // GET: Notifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notification == null)
            {
                return NotFound();
            }

            var notification = await _context.Notification.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            ViewData["RelatedCommentId"] = new SelectList(_context.Set<Comment>(), "CommentId", "CommentId", notification.RelatedCommentId);
            ViewData["RelatedPostId"] = new SelectList(_context.Post, "PostId", "PostId", notification.RelatedPostId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", notification.UserId);
            return View(notification);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NotificationId,Text,DateSent,UserId,RelatedPostId,RelatedCommentId")] Notification notification)
        {
            if (id != notification.NotificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationExists(notification.NotificationId))
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
            ViewData["RelatedCommentId"] = new SelectList(_context.Set<Comment>(), "CommentId", "CommentId", notification.RelatedCommentId);
            ViewData["RelatedPostId"] = new SelectList(_context.Post, "PostId", "PostId", notification.RelatedPostId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", notification.UserId);
            return View(notification);
        }

        // GET: Notifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notification == null)
            {
                return NotFound();
            }

            var notification = await _context.Notification
                .Include(n => n.RelatedComment)
                .Include(n => n.RelatedPost)
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NotificationId == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notification == null)
            {
                return Problem("Entity set 'WebAPP_Marjorie_Falcone_20240904Context.Notification'  is null.");
            }
            var notification = await _context.Notification.FindAsync(id);
            if (notification != null)
            {
                _context.Notification.Remove(notification);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationExists(int id)
        {
          return (_context.Notification?.Any(e => e.NotificationId == id)).GetValueOrDefault();
        }
    }
}
