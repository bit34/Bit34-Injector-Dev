using Com.Bit34Games.Injector.Test.Payloads;

namespace Com.Bit34Games.Injector.Test.Containers
{
    class ClassThatUses_SimpleInterfaceA
    {
        [Inject] public ISimpleInterfaceA value;

        public ClassThatUses_SimpleInterfaceA(){value = null;}
    }
}
