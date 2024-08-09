using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webformulario.Data;
using webformulario.Models;

namespace webformulario.Controllers
{
    public class filiacaoController : Controller
    {
        private readonly webformularioContext _context;

        public filiacaoController(webformularioContext context)
        {
            _context = context;
        }

        // GET: filiacao
        public async Task<IActionResult> Index()
        {
            return View(await _context.filiacao.ToListAsync());
        }

        // GET: filiacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiacao = await _context.filiacao
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (filiacao == null)
            {
                return NotFound();
            }

            return View(filiacao);
        }

        // GET: filiacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: filiacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Telefone,Vitalicio,Anual")] filiacao filiacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filiacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filiacao);
        }

        // GET: filiacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiacao = await _context.filiacao.FindAsync(id);
            if (filiacao == null)
            {
                return NotFound();
            }
            return View(filiacao);
        }

        // POST: filiacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Telefone,Vitalicio,Anual")] filiacao filiacao)
        {
            if (id != filiacao.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filiacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!filiacaoExists(filiacao.Codigo))
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
            return View(filiacao);
        }

        // GET: filiacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiacao = await _context.filiacao
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (filiacao == null)
            {
                return NotFound();
            }

            return View(filiacao);
        }

        // POST: filiacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filiacao = await _context.filiacao.FindAsync(id);
            if (filiacao != null)
            {
                _context.filiacao.Remove(filiacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool filiacaoExists(int id)
        {
            return _context.filiacao.Any(e => e.Codigo == id);
        }
    }
}
