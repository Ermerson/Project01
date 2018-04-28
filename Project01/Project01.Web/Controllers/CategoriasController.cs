using Project01.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project01.Web.Controllers
{
    public class CategoriasController : Controller
    {

        // -  Utilitario - Temporario
        private static IList<Categoria> categorias
            = new List<Categoria>()
            {
                new Categoria()
                {
                    CategoriaId = 1,
                    Nome = "Notebooks"
                },
                new Categoria()
                {
                    CategoriaId =2,
                    Nome = "Impressoras"
                },
                new Categoria()
                {
                    CategoriaId = 3,
                    Nome = "Gabinetes"
                },
                new Categoria()
                {
                    CategoriaId = 4,
                    Nome = "Monitores"
                },
                new Categoria()
                {
                    CategoriaId = 5,
                    Nome = "Mouses"
                }
            };

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Categorias
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categorias.Add(categoria);
            categoria.CategoriaId =
                categorias.Select(m => m.CategoriaId).Max() + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(categorias.Where(
                m => m.CategoriaId == id).First());
        }

        public ActionResult Delete(long id)
        {
            categorias.Remove(categorias.Where(
                m => m.CategoriaId == id).First());
            return RedirectToAction("Index");
        }
    }
}