using System;

namespace Web_Api_ToDo.Exceptions
{
    public class ValidationDomainException : Exception
    {
        public ValidationDomainException(string mensagem) : base(mensagem)
        {

        }

        public static void Validar(bool validacao, string erro)
        {
            if (validacao)
            {
                throw new ValidationDomainException(erro);
            }
        }
    }
}
