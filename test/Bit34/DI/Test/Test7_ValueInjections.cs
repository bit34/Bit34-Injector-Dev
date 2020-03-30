using Xunit;
using Com.Bit34Games.DI.Error;
using Com.Bit34Games.DI.Test.Payloads;
using Com.Bit34Games.DI.Test.Containers;

namespace Com.Bit34Games.DI.Test
{
    public class Test7_ValueInjections
    {
        [Fact]
        public void Test_ValueInjection()
        {
            Injector injector = new Injector();

            //  Add first binding
            SimpleClassA value = new SimpleClassA();
            injector.AddBinding<SimpleClassA>().ToValue(value);

            //  Create injection target
            var target = new ClassThatUses_SimpleClassA();

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
            Assert.Same(value,target.value2);
            Assert.Same(value,target.value1);
        }

        [Fact]
        public void Test_ValueInjectionToNestedMembers()
        {
            Injector injector = new Injector();

            //  Add first binding
            var value = new SimpleClassA();
            injector.AddBinding<SimpleClassA>().ToValue(value);

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
            Assert.Same(value,target.value2);
            Assert.Same(value,target.value1);
        }

        [Fact]
        public void Test_ValueInjectionToAssignableType()
        {
            Injector injector = new Injector();

            //  Add first binding
            var value = new SimpleClassA();
            injector.AddBinding<ISimpleInterfaceA>().ToValue(value);

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
        public void Test_Error_ValueInjectionToWrongType()
        {
            Injector injector = new Injector();

            //  Add first binding
            var value = new SimpleClassB();
            injector.AddBinding<SimpleClassB>().ToValue(value);

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
