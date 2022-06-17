using FluentValidation;
using ClienteApi.Models;

namespace ClienteApi.Validacao
{
    public class AddClienteValidator : AbstractValidator<Cliente>
    {
        public AddClienteValidator()
        {
            //Validação Nome
            RuleFor(m => m.Nome)
                .NotEmpty()
                .WithMessage("Nome não encontrado")
                .MaximumLength(50)
                .WithMessage("máximo de caracteres 50")
                .MinimumLength(5)
                .WithMessage("Mínino de caracteres 5");

            //Validação CPF
            RuleFor(m => m.Cpf)
                .NotEmpty().NotNull()
                    .WithMessage("Por favor digite um cpf")
                .MaximumLength(11)
                    .WithMessage(" não pode passar de 11 caracteres")
                .Matches("[0-9]{11}")
                    .WithMessage("CPF Inválido");

            //Validação E-mail
            RuleFor(m => m.Email)
                .NotEmpty().NotNull()
                    .WithMessage("por favor insira um e-mail")

                 .EmailAddress()
                    .WithMessage("E-mail inválido!");

            //Validação Contato
            RuleFor(m => m.Contato)
              .NotEmpty().NotNull()
                 .WithMessage("Por favor digite um telefone")
                .MaximumLength(11)
                    .WithMessage(" Não pode passar de 11 numeros")
                .Matches("[0-9]{11}")
                    .WithMessage("Telefone Inválido");


        }
    }
}
  