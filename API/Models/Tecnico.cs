using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
namespace API.Models
{
    public class Tecnico
    {
        public Tecnico()
        {
        }

        public Tecnico(int id, string nome, string senha, bool ativo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Senha = senha;
            this.Ativo = ativo;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public Login Login { get; set; }
        public Gestor Gestor { get; set; }
        public IEnumerable<Atendimento> Atendimentos { get; set; }
    }
}