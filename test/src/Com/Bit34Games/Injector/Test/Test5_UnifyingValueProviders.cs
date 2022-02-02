using Xunit;
using Com.Bit34Games.Injector.Error;
using Com.Bit34Games.Injector.Test.Payloads;

namespace Com.Bit34Games.Injector.Test
{
    public class Test5_UnifyingValueProviders
    {
        [Fact]
        public void Test_UnifyTypedProvidersWithSameType()
        {
            InjectorContext injector = new InjectorContext();
            
            SimpleClassA value = new SimpleClassA();

            //  Add first binding
            injector.AddBinding<ISimpleInterfaceA>().ToValue(value);

            //  Check bindings and providers
            Assert.Equal(1, injector.BindingCount);
            Assert.Equal(1, injector.ProviderCount);

            //  Check errors
            Assert.Equal(0, injector.ErrorCount);

            //  Add second binding to same value
            injector.AddBinding<ISimpleInterfaceAA>().ToValue(value);
            
            //  Check bindings and providers
            Assert.Equal(2, injector.BindingCount);
            Assert.Equal(1, injector.ProviderCount);

            //  Check errors
            Assert.Equal(0, injector.ErrorCount);

            //  Add third binding to same value
            injector.AddBinding<SimpleClassA>().ToValue(value);
            
            //  Check bindings and providers
            Assert.Equal(3, injector.BindingCount);
            Assert.Equal(1, injector.ProviderCount);

            //  Check errors
            Assert.Equal(0, injector.ErrorCount);
        }
        
        [Fact]
        public void Test_Error_AlreadyAddedValueProviderWithDifferentProvider()
        {
            InjectorContext injector = new InjectorContext();
            
            //  Add first binding to a value
            injector.AddBinding<ISimpleInterfaceAA>().ToType<SimpleClassA>();

            //  Check bindings and providers
            Assert.Equal(1, injector.BindingCount);
            Assert.Equal(1, injector.ProviderCount);

            //  Check errors
            Assert.Equal(0, injector.ErrorCount);

            //  Add second binding with same provider type
            injector.AddBinding<ISimpleInterfaceA>().ToValue(new SimpleClassA());

            //  Check bindings and providers
            Assert.Equal(2, injector.BindingCount);
            Assert.Equal(1, injector.ProviderCount);
            
            //  Check errors
            Assert.Equal(1, injector.ErrorCount);
            Assert.Equal(InjectionErrorType.AlreadyAddedTypeWithDifferentProvider,injector.GetError(0).error);
        }

    }
}
