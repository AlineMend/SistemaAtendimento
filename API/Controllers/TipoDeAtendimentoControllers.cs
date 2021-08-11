using System;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoDeAtendimentoControllers : ControllerBase
    {
        private readonly IRepository _repo;

        public TipoDeAtendimentoControllers(IRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Consultar os tipos de atendimentos.
        /// </summary>
        /// <param name="Todos os Tipos de Atendimentos">Retorna todos os atendimentos</param>
        /// <response code="200">Retorna os compromissosatendimentos</response>
        /// <response code="400">Caso não haja nenhum atendimento</response>

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllTipoDeAtendimentoAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Consultar o tipo de atendimento por Id
        /// </summary>
        /// <param name="Tipo de Atendimento Id">Id do tipo de atendimento</param>
        /// <response code="200">Retorna o atendimento  filtrado</response>
        /// <response code="400">Caso não haja atendimento  com este id</response> 

        [HttpGet("{tipoDeAtendimentoId}")]
        public async Task<IActionResult> GetTipoDeAtendimentoAsyncById(int tipoDeAtendimentoId)
        {
            try
            {
                var result = await _repo.GetTipoDeAtendimentoAsyncById(tipoDeAtendimentoId);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        /// <summary>
        /// Consultar o tipo de atendimento por Tipo
        /// </summary>
        /// <param name="Tipo de Atendimento">Tipo do atendimento</param>
        /// <response code="200">Retorna o tipo de atendimento  filtrado</response>
        /// <response code="400">Caso não haja atendimento desse tipo</response> 

        [HttpGet("{tipoDeAtendimentoTipo}")]
        public async Task<IActionResult> GetAtendimentoAsyncByTipoDeAtendimentoTipo(string tipoDeAtendimentoTipo)
        {
            try
            {
                var result = await _repo.GetAtendimentoAsyncByTipoDeAtendimentoTipo(tipoDeAtendimentoTipo);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Adicionar um tipo de atendimento
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Modelo
        ///     {
        ///        "Id": "1",
        ///        "Tipo": "Presencial",
        ///        "Ativo": "true
        ///     }
        /// </remarks>
        /// <param name="model">Dados do tipo de atendimento a ser inserido</param>
        /// <response code="200">Caso o o tipo de atendimento seja inserido com sucesso</response>
        /// <response code="400">Caso já exista esse tipo de atendimento</response>

        [HttpPost]
        public async Task<IActionResult> post(TipoDeAtendimento model)
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
        /// Atualizar e/ou desativar um tipo de atendimento
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Modelo
        ///     {
        ///        "Id": "1",
        ///        "Tipo": "Presencial",
        ///        "Ativo": "true
        ///     }
        /// </remarks>
        /// <param name="Tipo de Atendimento Id">Id do tipo de atendimento  a ser atualizado</param>
        /// <param name="model">Novos dados para atualizar o tipo de atendimento indicado</param>
        /// <response code="200">Cao o tipo de atendimento seja atualizado com sucesso</response>
        /// <response code="400">Caso não exista um tipo de atendimento com este Id</response>   

        [HttpPut("{tipoDeAtendimentoId}")]
        public async Task<IActionResult> put(int tipoDeAtendimentoId, TipoDeAtendimento model)
        {
            try
            {
                var tipoDeAtendimento = await _repo.GetTipoDeAtendimentoAsyncById(tipoDeAtendimentoId);
                if(tipoDeAtendimento == null) return NotFound();

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
        /// Excluir um tipo de atendimento
        /// </summary>
        /// /// <param name="Tipo de Atendimento Id">Id do compromisso a ser excluído</param>
        /// <response code="200">Cao o compromisso seja excluido com sucesso</response>
        /// <response code="400">Caso não exista um compromisso com este Id</response>  

        [HttpDelete("{tipoDeAtendimentoId}")]
        public async Task<IActionResult> delete(int tipoDeAtendimentoId)
        {
            try
            {
                var tipoDeAtendimento = await _repo.GetTipoDeAtendimentoAsyncById(tipoDeAtendimentoId);
                if(tipoDeAtendimento == null) return NotFound();

                _repo.Delete(tipoDeAtendimento);

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