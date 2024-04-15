using ControleDeContatos.Models;  
using Microsoft.EntityFrameworkCore;  
using Microsoft.EntityFrameworkCore.Metadata.Builders;  

namespace ControleDeContatos.Data.Map
{
    public class ContatoMap : IEntityTypeConfiguration<ContatoModel>  // Define a classe ContatoMap que implementa a interface IEntityTypeConfiguration para a entidade ContatoModel
    {
        public void Configure(EntityTypeBuilder<ContatoModel> builder)
        {
            builder.HasKey(x => x.Id);  // Define a chave primária da entidade ContatoModel como a propriedade Id
            builder.HasOne(x => x.Usuario);  // Define um relacionamento de um-para-um (hasOne) entre a entidade ContatoModel e a entidade UsuarioModel
        }
    }
}
