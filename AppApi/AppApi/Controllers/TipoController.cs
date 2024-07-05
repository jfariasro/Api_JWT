using AppApi.Models;
using AppApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoController : ControllerBase
    {
        private readonly IGenericService<Tipo> _service;

        public TipoController(IGenericService<Tipo> service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> RegistrarTipo([FromBody] Tipo model)
        {
            if(!ModelState.IsValid)
                return BadRequest(new { Error = "La solicitud contiene datos no válidos", Detalles = model });

            try
            {
                var res = await _service.Registrar(model);

                return (!res) ?
                    BadRequest(new { Error = "La solicitud no fue procesada", Valor = res })
                    : Ok(new { Mensaje = "Tipo Registrado de Forma Exitosa", Valor = res });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "La solicitud obtuvo un error en el proceso", Detalles = ex.Message });
            }

        }

        [HttpPut]
        [Route("Editar/{id:int}")]
        public async Task<IActionResult> EditarTipo([FromBody] Tipo model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "La solicitud contiene datos no válidos", Detalles = ModelState });

            if (await _service.Buscar(id) == null)
                return NotFound(new { Error = "El Tipo No fue Encontrado", Id = id });

            try
            {
                var res = await _service.Editar(model, id);

                return (!res) ?
                    BadRequest(new { Error = "La solicitud no fue procesada", Valor = res })
                    : Ok(new { Mensaje = "Tipo Editado de Forma Exitosa", Valor = res });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "La solicitud obtuvo un error en el proceso", Detalles = ex.Message });
            }

        }

        [HttpGet]
        [Route("Consultar")]
        public async Task<IActionResult> ObtenerTodo()
        {
            var tipoSQL = await _service.Consultar();
            List<Tipo> listado = tipoSQL.Select(t => new Tipo()
            {
                Idtipo = t.Idtipo,
                Nombre = t.Nombre,
                Descripcion = t.Descripcion
            }).ToList();

            return (listado.Count == 0) ?
                    StatusCode(StatusCodes.Status404NotFound, new { Mensaje = "No se encontraron registros", Tipos = listado })
                    : Ok(new { Mensaje = "Tipos Obtenidos", Tipos = listado });
        }

        [HttpGet]
        [Route("Buscar/{id:int}")]
        public async Task<IActionResult> BuscarTipo([FromRoute] int id)
        {
            try
            {
                var model = await _service.Buscar(id);

                return (model == null) ?
                    NotFound(new { Error = "No se pudo encontrar el tipo", Tipo = model })
                    : Ok(new { Mensaje = "Tipo Obtenido", Tipo = model });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "La solicitud obtuvo un error en el proceso", Detalles = ex.Message });
            }

        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> EliminarTipo([FromRoute] int id)
        {
            if (await _service.Buscar(id) == null)
                return NotFound(new { Error = "El Tipo No fue Encontrado", Id = id });

            try
            {
                var res = await _service.Eliminar(id);

                return (!res) ?
                    BadRequest(new { Error = "La solicitud no fue procesada", Valor = res })
                    : Ok(new { Mensaje = "Tipo Eliminado de Forma Exitosa", Valor = res });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "La solicitud obtuvo un error en el proceso", Detalles = ex.Message });
            }

        }

    }
}
