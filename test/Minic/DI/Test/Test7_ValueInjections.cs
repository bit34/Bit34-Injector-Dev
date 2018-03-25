// Copyright (c) 2018 Oğuz Sandıkçı
// This code is licensed under MIT license (see LICENSE.txt for details)

using System;
using Xunit;
using Minic.DI;
using Minic.DI.Error;
using Minic.DI.Test.Payloads;


namespace Minic.DI.Test
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
            ClassThatUses_SimpleClassA target = new ClassThatUses_SimpleClassA();

            //  Check before injection
            Assert.Null(target.value);
            
            //  Inject
            injector.InjectInto(target);

            //  Check error
            Assert.Equal(0, injector.ErrorCount);

            //  Check after injection
            Assert.NotNull(target.value);
            Assert.Same(value,target.value);
        }

        [Fact]
        public void Test_ValueInjectionToAssignableType()
        {
            Injector injector = new Injector();

            //  Add first binding
            SimpleClassA value = new SimpleClassA();
            injector.AddBinding<ISimpleInterfaceA>().ToValue(value);

            //  Create injection target
            ClassThatUses_SimpleInterfaceA target = new ClassThatUses_SimpleInterfaceA();

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
            SimpleClassB value = new SimpleClassB();
            injector.AddBinding<SimpleClassB>().ToValue(value);

            //  Create injection target
            ClassThatUses_SimpleClassA target = new ClassThatUses_SimpleClassA();

            //  Check before injection
            Assert.Null(target.value);
            
            //  Inject
            injector.InjectInto(target);

            //  Check error
            Assert.Equal(1, injector.ErrorCount);
            Assert.Equal(InjectionErrorType.CanNotFindBindingForType,injector.GetError(0).Error);

            //  Check after injection
            Assert.Null(target.value);
        }
    }
}
