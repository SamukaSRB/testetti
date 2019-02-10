

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCX.Models
{
    [Table("produtos")]
             public class Produto{
            [Key]
            public  long  IdProduto{get;set;}
             [Required]
            public  string Nome{get;set;}
             [Required]
            public string Descricao{get;set;}
             [Required]
            public string Categoria{get;set;}          
             
           
             [Required]
            
            public double Preco{get;set;}           

        }
    }
    