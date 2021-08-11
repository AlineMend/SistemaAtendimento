using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
         public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Atendimento[]> GetAllAtendimentoAsync()
        {
            IQueryable<Atendimento> query = _context.Atendimentos;
            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Tecnico[]> GetAllTecnicoAsync()
        {
            IQueryable<Tecnico> query = _context.Tecnicos;
            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<TipoDeAtendimento[]> GetAllTipoDeAtendimentoAsync()
        {
            IQueryable<TipoDeAtendimento> query = _context.TiposDeAtendimento;
            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Atendimento> GetAtendimentoAsyncById(int atendimentoId)
        {
            IQueryable<Atendimento> query = _context.Atendimentos;
            query = query.AsNoTracking()
                         .OrderBy(atendimentos => atendimentos.Id)
                         .Where(atendimentos => atendimentos.Id == atendimentoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Atendimento> GetAtendimentoAsyncByNomeCliente(string nomeCliente)
        {
            IQueryable<Atendimento> query = _context.Atendimentos;
            query = query.AsNoTracking()
                         .OrderBy(atendimentos => atendimentos.NomeCliente)
                         .Where(atendimentos => atendimentos.NomeCliente == nomeCliente);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Atendimento> GetAtendimentoAsyncByTecnicoNome(string tecnicoNome)
        {
            IQueryable<Atendimento> query = _context.Atendimentos;
            query = query.AsNoTracking()
                         .OrderBy(atendimentos => atendimentos.TecnicoNome)
                         .Where(atendimentos => atendimentos.TecnicoNome == tecnicoNome);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Atendimento> GetAtendimentoAsyncByTipoDeAtendimentoTipo(string tipoDeAtendimentoTipo)
        {
            IQueryable<Atendimento> query = _context.Atendimentos;
            query = query.AsNoTracking()
                         .OrderBy(atendimentos => atendimentos.TipoDeAtendimentoTipo)
                         .Where(atendimentos => atendimentos.TipoDeAtendimentoTipo == tipoDeAtendimentoTipo);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Tecnico> GetTecnicoAsyncById(int tecnicoId)
        {
            IQueryable<Tecnico> query = _context.Tecnicos;
            query = query.AsNoTracking()
                         .OrderBy(tecnicos => tecnicos.Id)
                         .Where(tecnicos => tecnicos.Id == tecnicoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Tecnico> GetTecnicoAsyncByNome(string tecnicoNome)
        {
            IQueryable<Tecnico> query = _context.Tecnicos;
            query = query.AsNoTracking()
                         .OrderBy(tecnicos => tecnicos.Nome)
                         .Where(tecnicos => tecnicos.Nome == tecnicoNome);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TipoDeAtendimento> GetTipoDeAtendimentoAsyncById(int tipoDeAtendimentoId)
        {
            IQueryable<TipoDeAtendimento> query = _context.TiposDeAtendimento;
            query = query.AsNoTracking()
                         .OrderBy(tiposDeAtendimento => tiposDeAtendimento.Id)
                         .Where(tiposDeAtendimento => tiposDeAtendimento.Id == tipoDeAtendimentoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Gestor[]> GetAllGestorAsync()
        {
            IQueryable<Gestor> query = _context.Gestores;
            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<TipoDeAtendimento> GetTipoDeAtendimentoAsyncByTipo(string tipoDeAtendimentocoTipo)
        {
            IQueryable<TipoDeAtendimento> query = _context.TiposDeAtendimento;
            query = query.AsNoTracking()
                         .OrderBy(tiposDeAtendimento => tiposDeAtendimento.Tipo)
                         .Where(tiposDeAtendimento => tiposDeAtendimento.Tipo == tipoDeAtendimentocoTipo);

            return await query.FirstOrDefaultAsync();
        }
    }
}