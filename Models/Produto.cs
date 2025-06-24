using System.ComponentModel.DataAnnotations;

namespace ProdutosApiReact.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        public string Descricao { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Preco { get; set; }

        [Required]
        public string Categoria { get; set; }
    }
}
