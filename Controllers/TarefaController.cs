using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Controllers
{
    public class TarefaController : Controller
    {
        private readonly AgendaContext _context;
        

        public TarefaController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tarefas = _context.Tarefas.ToList();

            if(tarefas.Count == 0) return RedirectToAction(nameof(SemTarefas));

            return View(tarefas);
        }

        public IActionResult SemTarefas()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if(ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public IActionResult Editar(int id)
        {

            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null) return RedirectToAction(nameof(Index));

            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Editar(Tarefa tarefa)
        {
            if(ModelState.IsValid)
            {
                _context.Update(tarefa);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Deletar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null) return RedirectToAction(nameof(Index));

            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Deletar(Tarefa tarefa)
        {
            if(ModelState.IsValid)
            {
                _context.Tarefas.Remove(tarefa);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public IActionResult AlterarStatus(int id)
        {

            var tarefa = _context.Tarefas.Find(id);
            tarefa.ToggleStatus();
            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Buscar()
        {
            return View();
        }

        public IActionResult ObterPorId()
        {
            return View();
        }

        public IActionResult TarefaPorId(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            List<Tarefa> tarefas = new List<Tarefa>();

            tarefas.Add(tarefa);

            return View("Detalhes", tarefas);

        }

        public IActionResult ObterPorTitulo()
        {
            return View();
        }

        public IActionResult TarefaPorTitulo(string titulo)
        {

            var tarefas = _context.Tarefas.Where(tarefa => tarefa.Titulo.Contains(titulo)).ToList();


            return View("Detalhes", tarefas);
        }

        public IActionResult ObterPorData()
        {
            return View();
        }


        public IActionResult TarefaPorData(DateTime data)
        {

            var tarefas = _context.Tarefas.Where(tarefa => tarefa.Data.Date == data.Date).ToList();

            return View("Detalhes", tarefas);
        }

        public IActionResult ObterPorStatus()
        {
            return View();
        }

        public IActionResult TarefaPorStatus(EnumStatusTarefa status)
        {
            var tarefas = _context.Tarefas.Where(tarefa => tarefa.Status == status).ToList();
            
            return View("Detalhes", tarefas);
        }
        
    }
}