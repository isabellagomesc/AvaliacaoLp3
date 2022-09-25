using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AvaliacaoLP3.Models;

namespace AvaliacaoLP3.Controllers;

public class LojasController : Controller {
    public static List<LojaViewModel> lojas = new List<LojaViewModel>();

    public IActionResult Index()
    {
        return View(lojas);
    }

    public IActionResult Gerenciamento()
    {
        return View(lojas);
    }

    public IActionResult Detalhes(int id)
    {
        return View(lojas[id - 1]);
    }

    public IActionResult Excluir(int id)
    {
        lojas.RemoveAt(id - 1);
        return View();
    }

    public IActionResult Cadastro()
    {
        return View();
    }

    public IActionResult Cadastramento([FromForm] string piso, [FromForm] string nome, [FromForm] string descricao, [FromForm] string tipo, [FromForm] string email)
    {
        foreach(var loja in lojas)
        {
            if(nome == loja.Nome) 
            {
                ViewData["Texto"] = "A Loja informada já possui cadastro";
                return View();
            }
        }

        int id = 1;
        foreach(var loja in lojas)
        {
            id++;
        }
       
        LojaViewModel Loja = new LojaViewModel(id, piso, nome, descricao, tipo, email);
        lojas.Add(Loja);

        ViewData["Texto"] = "Loja cadastrada com sucesso";
        return View();
    }
}