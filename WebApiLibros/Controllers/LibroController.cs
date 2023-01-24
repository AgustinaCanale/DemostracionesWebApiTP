using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {


        private readonly DBLibrosContext context;
        //contructor 
        public LibroController(DBLibrosContext context)
        {

            this.context = context;

        }


        //GET: api/autor
        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return context.Libros.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Libro> GetbyId(int id)
        {
            Libro libro = (from a in context.Libros
                           where a.Id == id
                           select a).SingleOrDefault();

            return libro;

        }




        [HttpGet("listado/{IdAutor}")]//ruta personalizada
        public ActionResult<IEnumerable<Libro>> GetIdAutor(int idautor)
        {
            List<Libro> libros = (from a in context.Libros
                                  where a.IdAutor == idautor
                                  select a).ToList();
            return libros;


        }

            [HttpPost]
        public ActionResult Post(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Libros.Add(libro);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }

            context.Entry(libro).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();

        }


        [HttpDelete("{id}")]
        public ActionResult<Libro> Delete(int id)
        {

            Libro libro = (from c in context.Libros
                               where c.Id == id
                               select c).SingleOrDefault();
            if (libro == null)
            {
                return NotFound();
            }
            context.Libros.Remove(libro);
            context.SaveChanges();
            return libro;
        }
    }







    }

