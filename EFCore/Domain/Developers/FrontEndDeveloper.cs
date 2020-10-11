using EFCore.Domain.Enums;
using EFCore.Domain.ValueObjects;
using FluentValidation;
using System;

namespace EFCore.Domain.Developers
{
    public class FrontEndDeveloper : Developer
    {
        public FrontEndDeveloper(DevCode id, string name, DevType devType, bool mobileStack, string frameworkPreference) : base()
        {
            Id = id;
            Name = name;
            DevType = devType;
            MobileStack = mobileStack;
            FrameworkPreference = frameworkPreference;
        }

        public bool MobileStack { get; protected set; }
        public string FrameworkPreference { get; protected set; }

        public override void HowIAm()
        {
            Console.WriteLine($"I'm a {nameof(FrontEndDeveloper)} and my framework preference is {FrameworkPreference}.");
        }

        public override bool IsValid()
        {
            Validator.RuleFor(e => e.DevType).Must(e => e == DevType.FrontEnd).WithMessage("Must be a FrontEnd Developer");
            return base.IsValid();
        }
    }
}
