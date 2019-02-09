

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCX.Models
{
    [Table("produtos")]
             public class Produto{
            [Key]
            public  long  IdProduto{get;set;}
             [Required]
            public  string NomeProduto{get;set;}
             [Required]
            public Categoria CategoriaProdutos{get;set;}
             [Required]
            public SubCategoria SubcategoriaProdutos{get;set;}
             [Required]
            public double PrecoDVendasProdutos{get;set;}
             [Required]
            public string DescricaoProduto{get;set;}

        }
    }