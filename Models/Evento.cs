using System.ComponentModel.DataAnnotations;

namespace ExerciciosMVC.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 2, ErrorMessage = "Nome deve ter entre 2 e 80 caracteres.")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string? Nome { get; set; }

        [MinLength(10, ErrorMessage = "Descrição deve ter no mínimo 10 caracteres.")]
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string? Descricao { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Local deve ter entre 3 e 100 caracteres.")]
        [Required(ErrorMessage = "O local é obrigatório.")]
        public string? Local { get; set; }

        public DateTime DataEvento { get; set; }
        
        [Range(1, 1000, ErrorMessage = "Quantidade de vagas deve ser entre 1 e 1000")]
        public int QuantidadeVagas { get; set; }

        public decimal ValorIngresso { get; set; }
    }
}