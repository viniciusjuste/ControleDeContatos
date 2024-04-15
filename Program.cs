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



            builder.Services.AddSession(o => // Adiciona o servi�o de sess�o ao cont�iner de inje��o de depend�ncia do aplicativo.
            {
                // Define a propriedade HttpOnly do cookie da sess�o como verdadeira.
                // Isso impede que o cookie seja acessado por JavaScript, ajudando a mitigar ataques XSS.
                o.Cookie.HttpOnly = true;

                // Define a propriedade IsEssential do cookie da sess�o como verdadeira.
                // Isso indica que o cookie � essencial para o funcionamento do aplicativo e n�o deve ser bloqueado,
                // mesmo se o usu�rio optar por bloquear cookies n�o essenciais em seu navegador.
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

            app.UseSession(); // Para habilitar as sess�es dentro do projeto.

            app.MapControllerRoute( // � aqui que eu fa�o a tela de login aparecer primeiro, antes das outras.
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}"); // Basta eu mudar "{controller=Home}" para "{controller=Login}"

			app.Run();
        }
    }
}
