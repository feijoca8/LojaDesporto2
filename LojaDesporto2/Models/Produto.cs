using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDesporto2.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatorio")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "O nome deve de ter pelo menos 4 carateceres e nao deve de exceder os 200 carateres")]
        public string Nome { get; set; }

       
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Deve preencher o preço")]
        public decimal Preco { get; set; }
    }
}
