using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace ControleDeContatos.Repositorio.ViewComponents
{
    public class Menu : ViewComponent
    {
        // Este método é chamado quando o componente é invocado em uma página.
        // Ele retorna a View associada ao componente.
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }

            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

            // Retorna a View correspondente ao componente.
            return View(usuario);
        }
    }
}
