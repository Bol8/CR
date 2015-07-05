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
using CR.Management;

namespace CR.Controllers
{
    public class BaseFieldsTemplatesController : Controller
    {
        private ContractsRecollectEntities db = new ContractsRecollectEntities();

        // GET: BaseFieldsTemplates
        public async Task<ActionResult> Index()
        {
            var baseFieldsTemplates = db.BaseFieldsTemplates.Include(b => b.BaseFieldType).Include(b => b.BaseType);
            return View(await baseFieldsTemplates.ToListAsync());
        }

        // GET: BaseFieldsTemplates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseFieldsTemplate baseFieldsTemplate = await db.BaseFieldsTemplates.FindAsync(id);
            if (baseFieldsTemplate == null)
            {
                return HttpNotFound();
            }
            return View(baseFieldsTemplate);
        }

        // GET: BaseFieldsTemplates/Create
        public ActionResult Create()
        {
            ViewBag.idContractFieldTypes = new SelectList(db.BaseFieldTypes, "IdContractFieldType", "Name");
            ViewBag.idContractType = new SelectList(db.BaseTypes, "IdContractType", "NameContractType");
            return View();
        }

        // POST: BaseFieldsTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idContractFieldTemplate,idContractType,MandatoryField,DefaultValue,AliasField,FieldValue,idContractFieldTypes")] BaseFieldsTemplate baseFieldsTemplate)
        {


            if (Management.Management.checkTypeofData(baseFieldsTemplate))
            {
                db.BaseFieldsTemplates.Add(baseFieldsTemplate);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idContractFieldTypes = new SelectList(db.BaseFieldTypes, "IdContractFieldType", "Name", baseFieldsTemplate.idContractFieldTypes);
            ViewBag.idContractType = new SelectList(db.BaseTypes, "IdContractType", "NameContractType", baseFieldsTemplate.idContractType);
            return View(baseFieldsTemplate);

            //if (ModelState.IsValid)
            //{
            //    db.BaseFieldsTemplates.Add(baseFieldsTemplate);
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.idContractFieldTypes = new SelectList(db.BaseFieldTypes, "IdContractFieldType", "Name", baseFieldsTemplate.idContractFieldTypes);
            //ViewBag.idContractType = new SelectList(db.BaseTypes, "IdContractType", "NameContractType", baseFieldsTemplate.idContractType);
            //return View(baseFieldsTemplate);
        }

        // GET: BaseFieldsTemplates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseFieldsTemplate baseFieldsTemplate = await db.BaseFieldsTemplates.FindAsync(id);
            if (baseFieldsTemplate == null)
            {
                return HttpNotFound();
            }
            ViewBag.idContractFieldTypes = new SelectList(db.BaseFieldTypes, "IdContractFieldType", "Name", baseFieldsTemplate.idContractFieldTypes);
            ViewBag.idContractType = new SelectList(db.BaseTypes, "IdContractType", "NameContractType", baseFieldsTemplate.idContractType);
            return View(baseFieldsTemplate);
        }

        // POST: BaseFieldsTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idContractFieldTemplate,idContractType,MandatoryField,DefaultValue,AliasField,FieldValue,idContractFieldTypes")] BaseFieldsTemplate baseFieldsTemplate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseFieldsTemplate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idContractFieldTypes = new SelectList(db.BaseFieldTypes, "IdContractFieldType", "Name", baseFieldsTemplate.idContractFieldTypes);
            ViewBag.idContractType = new SelectList(db.BaseTypes, "IdContractType", "NameContractType", baseFieldsTemplate.idContractType);
            return View(baseFieldsTemplate);
        }

        // GET: BaseFieldsTemplates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseFieldsTemplate baseFieldsTemplate = await db.BaseFieldsTemplates.FindAsync(id);
            if (baseFieldsTemplate == null)
            {
                return HttpNotFound();
            }
            return View(baseFieldsTemplate);
        }

        // POST: BaseFieldsTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BaseFieldsTemplate baseFieldsTemplate = await db.BaseFieldsTemplates.FindAsync(id);
            db.BaseFieldsTemplates.Remove(baseFieldsTemplate);
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
