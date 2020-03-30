using Xunit;
using Com.Bit34Games.DI.Test.Payloads;

namespace Com.Bit34Games.DI.Test
{
    public class Test2_TypedProviders
    {
        [Fact]
        public void Test_AddingTypedProvider()
        {
            Injector injector = new Injector();

            //  Add first binding and a typed provider
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassA>();

            //  Validate
            Assert.Equal(1,injector.BindingCount);
            Assert.Equal(1,injector.ProviderCount);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);
            
            //  Add second binding and set typed provider
            injector.AddBinding<SimpleClassB>().ToType<SimpleClassB>();

            //  Validate
            Assert.Equal(2,injector.BindingCount);
            Assert.Equal(2,injector.ProviderCount);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);
        }
        
        [Fact]
        public void Test_AddingTypedProviderToAssignableType()
        {
            Injector injector = new Injector();

            //  Add first binding and a typed provider
            injector.AddBinding<ISimpleInterfaceA>().ToType<SimpleClassA>();

            //  Validate
            Assert.Equal(1,injector.BindingCount);
            Assert.Equal(1,injector.ProviderCount);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);
            
            //  Add second binding and set typed provider
            injector.AddBinding<ISimpleInterfaceB>().ToType<SimpleClassB>();

            //  Validate
            Assert.Equal(2,injector.BindingCount);
            Assert.Equal(2,injector.ProviderCount);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);
        }
        
/*      This is no longer needed because provider setter now uses binding type as a generic type
        [Fact]
        public void Test_Error_AddingTypedProviderToWrongType()
        {
            Injector injector = new Injector();

            //  Add first binding and set typed provider
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassB>();

            //  Validate binding
            Assert.Equal(1,injector.BindingCount);
            Assert.Equal(0,injector.ProviderCount);

            //  Check error
            Assert.Equal(1,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.TypeNotAssignableToTarget, injector.GetError(0).error);
            
            //  Add second binding and set typed provider
            injector.AddBinding<SimpleClassB>().ToType<SimpleClassA>();

            //  Validate binding
            Assert.Equal(2,injector.BindingCount);
            Assert.Equal(0,injector.ProviderCount);

            //  Check error
            Assert.Equal(2,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.TypeNotAssignableToTarget, injector.GetError(1).error);
        }
*/
    }
}
