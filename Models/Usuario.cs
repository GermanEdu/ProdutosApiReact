using System.ComponentModel.DataAnnotations;

namespace ProdutosApiReact.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
