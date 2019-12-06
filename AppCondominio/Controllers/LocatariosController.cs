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
    public class LocatariosController : Controller
    {
        private readonly ILocatarioRepo locatarioRepo;

        public LocatariosController(ILocatarioRepo locatarioRepo)
        {
            this.locatarioRepo = locatarioRepo;
        }

        // GET: Locatarios
        public async Task<IActionResult> Index()
        {
            return View(locatarioRepo.GetLocatarios());
        }

        // GET: Locatarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatario = locatarioRepo.GetLocatario(id);
            if (locatario == null)
            {
                return NotFound();
            }

            return View(locatario);
        }

        // GET: Locatarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locatarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Documento,Nome,Id,Endereco,Contato")] Locatario locatario)
        {
            if (ModelState.IsValid)
            {
                locatarioRepo.CreateLocatario(locatario);
                return RedirectToAction(nameof(Index));
            }
            return View(locatario);
        }

        // GET: Locatarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatario =  locatarioRepo.GetLocatario(id);
            if (locatario == null)
            {
                return NotFound();
            }
            return View(locatario);
        }

        // POST: Locatarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Documento,Nome,Id,Endereco,Contato")] Locatario locatario)
        {
            if (id != locatario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    locatarioRepo.UpdateLocatario(locatario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!locatarioRepo.LocatarioExists(locatario.Id))
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
            return View(locatario);
        }

        // GET: Locatarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatario =  locatarioRepo.GetLocatario(id);
            if (locatario == null)
            {
                return NotFound();
            }

            return View(locatario);
        }

        // POST: Locatarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locatario = locatarioRepo.GetLocatario(id);
            locatarioRepo.DeleteLocatario(locatario);
            return RedirectToAction(nameof(Index));
        }
    }
}
