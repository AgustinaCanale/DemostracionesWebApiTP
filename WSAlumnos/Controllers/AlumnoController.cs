using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WSAlumnos.Models;
using System.Linq;

namespace WSAlumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private List<Alumno> Listado()
        {
            List<Alumno> alumnos = new List<Alumno>()
            {
                new Alumno () {Id=1, Apellido="Perez", Nombre="Maria"},

                new Alumno () {Id=2, Apellido="Rojo", Nombre="Luis"},

               new Alumno () {Id=3, Apellido="Gomez", Nombre="Marta"}
            };
            return alumnos;
        }
        //GET api/Alumno
        [HttpGet]
        public IEnumerable <Alumno> Get() {
        return Listado();   
        }

        [HttpGet("{id}")]
        public IEnumerable<Alumno> GetById(int id)
        {
            var alumno = (from a in Listado()
                         where a.Id == id
                         select a).ToList();
            return Listado();
        }

    }
}
