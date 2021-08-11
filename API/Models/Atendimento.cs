using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Atendimento
    {
        public Atendimento()
        {
        }

        public Atendimento(int id, string nomeCliente, DateTime dataExecucao, string observacao, string tipoDeAtendimentoTipo, string tecnicoNome)
        {
            this.Id = id;
            this.NomeCliente = nomeCliente;
            this.DataExecucao = dataExecucao;
            this.Observacao = observacao;
            this.TipoDeAtendimentoTipo = tipoDeAtendimentoTipo;
            this.TecnicoNome = tecnicoNome;

        }
        public int Id { get; set; }
        public string NomeCliente { get; set; }

        [Display(Name = "Data Execução")]
        [DisplayFormat(DataFormatString = "{0:f}")]
        public DateTime DataExecucao { get; set; }
        public string Observacao { get; set; }
        public string TipoDeAtendimentoTipo { get; set; }

        public IEnumerable<TipoDeAtendimento> TiposDeAtendimentos { get; set; }
        public string TecnicoNome { get; set; }
        public IEnumerable<Tecnico> Tecnicos { get; set; }

    }
}