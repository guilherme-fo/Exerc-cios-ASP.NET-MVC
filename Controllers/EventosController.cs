using ExerciciosMVC.Models;
using ExerciciosMVC.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExerciciosMVC.Controllers
{
    public class EventosController : Controller
    {
        private static List<Evento> _eventos = new()
        {
            new Evento { Id = 1, Nome = "Guardião Cibernético", Descricao = "O maior treinamento de defesa cibernética do Hemisfério Sul, coordenado pelo Exército Brasileiro para testar a proteção e a resiliência das infraestruturas críticas do país.", Local = "São Paulo", DataEvento = DateTime.Now, QuantidadeVagas = 110, ValorIngresso = 150.00m },
            new Evento { Id = 2, Nome = "GTA 6", Descricao = "Lançamento do novo jogo da Rockstar Games no Brasil.", Local = "São Paulo", DataEvento = new DateTime(2026, 11, 19), QuantidadeVagas = 250, ValorIngresso = 180.00m }
        };

        // GET /Eventos - listar todos os eventos
        public IActionResult Index()
        {
            return View(_eventos);
        }

        // GET /Eventos/Detalhes/1 - mostrar um evento especifico
        public IActionResult Detalhes(int id)
        {
            var evento = _eventos.FirstOrDefault(e => e.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET /Eventos/Criar - retornar a View de Criação de Eventos
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        // POST /Eventos/Criar - recebe dados da View Criar()
        [HttpPost]
        public IActionResult Criar(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return View(evento); // retornar para a View de cadastro com erros de validação
            }


            evento.Id = _eventos.Any() ? _eventos.Max(e => e.Id) + 1 : 1;
            _eventos.Add(evento);

            return RedirectToAction("Index");
        }

        // GET /Eventos/Buscar
        [HttpGet]
        public IActionResult Buscar()
        {
            return View(new BuscaEventoViewModel());
        }

        // POST /Eventos/Buscar
        [HttpPost]
        public IActionResult Buscar(BuscaEventoViewModel vm)
        {
            if (!string.IsNullOrEmpty(vm.TermoBusca))
            {
                vm.Resultados = _eventos
                    .Where(e => e.Nome.Contains(vm.TermoBusca, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(vm);
        }
    }
}