using EFCore.Domain.Entity;
using EFCore.Domain.ValueObjects;

namespace EFCore.Domain.Motivations
{
    public class Motivation : Identity<Motivation, long>
    {
        public Motivation(string factor, DevCode developerId)
        {
            Factor = factor;
            DeveloperId = developerId;
        }

        protected Motivation() { }

        public string Factor { get; protected set; }
        public DevCode DeveloperId { get; protected set; }
    }
}
