using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ControleDeContatos.Filters
{
    /* esse filtro de ação tem como objetivo principal garantir que apenas usuários autenticados tenham acesso a determinadas 
     * partes do aplicativo, especialmente aquelas que exigem autenticação para serem acessadas. 
     * Quando um usuário tenta acessar uma URL diretamente sem estar autenticado, este filtro redireciona automaticamente 
     * o usuário para a página de login, impedindo o acesso não autorcizado. */

    public class PaginaParaUsuarioLogado : ActionFilterAttribute  // São os filtros do ASP.NET MVC.
    {
        public override void OnActionExecuting(ActionExecutingContext context) // Estou sobrescrevendo o método "OnActionExecuting", do "ActionFilterAttribute".
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado"); // Verifica se tem um usuário logado.

            if (string.IsNullOrEmpty(sessaoUsuario)) // Se náo tiver ninguém logado.
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } }); // Redireciona o usuário para o controller Login e a rota Index.

            }
            else
            {
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario); // Desserializa o objeto em Json para um objeto do tipo UsuarioModel.

                if (usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } }); // Redireciona o usuário para o controller Login e a rota Index.

                }
            }

            base.OnActionExecuting(context); // Está pegando todo o código base do "ActionFilterAttribute", executando no "OnActionExecuting".
        }
    }
}
