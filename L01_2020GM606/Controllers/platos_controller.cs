using L01_2020GM606.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2020GM606.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class platos_controller : ControllerBase
    {
        private readonly RestauranteDB_Context _platos;
        
        public platos_controller (RestauranteDB_Context platos)
        {
            _platos = platos;
        }

        ////////////////////////////////////////////////////////////
        //selecciona todo de la tabla 
        [HttpGet]
        [Route("Ver Todo")]
        public IActionResult Get()
        {
            List<p_platos> mi_lista = (from e in _platos.platos
                                          //where e.estado == "A"
                                          select e).ToList();
            if (mi_lista.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(mi_lista);
            }
        }
        ////////////////////////////////////////////////////////////
        //Consulta segun filtro en las columna nombre 
        [HttpGet]
        [Route("Buscar por palabra clave")]
        public IActionResult burcar(string filtro)
        {
            List<p_platos> lista_plato = (from e in _platos.platos
                                               where (e.nombrePlato.Contains(filtro))
                                               select e).ToList();
            //mas rapido y mejor para no evaluar todos los registros
            if (lista_plato.Any())
            {
                return Ok(lista_plato);
            }
            else
            {
                return NotFound();
            }
        }
        ////////////////////////////////////////////////////////////
        ///FUNCION DE AGREGAR REGISTROS.
        [HttpPost]
        [Route("Agregar registro")]
        public IActionResult Crear([FromBody] p_platos nuevo_plato)
        {
            try
            {

                _platos.platos.Add(nuevo_plato);
                _platos.SaveChanges();
                return Ok(nuevo_plato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        ////////////////////////////////////////////////////////////
        // FUNCION DE ACTUALIZAR REGISTROS
        [HttpPut]
        [Route("Actualizar registro")]
        public IActionResult actualizarEquipo(int id, [FromBody] p_platos eqmodificar)
        {
            p_platos? plato_Existe = (from e in _platos.platos
                                         where e.platoId == id
                                         select e).FirstOrDefault();

            if (plato_Existe == null) return NotFound();

            //solo tiene permisos de cambiar estos datos 
            //se pueden poner los demas parametros de la tabla 
            plato_Existe.nombrePlato = eqmodificar.nombrePlato;
            plato_Existe.precio = eqmodificar.precio;

            _platos.Entry(plato_Existe).State = EntityState.Modified;
            _platos.SaveChanges();
            return Ok(plato_Existe);
        }
        ////////////////////////////////////////////////////////////
        ///metodo para modificar estado de elimindo
        [HttpDelete]
        [Route("Eliminar estado")]
        public IActionResult Eliminar(int id)
        {
            p_platos platos_Existe = (from e in _platos.platos
                                         where e.platoId == id
                                     select e).FirstOrDefault();

            if (platos_Existe == null) return NotFound();
            _platos.platos.Attach(platos_Existe);
            _platos.platos.Remove(platos_Existe);
            _platos.SaveChanges();
            return Ok(platos_Existe);
        }
    }

}
