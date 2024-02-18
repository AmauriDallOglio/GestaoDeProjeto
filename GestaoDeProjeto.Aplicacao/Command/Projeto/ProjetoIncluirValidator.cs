using FluentValidation;

namespace GestaoDeProjeto.Aplicacao.Command
{
    public class ProjetoIncluirValidator : AbstractValidator<ProjetoIncluirRequest>
    {
        public ProjetoIncluirValidator()
        {
            RuleFor(request => request.NomeProjeto)
                .NotEmpty().WithMessage("Nome do projeto é obrigatório")
                .Length(5, 50).WithMessage(string.Format("Digite no minino 5 caracter", "Nome do projeto", 5, 50));
 
        }
    }
}
