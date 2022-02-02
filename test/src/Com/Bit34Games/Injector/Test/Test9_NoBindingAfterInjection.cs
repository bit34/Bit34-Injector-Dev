using Xunit;
using Com.Bit34Games.Injector.Error;
using Com.Bit34Games.Injector.Test.Payloads;
using Com.Bit34Games.Injector.Test.Containers;

namespace Com.Bit34Games.Injector.Test
{
    public class Test9_NoBindingAfterInjection
    {
        [Fact]
        public void Test_Error_BindingAfterGetInstance()
        {
            InjectorContext injector = new InjectorContext();

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
            InjectorContext injector = new InjectorContext();

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
