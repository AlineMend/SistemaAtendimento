using System.Collections;
using System.Collections.Generic;
namespace API.Models
{
    public class Gestor
    {
        public Gestor()
        {
        }

        public Gestor(int id, string nome, string senha)
        {
            this.Id = id;
            this.Nome = nome;
            this.Senha = senha;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }


        public IEnumerable<TipoDeAtendimento> TiposDeAtendimentos { get; set; }
        public IEnumerable<Tecnico> Tecnicos { get; set; }
        public Login Login { get; set; }
    }
}