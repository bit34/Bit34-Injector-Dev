using Xunit;
using Com.Bit34Games.Injector.Error;
using Com.Bit34Games.Injector.Test.Payloads;
using Com.Bit34Games.Injector.Test.Containers;

namespace Com.Bit34Games.Injector.Test
{
    public class Test6_TypedInjections
    {
        [Fact]
        public void Test_TypedInjection()
        {
            InjectorContext injector = new InjectorContext();

            //  Add first binding
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassA>();

            //  Create injection target
            ClassThatUses_SimpleClassA target = new ClassThatUses_SimpleClassA();

            //  Check before injection
            Assert.Null(target.value2);
            Assert.Null(target.value1);
            
            //  Inject
            injector.InjectInto(target);

            //  Check error
            Assert.Equal(0, injector.ErrorCount);

            //  Check after injection
            Assert.NotNull(target.value2);
            Assert.NotNull(target.value1);
        }

        [Fact]
        public void Test_TypedInjectionToNestedMembers()
        {
            InjectorContext injector = new InjectorContext();

            //  Add first binding
            injector.AddBinding<SimpleClassA>().ToType<SimpleClassA>();

            //  Create injection target
            var target = new ExtendedClassThatUses_SimpleClassA();

            //  Check before injection
            Assert.Null(target.value2);
            Assert.Null(target.value1);
            
            //  Inject
            injector.InjectInto(target);

            //  Check error
            Assert.Equal(0, injector.ErrorCount);

            //  Check after injection
            Assert.NotNull(target.value2);
            Assert.NotNull(target.value1);
        }

        [Fact]
        public void Test_TypedInjectionToAssignableType()
        {
            InjectorContext injector = new InjectorContext();

            //  Add first binding
            injector.AddBinding<ISimpleInterfaceA>().ToType<SimpleClassA>();

            //  Create injection target
            var target = new ClassThatUses_SimpleInterfaceA();

            //  Check before injection
            Assert.Null(target.value);
            
            //  Inject
            injector.InjectInto(target);

            //  Check error
            Assert.Equal(0, injector.ErrorCount);

            //  Check after injection
            Assert.NotNull(target.value);
        }

        [Fact]
        public void Test_Error_TypedInjectionToWrongType()
        {
            InjectorContext injector = new InjectorContext();

            //  Add first binding
            injector.AddBinding<SimpleClassB>().ToType<SimpleClassB>();

            //  Create injection target
            var target = new ClassThatUses_SimpleClassA();

            //  Check before injection
            Assert.Null(target.value2);
            Assert.Null(target.value1);
            
            //  Inject
            injector.InjectInto(target);

            //  Check error
            Assert.Equal(2, injector.ErrorCount);
            Assert.Equal(InjectionErrorType.CanNotFindBindingForType,injector.GetError(0).error);
            Assert.Equal(InjectionErrorType.CanNotFindBindingForType,injector.GetError(1).error);

            //  Check after injection
            Assert.Null(target.value2);
            Assert.Null(target.value1);
        }
    }
}
