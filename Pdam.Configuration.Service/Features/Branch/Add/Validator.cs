using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Pdam.Common.Shared.Fault;

namespace Pdam.Configuration.Service.Features.Branch.Add
{
    public class Validator : AbstractValidator<Request>, IRequestValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.CompanyCode).NotEmpty().WithMessage("Kode Perusahaan tidak boleh kosong");
            RuleFor(x => x.BranchCode).NotEmpty().WithMessage("Kode cabang tidak boleh kosong");
            RuleFor(x => x.BranchName).NotEmpty().WithMessage("Nama cabang tidak boleh kosong");
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