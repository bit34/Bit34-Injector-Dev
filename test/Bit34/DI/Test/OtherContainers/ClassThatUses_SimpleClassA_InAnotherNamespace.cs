using Bit34.DI.Test.Payloads;

namespace Bit34.DI.Test.OtherContainers
{
    class ClassThatUses_SimpleClassA_InAnotherNamespace
    {
#pragma warning disable 649
        [Inject] public SimpleClassA value;
#pragma warning restore 649

        public ClassThatUses_SimpleClassA_InAnotherNamespace(){ }
    }
}
