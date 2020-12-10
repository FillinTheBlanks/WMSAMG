using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WMSAMG.Models.CSIS2017Models;

namespace WMSAMG.Controllers
{
    public class WithdrawalController : Controller
    {
        private readonly CSIS2017Context _context;

        public WithdrawalController(CSIS2017Context context)
        {
            _context = context;
        }

        // GET: Withdrawal
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblStockWithdrawalDetail.ToListAsync());
        }

        // GET: Withdrawal/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblStockWithdrawalDetail = await _context.TblStockWithdrawalDetail
                .FirstOrDefaultAsync(m => m.ReferenceCode == id);
            if (tblStockWithdrawalDetail == null)
            {
                return NotFound();
            }

            return View(tblStockWithdrawalDetail);
        }

        // GET: Withdrawal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Withdrawal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReferenceCode,Swcode,Rrcode,CustomerId,PayTypeInitial,StockId,StockSku,StockGroupId,StockPcsperPack,StockPackperCase,Qty,ActualWeight,Uom,ProductionDate,StockWeightinKilosperPack,StockWeightinKilosperCase,PalletNo,CompanyId,StorageLocationId,StorageId,StorageTypeId,TransactionDate,StartTime,EndTime,LocationId,Nature,Source,Remarks,ApprovedBy,Requestor,Approver,EmployeeId,EmployeeDate,IsSaved")] TblStockWithdrawalDetail tblStockWithdrawalDetail)
        {
            if (ModelState.IsValid)
            {
                tblStockWithdrawalDetail.ReferenceCode = Guid.NewGuid();
                _context.Add(tblStockWithdrawalDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblStockWithdrawalDetail);
        }

        // GET: Withdrawal/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblStockWithdrawalDetail = await _context.TblStockWithdrawalDetail.FindAsync(id);
            if (tblStockWithdrawalDetail == null)
            {
                return NotFound();
            }
            return View(tblStockWithdrawalDetail);
        }

        // POST: Withdrawal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ReferenceCode,Swcode,Rrcode,CustomerId,PayTypeInitial,StockId,StockSku,StockGroupId,StockPcsperPack,StockPackperCase,Qty,ActualWeight,Uom,ProductionDate,StockWeightinKilosperPack,StockWeightinKilosperCase,PalletNo,CompanyId,StorageLocationId,StorageId,StorageTypeId,TransactionDate,StartTime,EndTime,LocationId,Nature,Source,Remarks,ApprovedBy,Requestor,Approver,EmployeeId,EmployeeDate,IsSaved")] TblStockWithdrawalDetail tblStockWithdrawalDetail)
        {
            if (id != tblStockWithdrawalDetail.ReferenceCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblStockWithdrawalDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblStockWithdrawalDetailExists(tblStockWithdrawalDetail.ReferenceCode))
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
            return View(tblStockWithdrawalDetail);
        }

        // GET: Withdrawal/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblStockWithdrawalDetail = await _context.TblStockWithdrawalDetail
                .FirstOrDefaultAsync(m => m.ReferenceCode == id);
            if (tblStockWithdrawalDetail == null)
            {
                return NotFound();
            }

            return View(tblStockWithdrawalDetail);
        }

        // POST: Withdrawal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblStockWithdrawalDetail = await _context.TblStockWithdrawalDetail.FindAsync(id);
            _context.TblStockWithdrawalDetail.Remove(tblStockWithdrawalDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblStockWithdrawalDetailExists(Guid id)
        {
            return _context.TblStockWithdrawalDetail.Any(e => e.ReferenceCode == id);
        }
    }
}
