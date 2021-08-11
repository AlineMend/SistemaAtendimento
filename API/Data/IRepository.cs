using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface IRepository
    {
        void Add<T> (T entity) where T : class;
        void Update<T> (T entity) where T : class;
        void Delete<T> (T entity) where T : class; 
        Task<bool> SaveChangesAsync();

        Task<Atendimento[]> GetAllAtendimentoAsync();
        Task<Atendimento> GetAtendimentoAsyncById(int atendimentoId);
        Task<Atendimento> GetAtendimentoAsyncByNomeCliente(string nomeCliente);
        Task<Atendimento> GetAtendimentoAsyncByTecnicoNome(string tecnicoNome);
        Task<Atendimento> GetAtendimentoAsyncByTipoDeAtendimentoTipo(string tipoDeAtendimentoTipo);

        Task<Tecnico[]> GetAllTecnicoAsync();
        Task<Tecnico> GetTecnicoAsyncById(int tecnicoId);
        Task<Tecnico> GetTecnicoAsyncByNome(string tecnicoNome);

        Task<TipoDeAtendimento[]> GetAllTipoDeAtendimentoAsync();
        Task<TipoDeAtendimento> GetTipoDeAtendimentoAsyncById(int tipoDeAtendimentoId);
        Task<TipoDeAtendimento> GetTipoDeAtendimentoAsyncByTipo(string tipoDeAtendimentocoTipo);

        Task<Gestor[]> GetAllGestorAsync();

    }
}