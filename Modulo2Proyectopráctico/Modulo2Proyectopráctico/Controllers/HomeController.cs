using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modulo2Proyectopráctico.Models;

namespace Modulo2Proyectopráctico.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            List<Videogames> Videogame = Videogames.SelectAll();
            return View(Videogame);
        }
         public ActionResult Game(int id)
        {
            Videogames Videogame = Videogames.Get(id);
            if ( Videogame != null)
            {
                return View(Videogame);
            }
            else
            {
                return Redirect("~/");
            }

        }
        public ActionResult Remove(int id = 0)
        {
           
            Videogames Videogame = Videogames.Get(id);
            if (Videogame != null)
            {
                
                Videogame.Remove();
            }
            return Redirect("~/");
        }
        public ActionResult Newgame() //Crear.cshmtl <-- Formulario
        {
            Videogames Newgame = new Videogames();
            return View("~/Views/Home/GameForm.cshtml", Newgame);
        }
        public ActionResult Edit(int id = 0) //Modificar.cshtml
        {
            Videogames Videogame = Videogames.Get(id);
            if (Videogame == null)
            {
                return Redirect("~/crear/");
            }
            else
            {
                return View("~/Views/Home/GameForm.cshtml", Videogame);
            }
        }
        public ActionResult Guardar(Videogames Videogame)
        {
            //Guardar esos datos en db
            Videogame.Save();
            //Redireccionar a una vista
            return Redirect("~/home/game/" + Videogame.id);
        }
        public ActionResult Ranking()
        {
            List<Videogames> ranking = Videogames.Ranking();
            return View("~/Views/Home/Ranking.cshtml", ranking);
        }
    }
}