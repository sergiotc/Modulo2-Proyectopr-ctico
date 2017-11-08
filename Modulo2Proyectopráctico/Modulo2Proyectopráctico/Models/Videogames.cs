namespace Modulo2Proyectopráctico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class Videogames
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string publisher { get; set; }

        public int year { get; set; }

        public int genre { get; set; }
        public Genre Genre()
        {
            return (Genre)this.genre;
        }

        public int platfrom { get; set; }
        public Platfrom Platfrom()
        {
            return (Platfrom)this.platfrom;
        }
        public int score{get; set;}
        

        public bool online { get; set; }

        public int pegi { get; set; }
        public PEGI PEGI()
        {
            return (PEGI)this.pegi;
        }
        public static List<Videogames> SelectAll()
        {
            List<Videogames> Videogame = new List<Videogames>();
            try
            {
                VideogameContext context = new VideogameContext();
                Videogame = context.Videogames.OrderBy(x => x.name).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return Videogame;
        }
        public static Videogames Get(int id)
        {
            Videogames Videogame = new Videogames();
            try
            {
                VideogameContext context = new VideogameContext();
                Videogame = context.Videogames.Where(x => x.id == id).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return Videogame;

        }
        public void Save()
        {
            bool create = this.id == 0;
            try
            {
                VideogameContext context = new VideogameContext();
                if (create)
                {
                    context.Entry(this).State = System.Data.Entity.EntityState.Added;
                }
                else
                {
                    context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                }
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Remove()
        {
            try
            {
                VideogameContext context = new VideogameContext();
                context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Videogames> Ranking()
        {
            List<Videogames> ranking = new List<Videogames>();
            try
            {
                VideogameContext context = new VideogameContext();
                ranking = context.Videogames.OrderByDescending(x => x.score).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return ranking;
        }
    }
}
