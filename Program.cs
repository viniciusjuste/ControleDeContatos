using Microsoft.EntityFrameworkCore;
using ControleDeContatos.Data;
using ControleDeContatos.Repositorio;
using ControleDeContatos.Helper;


namespace ControleDeContatos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<BancoContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // Configura o 'HttpContextAccessor'.

            builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>(); // tem que fazer isso para a interface funcionar
            builder.Services.AddScoped<IUsuarioRepositorio, Usuariorepositorio>();
            builder.Services.AddScoped<ISessao, Sessao>();
            builder.Services.AddScoped<IEmail, Email>();



            builder.Services.AddSession(o => // Adiciona o serviço de sessão ao contêiner de injeção de dependência do aplicativo.
            {
                // Define a propriedade HttpOnly do cookie da sessão como verdadeira.
                // Isso impede que o cookie seja acessado por JavaScript, ajudando a mitigar ataques XSS.
                o.Cookie.HttpOnly = true;

                // Define a propriedade IsEssential do cookie da sessão como verdadeira.
                // Isso indica que o cookie é essencial para o funcionamento do aplicativo e não deve ser bloqueado,
                // mesmo se o usuário optar por bloquear cookies não essenciais em seu navegador.
                o.Cookie.IsEssential = true;
            });

           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession(); // Para habilitar as sessões dentro do projeto.

            app.MapControllerRoute( // É aqui que eu faço a tela de login aparecer primeiro, antes das outras.
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}"); // Basta eu mudar "{controller=Home}" para "{controller=Login}"

			app.Run();
        }
    }
}
