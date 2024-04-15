using System.Security.Cryptography; 
using System.Text;

namespace ControleDeContatos.Helper
{
    public static class Criptografia // Classe estática para operações de criptografia
    {
        // Método de extensão para calcular o hash SHA-1 de uma string
        public static string GerarHash(this string valor)
        {
            // Criar objeto para calcular hash SHA-1
            var hash = SHA1.Create();
            // Criar objeto para codificar string como bytes ASCII
            var encoding = new ASCIIEncoding();
            // Converter a string de entrada para bytes ASCII
            var array = encoding.GetBytes(valor);

            // Calcular o hash SHA-1 dos bytes
            array = hash.ComputeHash(array);

            // Criar um StringBuilder para construir a representação hexadecimal do hash
            var strHexa = new StringBuilder();

            // Iterar sobre os bytes do hash e converter cada um em sua representação hexadecimal
            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2")); // Adicionar o byte convertido ao StringBuilder
            }

            // Retornar a representação hexadecimal do hash como uma string
            return strHexa.ToString();
        }
    }
}
