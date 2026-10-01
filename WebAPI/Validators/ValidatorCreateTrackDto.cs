using FluentValidation;
using Tracks;

namespace WebAPI.Validators;

public class ValidatorCreateTrackDto 
    : AbstractValidator<CreateTrackRequest>
{
    public ValidatorCreateTrackDto()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Название трека не должно быть пустым")
            .MaximumLength(100).WithMessage("Название слишком длинное");

        RuleFor(x => x.AlbumId)
            .NotEmpty()
            .WithMessage("У трека должен быть рериз которому он пренадлежит");

        RuleFor(x => x.Duration)
        .GreaterThan(0)
        .WithMessage("Длительность должна быть больше нуля");

        RuleFor(x => x.FileId)
            .NotEmpty()
            .WithMessage("");
    }
}
