using Microsoft.AspNetCore.Mvc;
using RacasDeCachorros.Models;

namespace RacasDeCachorros.Controllers;

public class CachorroController : Controller
{
    private static List<Cachorro> _lista = new List<Cachorro>();
    private static int _id = 0;

    [HttpGet]
    public IActionResult PesquisaNome(string searchString)
    {
        if (string.IsNullOrEmpty(searchString))
        {
            return RedirectToAction("Index");
        }

        var cachorros = _lista.Where(c => c.Nome?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true).ToList();

        if (cachorros.Count == 0)
        {
            TempData["msg"] = "Nenhum cachorro encontrado!";
            return RedirectToAction("Index");
        }

        return View("Index", cachorros);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(Cachorro cachorro)
    {
        cachorro.CachorroId = ++_id;
        _lista.Add(cachorro);
        TempData["msg"] = "Cachorro cadastrado com sucesso!";
        return RedirectToAction("Cadastrar");
    }

    public IActionResult Index()
    {
        return View(_lista);
    }

    [HttpGet]
    public IActionResult Editar(int id)
    {
        var cachorro = _lista.FirstOrDefault(c => c.CachorroId == id);
        if (cachorro == null)
        {
            TempData["msg"] = "Cachorro não encontrado!";
            return RedirectToAction("Index");
        }
        return View(cachorro);
    }

    [HttpPost]
    public IActionResult Editar(Cachorro cachorro)
    {
        var existingCachorro = _lista.FirstOrDefault(c => c.CachorroId == cachorro.CachorroId);
        if (existingCachorro == null)
        {
            TempData["msg"] = "Cachorro não encontrado!";
            return RedirectToAction("Index");
        }
        existingCachorro.Nome = cachorro.Nome;
        existingCachorro.Origem = cachorro.Origem;
        existingCachorro.Tamanho = cachorro.Tamanho;
        existingCachorro.Grupo = cachorro.Grupo;
        existingCachorro.Nascimento = cachorro.Nascimento;
        existingCachorro.Genero = cachorro.Genero;
        TempData["msg"] = "Cachorro atualizado com sucesso!";
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Remover(int id)
    {
        var cachorro = _lista.FirstOrDefault(c => c.CachorroId == id);
        if (cachorro == null)
        {
            TempData["msg"] = "Cachorro não encontrado!";
        }
        else
        {
            _lista.Remove(cachorro);
            TempData["msg"] = "Cachorro removido com sucesso!";
        }
        return RedirectToAction("Index");
    }
}
