namespace EFCore.Domain.Motivations
{
    public class ExtraMotivation
    {
        public ExtraMotivation(string factor)
        {
            Factor = factor;
        }

        protected ExtraMotivation() { }

        public string Factor { get; protected set; }
    }
}
