using L01_2020GM606.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2020GM606.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clientes_Controller : ControllerBase
    {
        private readonly RestauranteDB_Context _conClientes;
        public clientes_Controller(RestauranteDB_Context clientes) 
        { 
            _conClientes = clientes;
        }
        ////////////////////////////////////////////////////////////
        //selecciona todo de la tabla 
        [HttpGet]
        [Route("Ver Todo")]
        public IActionResult Get()
        {
            List<m_clientes> resull = (from e in _conClientes.clientes
                                      select e).ToList();
            if (resull.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(resull);
            }
        }
        ////////////////////////////////////////////////////////////
        ///FUNCION DE AGREGAR REGISTROS.
        [HttpPost]
        [Route("Agregar registro")]
        public IActionResult Crear([FromBody] m_clientes nuevos_cli)
        {
            try
            {

                _conClientes.clientes.Add(nuevos_cli);
                _conClientes.SaveChanges();
                return Ok(nuevos_cli);
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
        public IActionResult actualizarEquipo(int id, [FromBody] m_clientes mod_clie)
        {
            m_clientes? cli_Existe = (from e in _conClientes.clientes
                                         where e.clienteId == id
                                        select e).FirstOrDefault();

            if (cli_Existe == null) return NotFound();

            //solo tiene permisos de cambiar estos datos 
            //se pueden poner los demas parametros de la tabla 
            cli_Existe.nombreCliente = mod_clie.nombreCliente;
            cli_Existe.direccion = mod_clie.direccion;

            _conClientes.Entry(cli_Existe).State = EntityState.Modified;
            _conClientes.SaveChanges();
            return Ok(cli_Existe);
        }
        ////////////////////////////////////////////////////////////
        ///metodo para modificar estado de elimindo
        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult Eliminar(int id)
        {
            m_clientes? id_exist = (from e in _conClientes.clientes
                                   where e.clienteId == id
                                         select e).FirstOrDefault();

            if (id_exist == null) return NotFound();
            _conClientes.clientes.Attach(id_exist);
            _conClientes.clientes.Remove(id_exist);
            _conClientes.SaveChanges();
            return Ok(id_exist);
        }

        // consulta segun filtro en las columnas nombre y descripcion
        [HttpGet]
        [Route("Buscar por palabra clave")]
        public IActionResult burcar(string filtro)
        {
            List<m_clientes> key_lista = (from e in _conClientes.clientes
                                              where (e.direccion.Contains(filtro))
                                               select e).ToList();
            //mas rapido y mejor para no evaluar todos los registros
            if (key_lista.Any())
            {
                return Ok(key_lista);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
