using NServiceBus;

namespace Messages
{
    public class DoSomethingElse : ICommand
    {
        public string SomeProperty { get; set; }

        public override string ToString()
        {
            return $"{nameof(DoSomethingElse)} {SomeProperty ?? "<null>"}";
        }
    }
}
