using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCondominio;
using AppCondominio.Models;

namespace AppCondominio.Controllers
{
    public class MateriaisController : Controller
    {
        private readonly CondominioContext _context;

        public MateriaisController(CondominioContext context)
        {
            _context = context;
        }

        // GET: Materiais
        public async Task<IActionResult> Index()
        {
            var condominioContext = _context.Materiais.Include(m => m.Fornecedor).Include(m => m.Locador);
            return View(await condominioContext.ToListAsync());
        }

        // GET: Materiais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materiais
                .Include(m => m.Fornecedor)
                .Include(m => m.Locador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Materiais/Create
        public IActionResult Create()
        {
            ViewData["FornecedorID"] = new SelectList(_context.Fornecedores, "Id", "Nome");
            ViewData["LocadorID"] = new SelectList(_context.Locadores, "Id", "Nome");
            return View();
        }

        // POST: Materiais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Descricao,ValorUnitario,QuantidadeAtual,QuantidadeTotal,FornecedorID,LocadorID,Id")] Material material)
        {
            if (ModelState.IsValid)
            {
                _context.Add(material);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorID"] = new SelectList(_context.Fornecedores, "Id", "CNPJ", material.FornecedorID);
            ViewData["LocadorID"] = new SelectList(_context.Locadores, "Id", "Documento", material.LocadorID);
            return View(material);
        }

        // GET: Materiais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materiais.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            ViewData["FornecedorID"] = new SelectList(_context.Fornecedores, "Id", "CNPJ", material.FornecedorID);
            ViewData["LocadorID"] = new SelectList(_context.Locadores, "Id", "Documento", material.LocadorID);
            return View(material);
        }

        // POST: Materiais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Descricao,ValorUnitario,QuantidadeAtual,QuantidadeTotal,FornecedorID,LocadorID,Id")] Material material)
        {
            if (id != material.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(material);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.Id))
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
            ViewData["FornecedorID"] = new SelectList(_context.Fornecedores, "Id", "CNPJ", material.FornecedorID);
            ViewData["LocadorID"] = new SelectList(_context.Locadores, "Id", "Documento", material.LocadorID);
            return View(material);
        }

        // GET: Materiais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materiais
                .Include(m => m.Fornecedor)
                .Include(m => m.Locador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Materiais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var material = await _context.Materiais.FindAsync(id);
            _context.Materiais.Remove(material);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(int id)
        {
            return _context.Materiais.Any(e => e.Id == id);
        }
    }
}
