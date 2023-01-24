using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiLibros.Data;
using WebApiLibros.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {

        private readonly DBLibrosContext context;
        //contructor 
        public AutorController(DBLibrosContext context)
        {

            this.context = context;

        }

       

        //GET: api/autor
        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get() 
        {
            return context.Autores.ToList();
        }


   




        //POST api/autor
        [HttpPost]
        public ActionResult Post(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Autores.Add(autor);
            context.SaveChanges();
            return Ok();
        }


  //UPDATE
        // PUT api/autor/2
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor autor)
        {
            if (id!=autor.IdAutor)
            {
                return BadRequest();
            }

            context.Entry(autor).State= EntityState.Modified;
            context.SaveChanges();

            return Ok();
        
        }












    }
}
