using FluentValidation;

namespace EFCore.Domain
{
    public class ValueObjectValidator<TObject>: AbstractValidator<TObject> 
        where TObject : ValueObject<TObject>
    {

    }
}
