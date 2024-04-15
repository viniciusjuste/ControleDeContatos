using ControleDeContatos.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ControleDeContatos.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContextAccessor; // O IHttpContextAccessor fornece acesso ao contexto HTTP atual.
        public Sessao(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public UsuarioModel BuscarSessaoDoUsuario()
        {
           string sessaoUsuario = _httpContextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario); // Deserializa o objeto que foi serializado.
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario); // Dar clique direito no mouse em cima do 'JsonConvert', ir em ações sugeridas e clicar em 'using Newtonsoft.Json'.
           
            _httpContextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);

            /* em C#, utilizando a biblioteca Newtonsoft.Json (também conhecida como Json.NET), 
            você pode usar o método "SerializeObject" para serializar um objeto para JSON. */
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
