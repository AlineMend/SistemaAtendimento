namespace API.Models
{
    public class TipoDeAtendimento
    {
        public TipoDeAtendimento()
        {
        }

        public TipoDeAtendimento(int id, string tipo, bool ativo)
        {
            this.Id = id;
            this.Tipo = tipo;
            this.Ativo = ativo;

        }
        public int Id { get; set; }
        public string Tipo { get; set; }
        public bool Ativo { get; set; }
        public Gestor Gestor { get; set; }
        public Atendimento Atendimento { get; set; }
    }
}