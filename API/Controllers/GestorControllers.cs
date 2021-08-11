using System;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GestorControllers : ControllerBase
    {
        private readonly IRepository _repo;

        public GestorControllers(IRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Buscar o gestor.
        /// </summary>
        /// <param name="Todos os Gestores">Retorna  o gestor</param>
        /// <response code="200">Retorna os compromissos</response>
        /// <response code="400">Caso não haja nenhum compromisso</response>

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllGestorAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

         /// <summary>
        /// Alterar o gestor
        /// </summary>
        /// <param name="model">Novos dados para alterar o gestor</param>
        /// <response code="200">Cao o compromisso seja atualizado com sucesso</response>
        /// <response code="400">Caso não exista um compromisso com este Id</response>   

        [HttpPut]
        public async Task<IActionResult> put( Gestor model)
        {
            try
            {
                var gestor = await _repo.GetAllGestorAsync();
                if(gestor == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

    }
}