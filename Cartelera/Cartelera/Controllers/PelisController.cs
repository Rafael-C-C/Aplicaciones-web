using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebServicesDSM.Models.Response;
using WebServicesDSM.Models;
using WebServicesDSM.Models.Request;

namespace WebServicesDSM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PelisController : ControllerBase
    {
        [HttpGet]

        //Metodo para consultar datos
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PelisplusContext db= new PelisplusContext())
                {
                    var list = db.Peliculas.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = list;
                }
            }

            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        //Este metodo sirve para insertar datos
        public IActionResult Add(PelisRequest model)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PelisplusContext db = new PelisplusContext())
                {
                    Pelicula oPro = new Pelicula();
                    oPro.Titulo = model.titulo;
                    oPro.Director = model.director;
                    oPro.Genero = model.genero;
                    oPro.Rating = model.rating;
                    oPro.Año = model.año;
                    db.Peliculas.Add(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]

        //Este metodo sirve para editar los datos

        public IActionResult Edit(PelisRequest model)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PelisplusContext db = new PelisplusContext())
                {
                    Pelicula oPro = db.Peliculas.Find(model.Id);
                    oPro.Id = model.Id;
                    oPro.Titulo = model.titulo;
                    oPro.Director = model.director;
                    oPro.Genero = model.genero;
                    oPro.Rating = model.rating;
                    oPro.Año = model.año;
                    db.Entry(oPro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        //Con este metodo vamos a eliminar cualquiera que querramos
        public IActionResult Del(int Id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (PelisplusContext db = new PelisplusContext())
                {
                    Pelicula oPro = db.Peliculas.Find(Id);
                    db.Remove(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
