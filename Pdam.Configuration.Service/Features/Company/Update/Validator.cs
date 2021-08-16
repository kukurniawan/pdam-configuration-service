using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Pdam.Common.Shared.Fault;
using Pdam.Configuration.Service.DataContext;

namespace Pdam.Configuration.Service.Features.Company.Update
{
    public class Validator : AbstractValidator<Request>, IRequestValidator<Request>
    {
        public Validator(ConfigContext context)
        {
            RuleFor(x => x.CompanyCode).NotEmpty().WithMessage("Kode Perusahaan tidak boleh kosong");
        }
        public new async Task<ValidationResult> Validate(Request request)
        {
            var g = await ValidateAsync(request);
            if (g.IsValid) return ValidationResult.Ok();
            var message = $"Errors: {string.Join(",", g.Errors.Select(x => x.ErrorMessage))}";
            return ValidationResult.Error(message);
        }

        public int Order { get; } = 1;
    }
}