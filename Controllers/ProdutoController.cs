using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using SCX.Contexto;
using SCX.Models;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
namespace SCX.Controllers
{
public class ProdutoController : Controller{
        private const string ObjValue = "samuka";
        private readonly DbContexto ProdContexto;
    public ProdutoController(DbContexto _contexto)
    {
            ProdContexto = _contexto;
    }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Produto(Produto produto)
        {

            if (ModelState.IsValid)
            {
                produto.Preco = Math.Round(produto.Preco);
               ProdContexto.Produtos.Add(produto);
               ProdContexto.SaveChanges();
               return RedirectToAction("Listagem");
              
            }           
             

            return View(produto);
        }
       [HttpGet]
         public IActionResult Produto()
    {
        var produto  = new Produto();
            return View(produto);
    }
        
        
        [HttpGet]
        public IActionResult Listagem(){
         var produtos = ProdContexto.Produtos.ToList();
        return View (produtos);
        }  
       
        [HttpGet]
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Produto produto = ProdContexto.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long? id, Produto produto)
        {
            var _produto = ProdContexto.Produtos.Find(id);
            _produto.Nome = produto.Nome;
            _produto.Descricao= produto.Descricao;
            _produto.Categoria = produto.Categoria;
            _produto.Preco = produto.Preco;

            if (ModelState.IsValid)
            {
                ProdContexto.Produtos.Update(_produto);
                ProdContexto.SaveChanges();
                 return RedirectToAction("Listagem");
            }
            return View(produto);
        }
        [HttpGet]
        public IActionResult Delete(long? id)
        {
            
            Produto produto = ProdContexto.Produtos.Find(id);
       

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long? id)
        {

          Produto produto = ProdContexto.Produtos.Find(id);

            if (produto != null)
            {
               ProdContexto.Produtos.Remove(produto);
                ProdContexto.SaveChanges();
                return RedirectToAction("Listagem");
            }
            return View(produto);
        }

     

    }
}

