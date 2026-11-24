using ExerciciosMVC.Models;

namespace ExerciciosMVC.ViewsModels
{
    public class BuscaEventoViewModel
    {
        public string? TermoBusca { get; set; }
        public List<Evento> Resultados { get; set; } = new();
    }
}