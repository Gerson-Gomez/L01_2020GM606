using L01_2020GM606.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2020GM606.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pedidos_Controller : ControllerBase
    {
        private readonly RestauranteDB_Context _conPedidos;
        public pedidos_Controller(RestauranteDB_Context pedioss) { 
            _conPedidos = pedioss;
        }
        ////////////////////////////////////////////////////////////
        //selecciona todo de la tabla 
        [HttpGet]
        [Route("Ver Todo")]
        public IActionResult Get()
        {
            List<m_pedidos> resull = (from e in _conPedidos.pedidos
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
        ////////////////////////////////////////////////////////////
        ///FUNCION DE AGREGAR REGISTROS.
        [HttpPost]
        [Route("Agregar registro")]
        public IActionResult Crear([FromBody] m_pedidos nuevos_pedidos)
        {
            try
            {

                _conPedidos.pedidos.Add(nuevos_pedidos);
                _conPedidos.SaveChanges();
                return Ok(nuevos_pedidos);
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
        public IActionResult actualizarEquipo(int id, [FromBody] m_pedidos mod_pedidos)
        {
            m_pedidos? pedido_Existe = (from e in _conPedidos.pedidos
                                      where e.pedidoId == id
                                      select e).FirstOrDefault();

            if (pedido_Existe == null) return NotFound();

            //solo tiene permisos de cambiar estos datos 
            //se pueden poner los demas parametros de la tabla 
            pedido_Existe.motoristaId = mod_pedidos.motoristaId;
            pedido_Existe.precio = mod_pedidos.precio;
            pedido_Existe.clienteId = mod_pedidos.clienteId;
            pedido_Existe.platoId = mod_pedidos.platoId;
            pedido_Existe.cantidad = mod_pedidos.cantidad;
            pedido_Existe.precio = mod_pedidos.precio;

            _conPedidos.Entry(pedido_Existe).State = EntityState.Modified;
            _conPedidos.SaveChanges();
            return Ok(pedido_Existe);
        }
        ////////////////////////////////////////////////////////////
        ///metodo para modificar estado de elimindo
        [HttpDelete]
        [Route("Eliminar ")]
        public IActionResult Eliminar(int id)
        {
            m_pedidos epedidos_Existe = (from e in _conPedidos.pedidos
                                        where e.pedidoId == id
                                      select e).FirstOrDefault();

            if (epedidos_Existe == null) return NotFound();
            _conPedidos.pedidos.Attach(epedidos_Existe);
            _conPedidos.pedidos.Remove(epedidos_Existe);
            _conPedidos.SaveChanges();
            return Ok(epedidos_Existe);
        }
        //selecciona segun el id especificado.
        [HttpGet]
        [Route("Buscar por ID cliente")]
        public IActionResult getbyid(int id)
        {
            m_pedidos? id_existe = (from e in _conPedidos.pedidos
                                       where e.clienteId == id
                                       select e).FirstOrDefault();

            if (id_existe == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(id_existe);
            }
        }
        ////////////////////////////////////////////////////////////
        [HttpGet]
        [Route("Buscar por ID Motorista")]
        public IActionResult getbyid2(int id)
        {
            m_pedidos? idm_existe = (from e in _conPedidos.pedidos
                                     where e.motoristaId == id
                                     select e).FirstOrDefault();

            if (idm_existe == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(idm_existe);
            }
        }
        ////////////////////////////////////////////////////////////
    }
}