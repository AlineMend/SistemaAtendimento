using System;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtendimentoControllers : ControllerBase
    {
        private readonly IRepository _repo;

        public AtendimentoControllers(IRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Buscar os atendimentos realizados.
        /// </summary>
        /// <param name="Todos os Atendimentos">Retorna todos os atendimentos</param>
        /// <response code="200">Retorna os atendimentos</response>
        /// <response code="400">Caso não haja nenhum atendimento</response>

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllAtendimentoAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Buscar um atendimento pelo seu Id
        /// </summary>
        /// <param name="Atendimento Id">Id do atendimento buscado</param>
        /// <response code="200">Retorna o atendimento  filtrado</response>
        /// <response code="400">Caso não haja atendimento  com este id</response> 

        [HttpGet("{atendimentoId}")]
        public async Task<IActionResult> GetAtendimentoAsyncById(int atendimentoId)
        {
            try
            {
                var result = await _repo.GetAtendimentoAsyncById(atendimentoId);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Buscar um atendimento pelo nome do cliente
        /// </summary>
        /// <param name="Nome Cliente">Nome do cliente do atendimento buscado</param>
        /// <response code="200">Retorna o atendimento  filtrado</response>
        /// <response code="400">Caso não haja atendimento  de cliente com este nome</response> 

        [HttpGet("{nomeCliente}")]
        public async Task<IActionResult> GetAtendimentoAsyncByNomeCliente(string nomeCliente)
        {
            try
            {
                var result = await _repo.GetAtendimentoAsyncByNomeCliente(nomeCliente);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Buscar um atendimento pelo nome do técnico
        /// </summary>
        /// <param name="Técnico Nome">Nome do técnico do atendimento buscado</param>
        /// <response code="200">Retorna o atendimento  filtrado</response>
        /// <response code="400">Caso não haja atendimento  de técnico com este nome</response> 

        [HttpGet("{tecnicoNome}")]
        public async Task<IActionResult> GetAtendimentoAsyncByTecnicoNome(string tecnicoNome)
        {
            try
            {
                var result = await _repo.GetAtendimentoAsyncByTecnicoNome(tecnicoNome);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

         /// <summary>
        /// Buscar um atendimento pelo seu tipo
        /// </summary>
        /// <param name="Tipo de Atendimento">Tipo do atendimento buscado</param>
        /// <response code="200">Retorna o atendimento  filtrado</response>
        /// <response code="400">Caso não haja atendimento  com esse tipo</response> 

        [HttpGet("{tipoDeAtendimentoTipo}")]
        public async Task<IActionResult> GetAtendimentoAsyncByTipoDeAtendimentoTipo(string tipoDeAtendimentoTipo)
        {
            try
            {
                var result = await _repo.GetAtendimentoAsyncByTecnicoNome(tipoDeAtendimentoTipo);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Adicionar um atendimento
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Modelo
        ///     {
        ///        "NomeCliente": "Maria Aparecida",
        ///        "DataExecucao": "segunda-feira, 09 de agosto de 2021 1:45 PM",
        ///        "Observacao": "Resolvido",
        ///        "TipoDeAtendimentoTipo": "Telefone",
        ///        "TecnicoNome": "Ana Couto"
        ///     }
        /// </remarks>
        /// <param name="model">Dados do atendimento a ser inserido</param>
        /// <response code="200">Caso o atendimento seja inserido com sucesso</response>
        /// <response code="400">Caso já exista este atendimento </response>

        [HttpPost]
        public async Task<IActionResult> post(Atendimento model)
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
        /// Alterar um atendimento
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Modelo
        ///     {
        ///        "NomeCliente": "Maria Aparecida",
        ///        "DataExecucao": "segunda-feira, 09 de agosto de 2021 1:45 PM",
        ///        "Observacao": "Resolvido",
        ///        "TipoDeAtendimentoTipo": "Telefone",
        ///        "TecnicoNome": "Ana Couto"
        ///     }
        /// </remarks>
        /// /// <param name="Atendimento Id">Id do atendimento  a ser atualizado</param>
        /// <param name="model">Novos dados para atualizar o atendimento indicado</param>
        /// <response code="200">Caso o atendimento seja atualizado com sucesso</response>
        /// <response code="400">Caso não exista um atendimento com este Id</response>   

        [HttpPut("{atendimentoId}")]
        public async Task<IActionResult> put(int atendimentoId, Atendimento model)
        {
            try
            {
                var atendimento = await _repo.GetAtendimentoAsyncById(atendimentoId);
                if(atendimento == null) return NotFound();

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