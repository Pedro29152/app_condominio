﻿using System;
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
    public class MateriaisController : Controller
    {
        private readonly IMaterialRepo materialRepo;
        private readonly IFornecedorRepo fornecedorRepo;
        private readonly ILocadorRepo locadorRepo;

        public MateriaisController(IMaterialRepo materialRepo,
            IFornecedorRepo fornecedorRepo,
            ILocadorRepo locadorRepo)
        {
            this.materialRepo = materialRepo;
            this.fornecedorRepo = fornecedorRepo;
            this.locadorRepo = locadorRepo;
        }

        // GET: Materiais
        public async Task<IActionResult> Index()
        {
            return View(materialRepo.GetMateriais());
        }

        // GET: Materiais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = materialRepo.GetMaterial(id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Materiais/Create
        public IActionResult Create()
        {
            ViewData["FornecedorID"] = new SelectList(fornecedorRepo.GetFornecedores(), "Id", "Nome");
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Nome");
            return View();
        }

        // POST: Materiais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Descricao,ValorUnitario,Quantidade,FornecedorID,LocadorID,Id")] Material material)
        {
            if (ModelState.IsValid)
            {
                var teste = materialRepo.CreateMaterial(material);
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorID"] = new SelectList(fornecedorRepo.GetFornecedores(), "Id", "Nome");
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Nome");
            return View(material);
        }

        // GET: Materiais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = materialRepo.GetMaterial(id);
            if (material == null)
            {
                return NotFound();
            }
            ViewData["FornecedorID"] = new SelectList(fornecedorRepo.GetFornecedores(), "Id", "Nome");
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Nome");
            return View(material);
        }

        // POST: Materiais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Descricao,ValorUnitario,Quantidade,FornecedorID,LocadorID,Id")] Material material)
        {
            if (id != material.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    materialRepo.UpdateMaterial(material);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!materialRepo.MaterialExists(material.Id))
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
            ViewData["FornecedorID"] = new SelectList(fornecedorRepo.GetFornecedores(), "Id", "Nome");
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Nome");
            return View(material);
        }

        // GET: Materiais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = materialRepo.GetMaterial(id);
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
            var material = materialRepo.GetMaterial(id);
            materialRepo.RemoveMaterial(material);
            return RedirectToAction(nameof(Index));
        }
    }
}
