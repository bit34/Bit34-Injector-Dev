namespace Bit34.DI.Test.Payloads
{
    class ClassThatUses_SimpleInterfaceA
    {
        [Inject]
        public ISimpleInterfaceA value;

        public ClassThatUses_SimpleInterfaceA(){value = null;}
    }
}
