using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CR.Entities;

namespace CR.Controllers
{
    public class BaseFieldTypesController : Controller
    {
        private ContractsRecollectEntities db = new ContractsRecollectEntities();

        // GET: BaseFieldTypes
        public async Task<ActionResult> Index()
        {
            var baseFieldTypes = db.BaseFieldTypes.Include(b => b.Type1);
            return View(await baseFieldTypes.ToListAsync());
        }

        // GET: BaseFieldTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseFieldType baseFieldType = await db.BaseFieldTypes.FindAsync(id);
            if (baseFieldType == null)
            {
                return HttpNotFound();
            }
            return View(baseFieldType);
        }

        // GET: BaseFieldTypes/Create
        public ActionResult Create()
        {
            ViewBag.Type = new SelectList(db.Types, "ID", "Name");
            return View();
        }

        // POST: BaseFieldTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdContractFieldType,Name,Type")] BaseFieldType baseFieldType)
        {
            if (ModelState.IsValid)
            {
                db.BaseFieldTypes.Add(baseFieldType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Type = new SelectList(db.Types, "ID", "Name", baseFieldType.Type);
            return View(baseFieldType);
        }

        // GET: BaseFieldTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseFieldType baseFieldType = await db.BaseFieldTypes.FindAsync(id);
            if (baseFieldType == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type = new SelectList(db.Types, "ID", "Name", baseFieldType.Type);
            return View(baseFieldType);
        }

        // POST: BaseFieldTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdContractFieldType,Name,Type")] BaseFieldType baseFieldType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseFieldType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Type = new SelectList(db.Types, "ID", "Name", baseFieldType.Type);
            return View(baseFieldType);
        }

        // GET: BaseFieldTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseFieldType baseFieldType = await db.BaseFieldTypes.FindAsync(id);
            if (baseFieldType == null)
            {
                return HttpNotFound();
            }
            return View(baseFieldType);
        }

        // POST: BaseFieldTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BaseFieldType baseFieldType = await db.BaseFieldTypes.FindAsync(id);
            db.BaseFieldTypes.Remove(baseFieldType);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
