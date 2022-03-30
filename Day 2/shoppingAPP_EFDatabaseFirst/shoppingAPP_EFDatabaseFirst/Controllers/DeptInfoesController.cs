using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shoppingAPP_EFDatabaseFirst.Models.EF.Shopping;

namespace shoppingAPP_EFDatabaseFirst.Controllers
{
    public class DeptInfoesController : Controller
    {
        private readonly shoppingAPPMVCContext _context = new shoppingAPPMVCContext();

        //public DeptInfoesController(shoppingAPPMVCContext context)
        //{
        //    _context = context;
        //}

        // GET: DeptInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeptInfos.ToListAsync());
        }

        // GET: DeptInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deptInfo = await _context.DeptInfos
                .FirstOrDefaultAsync(m => m.DeptNo == id);
            if (deptInfo == null)
            {
                return NotFound();
            }

            return View(deptInfo);
        }

        // GET: DeptInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeptInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeptNo,DeptName,DeptLocation,DeptHead")] DeptInfo deptInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deptInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deptInfo);
        }

        // GET: DeptInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deptInfo = await _context.DeptInfos.FindAsync(id);
            if (deptInfo == null)
            {
                return NotFound();
            }
            return View(deptInfo);
        }

        // POST: DeptInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeptNo,DeptName,DeptLocation,DeptHead")] DeptInfo deptInfo)
        {
            if (id != deptInfo.DeptNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deptInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeptInfoExists(deptInfo.DeptNo))
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
            return View(deptInfo);
        }

        // GET: DeptInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deptInfo = await _context.DeptInfos
                .FirstOrDefaultAsync(m => m.DeptNo == id);
            if (deptInfo == null)
            {
                return NotFound();
            }

            return View(deptInfo);
        }

        // POST: DeptInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deptInfo = await _context.DeptInfos.FindAsync(id);
            _context.DeptInfos.Remove(deptInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeptInfoExists(int id)
        {
            return _context.DeptInfos.Any(e => e.DeptNo == id);
        }
    }
}
