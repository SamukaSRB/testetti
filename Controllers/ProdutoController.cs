using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCX.Contexto;
using SCX.Models;

namespace SCX.Controllers
{
public class ProdutoController : Controller{
 
    private readonly DbContexto ProdContexto;

    
    public ProdutoController(DbContexto _contexto)
    {
            ProdContexto = _contexto;
    }
    [HttpGet]
    public IActionResult Produto()
    {
            return View();
    }
}

}

