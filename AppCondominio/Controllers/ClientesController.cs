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
    public class ClientesController : Controller
    {
        private readonly IClienteRepo clienteRepo;
        private readonly ILocadorRepo locadorRepo;

        public ClientesController(
            IClienteRepo clienteRepo,
            ILocadorRepo locadorRepo)
        {
            this.clienteRepo = clienteRepo;
            this.locadorRepo = locadorRepo;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(clienteRepo.GetClientes());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente cliente = clienteRepo.GetCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Documento");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Cpf,LocadorID,Id,Contato,Endereco")] Cliente cliente, Contato contato, Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                cliente.Contato = contato;
                cliente.Endereco = endereco;
                clienteRepo.CreateCliente(cliente);
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Documento");
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = clienteRepo.GetCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Documento");
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Cpf,LocadorID,Id")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    clienteRepo.UpdateCliente(cliente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!clienteRepo.ClienteExists(cliente.Id))
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
            ViewData["LocadorID"] = new SelectList(locadorRepo.GetLocadores(), "Id", "Documento");
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = clienteRepo.GetCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = clienteRepo.GetCliente(id);
            clienteRepo.RemoveCliente(cliente);
            return RedirectToAction(nameof(Index));
        }
    }
}
