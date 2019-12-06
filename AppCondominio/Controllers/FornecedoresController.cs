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
    public class FornecedoresController : Controller
    {
        private readonly IFornecedorRepo fornecedorRepo;
        private object locador;

        public FornecedoresController(IFornecedorRepo fornecedorRepo)
        {
            this.fornecedorRepo = fornecedorRepo;
        }

        // GET: Fornecedores
        public async Task<IActionResult> Index()
        {
            return View(fornecedorRepo.GetFornecedores());
        }

        // GET: Fornecedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = fornecedorRepo.GetFornecedor(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedores/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Orcamento(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fornecedor = fornecedorRepo.GetFornecedor(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            var relatorio = new OrcamentoMateriais(fornecedor);
            return View(relatorio);
        }

        // POST: Fornecedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CNPJ,Nome,Descricao,Id")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                fornecedorRepo.GravaFornecedor(fornecedor);
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // GET: Fornecedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = fornecedorRepo.GetFornecedor(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CNPJ,Nome,Descricao,Id")] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    fornecedorRepo.UpdateFornecedor(fornecedor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!fornecedorRepo.FornecedorExists(fornecedor.Id))
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
            return View(fornecedor);
        }

        // GET: Fornecedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = fornecedorRepo.GetFornecedor(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = fornecedorRepo.GetFornecedor(id);
            fornecedorRepo.DeleteFornecedor(fornecedor);
            return RedirectToAction(nameof(Index));
        }
    }
}
