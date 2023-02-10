using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FileMonitor.DataDB;

namespace FileMonitor.Controllers
{
    public class ServicePathToMonitorsController : Controller
    {
        private readonly RlvFileActivityMonitorContext _context;

        public ServicePathToMonitorsController(RlvFileActivityMonitorContext context)
        {
            _context = context;
        }

        // GET: ServicePathToMonitors
        public async Task<IActionResult> Index()
        {
              return View(await _context.ServicePathToMonitors.ToListAsync());
        }

        // GET: ServicePathToMonitors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServicePathToMonitors == null)
            {
                return NotFound();
            }

            var servicePathToMonitor = await _context.ServicePathToMonitors
                .FirstOrDefaultAsync(m => m.ServicePathSysId == id);
            if (servicePathToMonitor == null)
            {
                return NotFound();
            }

            return View(servicePathToMonitor);
        }


        /**********************
       // GET: ServicePathToMonitors/Create
       public IActionResult Create()
       {
           return View();
       }



       // POST: ServicePathToMonitors/Create
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Create([Bind("ServicePathSysId,PathToMonitor,ServiceSysId,LastChangeDateTime,CreateDate,TimeCheckInterval,Status,Active,FileNamePattern,NumberOfFilesForToday,LastFileReceived,NumberOfFilesForYesterday")] ServicePathToMonitor servicePathToMonitor)
       {
           if (ModelState.IsValid)
           {
               _context.Add(servicePathToMonitor);
               await _context.SaveChangesAsync();
               return RedirectToAction(nameof(Monitor));
           }
           return View(servicePathToMonitor);
       }
       ************************/

        // GET: ServicePathToMonitors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServicePathToMonitors == null)
            {
                return NotFound();
            }

            var servicePathToMonitor = await _context.ServicePathToMonitors.FindAsync(id);
            if (servicePathToMonitor == null)
            {
                return NotFound();
            }
            return View(servicePathToMonitor);
        }

        // POST: ServicePathToMonitors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServicePathSysId,PathToMonitor,ServiceSysId,LastChangeDateTime,CreateDate,TimeCheckInterval,Status,Active,FileNamePattern,NumberOfFilesForToday,LastFileReceived,NumberOfFilesForYesterday")] ServicePathToMonitor servicePathToMonitor)
        {
            if (id != servicePathToMonitor.ServicePathSysId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicePathToMonitor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicePathToMonitorExists(servicePathToMonitor.ServicePathSysId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Monitor));
            }
            return View(servicePathToMonitor);
        }

        // GET: ServicePathToMonitors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServicePathToMonitors == null)
            {
                return NotFound();
            }

            var servicePathToMonitor = await _context.ServicePathToMonitors
                .FirstOrDefaultAsync(m => m.ServicePathSysId == id);
            if (servicePathToMonitor == null)
            {
                return NotFound();
            }

            return View(servicePathToMonitor);
        }

        // POST: ServicePathToMonitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServicePathToMonitors == null)
            {
                return Problem("Entity set 'RlvFileActivityMonitorContext.ServicePathToMonitors'  is null.");
            }
            var servicePathToMonitor = await _context.ServicePathToMonitors.FindAsync(id);
            if (servicePathToMonitor != null)
            {
                _context.ServicePathToMonitors.Remove(servicePathToMonitor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Monitor));
        }

        private bool ServicePathToMonitorExists(int id)
        {
          return _context.ServicePathToMonitors.Any(e => e.ServicePathSysId == id);
        }
    }
}
