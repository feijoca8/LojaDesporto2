using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaDesporto2.Data;
using LojaDesporto2.Models;

namespace LojaDesporto2.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly LojaDesporto2BdContext bd;

        public ProdutosController(LojaDesporto2BdContext context)
        {
            bd = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {  
            return View(await bd.Produto.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await bd.Produto
                .SingleOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return View("Inexistente");
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,Nome,Descricao,Preco")] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                
                return View(produto);

            }
            bd.Add(produto);
            await bd.SaveChangesAsync();

            @ViewBag.Mensagem = "Produto Adicionado com sucesso";
            return View("Sucesso");
        }



        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await bd.Produto.FindAsync(id);
            if (produto == null)
            {
                return View("Inexistente");
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,Nome,Descricao,Preco")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bd.Update(produto);
                    await bd.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoId))
                    {
                        return View("Eliminarinserir", produto);
                    }
                    else
                    {
                        ModelState.AddModelError("Erro", "Ocorreu um erro. Não foi possivel guardar o produto. Tente novamente e se o problema prosseguir contacte a assistência.");
                        return View(produto);
                    }
                }
                ViewBag.Mensagem = "Produto alterado com sucesso";
                return View("Sucesso");
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await bd.Produto
                .SingleOrDefaultAsync(p => p.ProdutoId == id);
            if (produto == null)
            {
                ViewBag.Mensagem = "O produto que estava a tentar apagar, foi eliminado por outra pessoa";
                return View("Sucesso");
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await bd.Produto.FindAsync(id);
            bd.Produto.Remove(produto);
            await bd.SaveChangesAsync();

            ViewBag.Mensagem = "O produto foi eliminado com sucesso.";
            return View("Sucesso");
        }

        private bool ProdutoExists(int id)
        {
            return bd.Produto.Any(p => p.ProdutoId == id);
        }
    }
}
