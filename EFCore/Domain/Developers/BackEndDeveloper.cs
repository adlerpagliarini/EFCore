using EFCore.Domain.Enums;
using EFCore.Domain.ValueObjects;
using FluentValidation;
using System;

namespace EFCore.Domain.Developers
{
    public class BackEndDeveloper : Developer
    {
        public BackEndDeveloper(DevCode id, string name, DevType devType, bool databaseStack, string databasePreference) : base()
        {
            Id = id;
            Name = name;
            DevType = devType;
            DatabaseStack = databaseStack;
            DatabasePreference = databasePreference;
        }

        public bool DatabaseStack { get; protected set; }
        public string DatabasePreference { get; protected set; }

        public override void HowIAm()
        {
            Console.WriteLine($"I'm a {nameof(BackEndDeveloper)} and I've preference for {DatabasePreference} databases.");
        }

        public override bool IsValid()
        {
            Validator.When(e => ((BackEndDeveloper)e).DatabaseStack, () =>
            {
                Validator.RuleFor(e => ((BackEndDeveloper)e).DatabasePreference).NotEmpty().WithMessage("Set Database Preference");
            });
            Validator.RuleFor(e => e.DevType).Must(e => e == DevType.BackEnd).WithMessage("Must be a BackEnd Developer");
            return base.IsValid();
        }
    }
}
