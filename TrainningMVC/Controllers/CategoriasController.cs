using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainningMVC.Models;

namespace TrainningMVC.Controllers
{
    public class CategoriasController : Controller
    {
        public static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria()
            {
                CategoriaId = 1,
                Nome="Notebooks"
            },
            new Categoria()
            {
                CategoriaId = 2,
                Nome="Monitores"
            },
            new Categoria()
            {
                CategoriaId = 3,
                Nome="Impressoras"
            },
            new Categoria()
            {
                CategoriaId = 4,
                Nome="Mouses"
            },
            new Categoria()
            {
                CategoriaId = 5,
                Nome="Desktops"
            },


        };
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias.OrderBy(c => c.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        // GET: Create
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
            return View(categorias.Where(m => m.CategoriaId ==id).First());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == c.CategoriaId).First());
            categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == c.CategoriaId).First());
            return RedirectToAction("Index");
        }
    }
}