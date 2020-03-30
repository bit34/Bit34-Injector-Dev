using Com.Bit34Games.DI.Test.Payloads;

namespace Com.Bit34Games.DI.Test.Containers
{
    class ClassThatUses_SimpleInterfaceA
    {
        [Inject] public ISimpleInterfaceA value;

        public ClassThatUses_SimpleInterfaceA(){value = null;}
    }
}
