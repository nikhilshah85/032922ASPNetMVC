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
    public class EmployeeInfoesController : Controller
    {
        private readonly shoppingAPPMVCContext _context = new shoppingAPPMVCContext();

        //public EmployeeInfoesController(shoppingAPPMVCContext context)
        //{
        //    _context = context;
        //}

        // GET: EmployeeInfoes
        public async Task<IActionResult> Index()
        {
            var shoppingAPPMVCContext = _context.EmployeeInfos.Include(e => e.EmpDeptNavigation);
            return View(await shoppingAPPMVCContext.ToListAsync());
        }

        // GET: EmployeeInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeInfo = await _context.EmployeeInfos
                .Include(e => e.EmpDeptNavigation)
                .FirstOrDefaultAsync(m => m.EmpNo == id);
            if (employeeInfo == null)
            {
                return NotFound();
            }

            return View(employeeInfo);
        }

        // GET: EmployeeInfoes/Create
        public IActionResult Create()
        {
            ViewData["EmpDept"] = new SelectList(_context.DeptInfos, "DeptNo", "DeptNo");
            return View();
        }

        // POST: EmployeeInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpNo,EmpName,EmpDesignation,EmpSalary,EmpDept")] EmployeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpDept"] = new SelectList(_context.DeptInfos, "DeptNo", "DeptNo", employeeInfo.EmpDept);
            return View(employeeInfo);
        }

        // GET: EmployeeInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeInfo = await _context.EmployeeInfos.FindAsync(id);
            if (employeeInfo == null)
            {
                return NotFound();
            }
            ViewData["EmpDept"] = new SelectList(_context.DeptInfos, "DeptNo", "DeptNo", employeeInfo.EmpDept);
            return View(employeeInfo);
        }

        // POST: EmployeeInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpNo,EmpName,EmpDesignation,EmpSalary,EmpDept")] EmployeeInfo employeeInfo)
        {
            if (id != employeeInfo.EmpNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeInfoExists(employeeInfo.EmpNo))
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
            ViewData["EmpDept"] = new SelectList(_context.DeptInfos, "DeptNo", "DeptNo", employeeInfo.EmpDept);
            return View(employeeInfo);
        }

        // GET: EmployeeInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeInfo = await _context.EmployeeInfos
                .Include(e => e.EmpDeptNavigation)
                .FirstOrDefaultAsync(m => m.EmpNo == id);
            if (employeeInfo == null)
            {
                return NotFound();
            }

            return View(employeeInfo);
        }

        // POST: EmployeeInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeInfo = await _context.EmployeeInfos.FindAsync(id);
            _context.EmployeeInfos.Remove(employeeInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeInfoExists(int id)
        {
            return _context.EmployeeInfos.Any(e => e.EmpNo == id);
        }
    }
}
