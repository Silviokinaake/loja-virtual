﻿using System.ComponentModel.DataAnnotations;

namespace AppLojaVirtual.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
        public string? Nome { get; set; }
    }
}
