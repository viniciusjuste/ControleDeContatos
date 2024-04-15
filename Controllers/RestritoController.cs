using ControleDeContatos.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    [PaginaParaUsuarioLogado] // Chama o filtro que foi criado.
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
