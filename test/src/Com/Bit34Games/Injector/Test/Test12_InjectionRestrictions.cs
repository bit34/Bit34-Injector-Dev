using Xunit;
using Com.Bit34Games.Injector.Test.Payloads;
using Com.Bit34Games.Injector.Error;
using Com.Bit34Games.Injector.Test.Containers;
using Com.Bit34Games.Injector.Test.OtherContainers;

namespace Com.Bit34Games.Injector.Test
{
    public class Test12_InjectionRestrictions
    {
        [Fact]
        public void Test_NamespaceRestriction()
        {
            InjectorContext injector = new InjectorContext();

            //  Add first
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassA>().RestrictToNamespace("Com.Bit34Games.Injector.Test.Containers");

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