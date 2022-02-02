using Xunit;
using Com.Bit34Games.Injector;
using Com.Bit34Games.Injector.Error;
using Com.Bit34Games.Injector.Test.Payloads;

namespace Com.Bit34Games.Injector.Test
{
    public class Test4_UnifyingTypedProviders
    {
        [Fact]
        public void Test_UnifyTypedProvidersWithSameType()
        {
            InjectorContext injector = new InjectorContext();
            
            //  Add first binding
            injector.AddBinding<ISimpleInterfaceA>().ToType<SimpleClassA>();

            //  Check bindings and providers
            Assert.Equal(1, injector.BindingCount);
            Assert.Equal(1, injector.ProviderCount);

            //  Check errors
            Assert.Equal(0, injector.ErrorCount);

            //  Add second binding with same provider type
            injector.AddBinding<ISimpleInterfaceAA>().ToType<SimpleClassA>();
            
            //  Check bindings and providers
            Assert.Equal(2, injector.BindingCount);
            Assert.Equal(1, injector.ProviderCount);

            //  Add third binding with same provider type
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassA>();
            
            //  Check bindings and providers
            Assert.Equal(3, injector.BindingCount);
            Assert.Equal(1, injector.ProviderCount);

            //  Check errors
            Assert.Equal(0, injector.ErrorCount);
        }
        
        [Fact]
        public void Test_Error_AlreadyAddedTypedProviderWithDifferentProvider()
        {
            InjectorContext injector = new InjectorContext();
            
            //  Add first binding to a value
            injector.AddBinding<ISimpleInterfaceAA>().ToValue(new SimpleClassA());

            //  Check bindings and providers
            Assert.Equal(1, injector.BindingCount);
            Assert.Equal(1, injector.ProviderCount);

            //  Check errors
            Assert.Equal(0, injector.ErrorCount);

            //  Add second binding with same provider type
            injector.AddBinding<ISimpleInterfaceA>().ToType<SimpleClassA>();

            //  Check bindings and providers
            Assert.Equal(2, injector.BindingCount);
            Assert.Equal(1, injector.ProviderCount);
            
            //  Check errors
            Assert.Equal(1, injector.ErrorCount);
            Assert.Equal(InjectionErrorType.AlreadyAddedTypeWithDifferentProvider,injector.GetError(0).error);
        }

    }
}
