using Bit34.DI.Test.Payloads;

namespace Bit34.DI.Test.Containers
{
    class ClassThatUses_SimpleInterfaceA
    {
        [Inject] public ISimpleInterfaceA value;

        public ClassThatUses_SimpleInterfaceA(){value = null;}
    }
}
