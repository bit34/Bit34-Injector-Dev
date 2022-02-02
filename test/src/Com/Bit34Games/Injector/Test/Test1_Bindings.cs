using Xunit;
using Com.Bit34Games.Injector.Error;
using Com.Bit34Games.Injector.Test.Payloads;

namespace Com.Bit34Games.Injector.Test
{
    public class Test1_Bindings
    {
        [Fact]
        public void Test_AddingBindings()
        {
            InjectorContext injector = new InjectorContext();

            //  Add first binding
            injector.AddBinding<SimpleClassA>();

            //  Validate binding
            Assert.Equal(1,injector.BindingCount);
            Assert.True(injector.HasBindingForType(typeof(SimpleClassA)));

            //  Check error
            Assert.Equal(0,injector.ErrorCount);

            //  Add second binding
            injector.AddBinding<SimpleClassB>();

            //  Validate binding
            Assert.Equal(2,injector.BindingCount);
            Assert.True(injector.HasBindingForType(typeof(SimpleClassA)));
            Assert.True(injector.HasBindingForType(typeof(SimpleClassB)));
            
            //  Check error
            Assert.Equal(0,injector.ErrorCount);
        }

        [Fact]
        public void Test_Error_ReAddingExistingBindings()
        {
            InjectorContext injector = new InjectorContext();

            //  Add two bindings
            injector.AddBinding<SimpleClassA>();
            injector.AddBinding<SimpleClassB>();

            //  Validate bindings
            Assert.Equal(2,injector.BindingCount);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);

            //  Try re-adding first binding
            injector.AddBinding<SimpleClassA>();

            //  Check error
            Assert.Equal(1,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.AlreadyAddedBindingForType, injector.GetError(0).error);

            //  Try re-adding second binding
            injector.AddBinding<SimpleClassB>();

            //  Check error
            Assert.Equal(2,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.AlreadyAddedBindingForType, injector.GetError(1).error);
        }
    }
}
