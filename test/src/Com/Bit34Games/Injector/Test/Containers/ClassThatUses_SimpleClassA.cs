using Com.Bit34Games.Injector.Test.Payloads;

namespace Com.Bit34Games.Injector.Test.Containers
{
    class ClassThatUses_SimpleClassA
    {
        public SimpleClassA value1 { get{ return _value1; } }
        [Inject] public SimpleClassA value2;
        [Inject] private SimpleClassA _value1;

        public ClassThatUses_SimpleClassA(){value2 = null; _value1=null;}
    }
}
