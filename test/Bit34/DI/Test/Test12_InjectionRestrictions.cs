using Xunit;
using Bit34.DI.Test.Payloads;
using Bit34.DI.Error;
using Bit34.DI.Test.Containers;
using Bit34.DI.Test.OtherContainers;

namespace Bit34.DI.Test
{
    public class Test12_InjectionRestrictions
    {
        [Fact]
        public void Test_NamespaceRestriction()
        {
            Injector injector = new Injector();

            //  Add first
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassA>().RestrictToNamespace("Bit34.DI.Test.Containers");

            //  Validate binding
            Assert.Equal(1, injector.BindingCount);
            Assert.True(injector.HasBindingForType(typeof(SimpleClassA)));

            //  Check error
            Assert.Equal(0,injector.ErrorCount);

            //  Inject
            var instanceA = new ClassThatUses_SimpleClassA();
            injector.InjectInto(instanceA);

            //  Check error
            Assert.Equal(0,injector.ErrorCount);

            //  Inject
            var instanceB = new ClassThatUses_SimpleClassA_InAnotherNamespace();
            injector.InjectInto(instanceB);

            //  Check error
            Assert.Equal(1,injector.ErrorCount);
            Assert.Equal(InjectionErrorType.InjectionRestricted, injector.GetError(0).error);
        }
    }
}