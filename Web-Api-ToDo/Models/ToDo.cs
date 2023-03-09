using System;
using Web_Api_ToDo.Exceptions;

namespace Web_Api_ToDo.Models
{
    public class ToDo
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public bool Concluido { get; private set; }
        public DateTime? DataCadastro { get; private set; }
        public DateTime? DataConclusao { get; private set; }

        public ToDo(int id, string titulo, string descricao)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Concluido = false;
            DataCadastro = DateTime.Now;

            ValidarDominio(titulo, descricao);
        }

        public void ConcluirTarefa()
        {
            Concluido = true;
            DataConclusao = DateTime.Now;
        }

        private void ValidarDominio(string titulo, string descricao)
        {
            ValidationDomainException.Validar(titulo.Length == 0, "Titulo é obrigatório");
            ValidationDomainException.Validar(titulo.Length <= 3, "para criar uma tarefa, o titulo é obrigatorio a ter mais de 3 caracteres");
            ValidationDomainException.Validar(titulo.Length >= 50, "para criar uma tarefa, o titulo devéra ter no máximo 50 caracteres");

            ValidationDomainException.Validar(descricao.Length == 0, "Descrição é obrigatório");
            ValidationDomainException.Validar(descricao.Length <= 3, "para criar uma descrição, ela devera ter mais de 10 caracteres");
        }
    }
}
