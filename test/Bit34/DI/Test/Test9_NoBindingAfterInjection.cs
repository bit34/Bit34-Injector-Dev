using Xunit;
using Com.Bit34Games.DI.Error;
using Com.Bit34Games.DI.Test.Payloads;
using Com.Bit34Games.DI.Test.Containers;

namespace Com.Bit34Games.DI.Test
{
    public class Test9_NoBindingAfterInjection
    {
        [Fact]
        public void Test_Error_BindingAfterGetInstance()
        {
            Injector injector = new Injector();

            //  Add a bindings
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassA>();

            //  Validate bindings
            Assert.Equal(1,injector.BindingCount);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);

            //  Get instance
            injector.GetInstance<SimpleClassA>();

            //  Try adding a new binding
            injector.AddBinding<SimpleClassB>();

            //  Check error
            Assert.Equal(1,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.BindingAfterInjection, injector.GetError(0).error);
        }
        
        [Fact]
        public void Test_Error_BindingAfterInjectInto()
        {
            Injector injector = new Injector();

            //  Add a bindings
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassA>();

            //  Validate bindings
            Assert.Equal(1,injector.BindingCount);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);

            //  Get instance
            var value = new ClassThatUses_SimpleClassA();
            injector.InjectInto(value);

            //  Try adding a new binding
            injector.AddBinding<SimpleClassB>();

            //  Check error
            Assert.Equal(1,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.BindingAfterInjection, injector.GetError(0).error);
        }
    }
}
