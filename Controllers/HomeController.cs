using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExerciciosMVC.Models;

namespace ExerciciosMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // a view Index lê essa chave para exibir o valor da mensagem
        ViewData["Mensagem"] = "Bem-vindo ao sistema de eventos!";
        return View();
    }

    // Action que recebe parametro pela: /Home/Sobre/5
    public IActionResult Sobre(int? id)
    {
        // id pode ser nulo porque o trecho final da rota e opcional
        ViewBag.Versao = "1.0";
        ViewBag.ParametroId = id;
        return View();
    }
}
