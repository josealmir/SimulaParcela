using FluentValidation;
using SimulaParcela.Dominio.Model;

namespace SimulaParcela.Dominio.Validation
{
    public class SimualcaoValidator : AbstractValidator<Simulacao>
    {
        public SimualcaoValidator()
        {
            RuleFor(x=>x.QuantidadeDeParcela).NotNull()
                                             .WithMessage("Campo Obrigatório.");
            RuleFor(x=>x.ValorJuros).Must(MaiorQueZero)
                                    .WithMessage("Valor inválido.");
        }

        protected static bool MaiorQueZero(int value)
                  => value > 0;

    }
}
