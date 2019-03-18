using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCore.Models;

namespace EFCore.Controllers
{
    public class SubscriptionsAliasController : Controller
    {
        private readonly SubscriptionsAliasContext _context;

        public SubscriptionsAliasController(SubscriptionsAliasContext context)
        {
            _context = context;
        }

        // GET: SubscriptionsAlias
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubscriptionsAlias.ToListAsync());
        }

        // GET: SubscriptionsAlias/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var subscriptionsAlias = await _context.SubscriptionsAlias
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (subscriptionsAlias == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(subscriptionsAlias);
        //}

        public async Task<IActionResult> Details(string id)
        {
            var subscriptionsAlias = await _context.SubscriptionsAlias
                .FirstOrDefaultAsync(m => m.SubscriptionId.Equals(id));
            if (subscriptionsAlias == null)
            {
                return NotFound();
            }

            return View(subscriptionsAlias);
        }

        // GET: SubscriptionsAlias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubscriptionsAlias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubscriptionId,Name,Alias,Username")] SubscriptionsAlias subscriptionsAlias)
        {
            if (ModelState.IsValid)
            {
                subscriptionsAlias.CreatedDate = DateTime.Now;
                _context.Add(subscriptionsAlias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subscriptionsAlias);
        }

        // GET: SubscriptionsAlias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptionsAlias = await _context.SubscriptionsAlias.FindAsync(id);
            if (subscriptionsAlias == null)
            {
                return NotFound();
            }
            return View(subscriptionsAlias);
        }

        // POST: SubscriptionsAlias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubscriptionId,Name,Alias,Username")] SubscriptionsAlias subscriptionsAlias)
        {
            if (id != subscriptionsAlias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscriptionsAlias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriptionsAliasExists(subscriptionsAlias.Id))
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
            return View(subscriptionsAlias);
        }

        // GET: SubscriptionsAlias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptionsAlias = await _context.SubscriptionsAlias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscriptionsAlias == null)
            {
                return NotFound();
            }

            return View(subscriptionsAlias);
        }

        // POST: SubscriptionsAlias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscriptionsAlias = await _context.SubscriptionsAlias.FindAsync(id);
            _context.SubscriptionsAlias.Remove(subscriptionsAlias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriptionsAliasExists(int id)
        {
            return _context.SubscriptionsAlias.Any(e => e.Id == id);
        }
    }
}
