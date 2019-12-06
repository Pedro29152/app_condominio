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
    public class ContratosController : Controller
    {
        private readonly IContratoRepo contratoRepo;
        private readonly ILocadorRepo locadorRepo;
        private readonly ILocatarioRepo locatarioRepo;

        public ContratosController(IContratoRepo contratoRepo,
            ILocadorRepo locadorRepo,
            ILocatarioRepo locatarioRepo)
        {
            this.contratoRepo = contratoRepo;
            this.locadorRepo = locadorRepo;
            this.locatarioRepo = locatarioRepo;
        }

        // GET: Contratoes
        public async Task<IActionResult> Index()
        {
            return View(contratoRepo.GetContratos());
        }

        // GET: Contratoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = contratoRepo.GetContrato(id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // GET: Contratoes/Create
        public IActionResult Create()
        {
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Nome");
            ViewData["LocatarioID"] = new SelectList(locatarioRepo.GetLocatarios(), "Id", "Nome");
            return View();
        }

        // POST: Contratoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataInicio,DataFim,Valor,FormaPagamento,LocadorID,LocatarioID,Id")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                contratoRepo.CreateContrato(contrato);
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Nome");
            ViewData["LocatarioID"] = new SelectList(locatarioRepo.GetLocatarios(), "Id", "Nome");
            return View(contrato);
        }

        // GET: Contratoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = contratoRepo.GetContrato(id);
            if (contrato == null)
            {
                return NotFound();
            }
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Nome");
            ViewData["LocatarioID"] = new SelectList(locatarioRepo.GetLocatarios(), "Id", "Nome");
            return View(contrato);
        }

        // POST: Contratoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DataInicio,DataFim,Valor,FormaPagamento,LocadorID,LocatarioID,Id")] Contrato contrato)
        {
            if (id != contrato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    contratoRepo.UpdateContrato(contrato);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!contratoRepo.ContratoExists(contrato.Id))
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
            ViewData["LocatarioID"] = new SelectList(locatarioRepo.GetLocatarios(), "Id", "Nome");
            return View(contrato);
        }

        // GET: Contratoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = contratoRepo.GetContrato(id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // POST: Contratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contrato = contratoRepo.GetContrato(id);
            contratoRepo.DeleteContrato(contrato);
            return RedirectToAction(nameof(Index));
        }
    }
}
