using ControleDeContatos.Data.Map;  
using ControleDeContatos.Models;    
using Microsoft.EntityFrameworkCore; 

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext  // Define a classe BancoContext que herda de DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
            // Construtor da classe, recebe opções de configuração do banco de dados e chama o construtor da classe base (DbContext) com essas opções
        }

        public DbSet<ContatoModel> Contatos { get; set; }  // Define um conjunto de entidades (DbSet) para os contatos
        public DbSet<UsuarioModel> Usuarios { get; set; }  // Define um conjunto de entidades (DbSet) para os usuários

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());  // Aplica configurações de mapeamento personalizadas para a entidade ContatoModel
            base.OnModelCreating(modelBuilder);  // Chama o método OnModelCreating da classe base para aplicar outras configurações padrão, se houver
        }
    }
}
