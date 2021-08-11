namespace API.Models
{
    public class Login
    {
        public Login(int tecnicoId, string tecnicoSenha, int gestorId, string gestrorSenha)
        {
            this.TecnicoId = tecnicoId;
            this.TecnicoSenha = tecnicoSenha;
            this.GestorId = gestorId;
            this.GestrorSenha = gestrorSenha;

        }
        public int TecnicoId { get; set; }
        public string TecnicoSenha { get; set; }
        public Tecnico Tecnico { get; set; }

        public int GestorId { get; set; }
        public string GestrorSenha { get; set; }
        public Gestor Gestor { get; set; }
    }
}