using System;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TecnicoControllers : ControllerBase
    {
        private readonly IRepository _repo;

        public TecnicoControllers(IRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Buscar os técnicos.
        /// </summary>
        /// <param name="Todos os Técnicos">Retorna todos os técnicos</param>
        /// <response code="200">Retorna os técnicos</response>
        /// <response code="400">Caso não haja nenhum técnico</response>

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllTecnicoAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Buscar técnico pelo seu Id
        /// </summary>
        /// <param name="Técnico Id">Id do técnico buscado</param>
        /// <response code="200">Retorna o técnico  filtrado</response>
        /// <response code="400">Caso não haja nenhum técnico  com este id</response> 

        [HttpGet("{tecnicoId}")]
        public async Task<IActionResult> GetTecnicoAsyncById(int tecnicoId)
        {
            try
            {
                var result = await _repo.GetTecnicoAsyncById(tecnicoId);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Buscar técnico pelo seu nome
        /// </summary>
        /// <param name="Técnico Nome">Nome do técnico buscado</param>
        /// <response code="200">Retorna o técnico  filtrado</response>
        /// <response code="400">Caso não haja nenhum técnico  com este nome</response> 

        [HttpGet("{tecnicoNome}")]
        public async Task<IActionResult> GetTecnicoAsyncByNome(string tecnicoNome)
        {
            try
            {
                var result = await _repo.GetTecnicoAsyncByNome(tecnicoNome);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Adicionar um novo técnico
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Modelo
        ///     {
        ///        "Nome": "Francisco Couto",
        ///        "Senha": "asd123",
        ///        "Ativo": "true"
        ///     }
        /// </remarks>
        /// <param name="model">Dados do técnico a ser inserido</param>
        /// <response code="200">Caso o técnico seja inserido com sucesso</response>
        /// <response code="400">Caso já exista um técnico com o mesmo nome</response>

        [HttpPost]
        public async Task<IActionResult> post(Tecnico model)
        {
            try
            {
                _repo.Add(model);

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

         /// <summary>
        /// Atualizar e/ou desativar um técnico
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Modelo
        ///     {
        ///        "Nome": "Francisco Couto",
        ///        "Senha": "asd123",
        ///        "Ativo": "true"
        ///     }
        /// </remarks>
        /// /// <param name="Técnico Nome">Nome do técnico  a ser atualizado</param>
        /// <param name="model">Novos dados para atualizar o técnico indicado</param>
        /// <response code="200">Caso o técnico seja atualizado com sucesso</response>
        /// <response code="400">Caso não exista um técnico com este nome</response>   

        [HttpPut("{tecnicoNome}")]
        public async Task<IActionResult> put(string tecnicoNome, Tecnico model)
        {
            try
            {
                var tecnico = await _repo.GetTecnicoAsyncByNome(tecnicoNome);
                if(tecnico == null) return NotFound();

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

         /// <summary>
        /// Excluir um técnico
        /// </summary>
        /// /// <param name="Técnico Nome">Nome do técnico a ser excluído</param>
        /// <response code="200">Caso o técnico seja excluido com sucesso</response>
        /// <response code="400">Caso não exista um técnico com este nome</response>  

        [HttpDelete("{tecnicoNome}")]
        public async Task<IActionResult> delete(string tecnicoNome)
        {
            try
            {
                var tecnico = await _repo.GetTecnicoAsyncByNome(tecnicoNome);
                if(tecnico == null) return NotFound();

                _repo.Delete(tecnico);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok("Deletado");
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