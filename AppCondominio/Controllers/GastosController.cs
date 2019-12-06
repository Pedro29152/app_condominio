using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCondominio;
using AppCondominio.Models;
using AppCondominio.Repository.Interfaces;

namespace AppCondominio.Controllers
{
    public class GastosController : Controller
    {
        private readonly IGastosRepo gastosRepo;
        private readonly ILocadorRepo locadorRepo;

        public GastosController(IGastosRepo gastosRepo,
            ILocadorRepo locadorRepo)
        {
            this.gastosRepo = gastosRepo;
            this.locadorRepo = locadorRepo;
        }

        // GET: Gastos
        public async Task<IActionResult> Index()
        {
            return View(gastosRepo.GetGastos());
        }

        // GET: Gastos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastos = gastosRepo.GetGasto(id);
            if (gastos == null)
            {
                return NotFound();
            }

            return View(gastos);
        }

        // GET: Gastos/Create
        public IActionResult Create()
        {
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Nome");
            return View();
        }

        // POST: Gastos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tipo,Descricao,Limite,Valor,LocadorID,Id")] Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                gastosRepo.CreateGastos(gastos);;
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Nome");
            return View(gastos);
        }

        // GET: Gastos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastos = gastosRepo.GetGasto(id);
            if (gastos == null)
            {
                return NotFound();
            }
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Nome");
            return View(gastos);
        }

        // POST: Gastos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tipo,Descricao,Limite,Valor,LocadorID,Id")] Gastos gastos)
        {
            if (id != gastos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    gastosRepo.CreateGastos(gastos);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!gastosRepo.GastosExists(gastos.Id))
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
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Nome");

            return View(gastos);
        }

        // GET: Gastos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastos = gastosRepo.GetGasto(id);
            if (gastos == null)
            {
                return NotFound();
            }

            return View(gastos);
        }

        // POST: Gastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gastos = gastosRepo.GetGasto(id);
            gastosRepo.DeleteGastos(gastos);
            return RedirectToAction(nameof(Index));
        }
    }
}
