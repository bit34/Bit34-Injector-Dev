using Com.Bit34Games.Injector.Test.Payloads;

namespace Com.Bit34Games.Injector.Test.OtherContainers
{
    class ClassThatUses_SimpleClassA_InAnotherNamespace
    {
#pragma warning disable 649
        [Inject] public SimpleClassA value;
#pragma warning restore 649

        public ClassThatUses_SimpleClassA_InAnotherNamespace(){ }
    }
}
