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
    public class ControlesInOutController : Controller
    {
        private readonly IControleInOutRepo controleRepo;
        private readonly IClienteRepo clienteRepo;
        private readonly ILocadorRepo locadorRepo;

        public ControlesInOutController(IControleInOutRepo controleRepo,
            IClienteRepo clienteRepo,
            ILocadorRepo locadorRepo)
        {
            this.controleRepo = controleRepo;
            this.locadorRepo = locadorRepo;
            this.clienteRepo = clienteRepo;
        }

        // GET: ControlesInOut
        public async Task<IActionResult> Index()
        {
            return View(controleRepo.GetControlesInOut());
        }

        // GET: ControlesInOut/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controleInOut = controleRepo.GetControleInOut(id);
            if (controleInOut == null)
            {
                return NotFound();
            }

            return View(controleInOut);
        }

        // GET: ControlesInOut/Create
        public IActionResult Create()
        {
            ViewData["ClienteID"] = new SelectList(clienteRepo.GetClientes(), "Id", "Nome");
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Nome");
            return View();
        }

        // POST: ControlesInOut/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataEntrada,DataSaida,LocadorID,ClienteID,Id")] ControleInOut controleInOut)
        {
            if (ModelState.IsValid)
            {
                controleRepo.CreateControleInOut(controleInOut);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteID"] = new SelectList(clienteRepo.GetClientes(), "Id", "Nome");
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Nome");
            return View(controleInOut);
        }

        // GET: ControlesInOut/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controleInOut = controleRepo.GetControleInOut(id);
            if (controleInOut == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(clienteRepo.GetClientes(), "Id", "Nome");
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Nome");
            return View(controleInOut);
        }

        // POST: ControlesInOut/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DataEntrada,DataSaida,LocadorID,ClienteID,Id")] ControleInOut controleInOut)
        {
            if (id != controleInOut.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    controleRepo.UpdateControleInOut(controleInOut);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!controleRepo.ControleInOutExists(controleInOut.Id))
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
            ViewData["ClienteID"] = new SelectList(clienteRepo.GetClientes(), "Id", "Nome");
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Nome");
            return View(controleInOut);
        }

        // GET: ControlesInOut/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controleInOut = controleRepo.GetControleInOut(id);
            if (controleInOut == null)
            {
                return NotFound();
            }

            return View(controleInOut);
        }

        // POST: ControlesInOut/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var controleInOut = controleRepo.GetControleInOut(id);
            controleRepo.DeleteControleInOut(controleInOut);
            return RedirectToAction(nameof(Index));
        }
    }
}
