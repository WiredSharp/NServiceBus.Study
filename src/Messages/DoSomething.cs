using NServiceBus;

namespace Messages
{
    public class DoSomething: ICommand
    {
        public string SomeProperty { get; set; }

        public override string ToString()
        {
            return $"{nameof(DoSomething)} {SomeProperty ?? "<null>"}";
        }
    }
}
