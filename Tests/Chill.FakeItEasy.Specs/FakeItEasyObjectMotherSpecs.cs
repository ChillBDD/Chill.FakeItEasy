using System;
using Autofac.Core.Registration;
using FluentAssertions;
using Xunit;

namespace Chill.FakeItEasy.Specs
{
    namespace FakeItEasyObjectMotherSpecs
    {
        public class When_an_unregistered_interface_is_resolved : GivenWhenThen<IFoo>
        {
            public When_an_unregistered_interface_is_resolved()
            {
                WhenLater(() => The<IFoo>());
            }

            [Fact]
            public void Then_it_should_return_a_fake_using_fake_it_easy()
            {
                WhenAction.Should().NotThrow();
                
                Result.Value.Should().Be(0);
            }
        }

        public class When_an_unregistered_class_is_resolved : GivenWhenThen<string>
        {
            public When_an_unregistered_class_is_resolved()
            {
                WhenLater(() => The<string>());
            }

            [Fact]
            public void Then_it_should_throw()
            {
                WhenAction.Should().Throw<ComponentNotRegisteredException>();
            }
        }

        public interface IFoo
        {
            int Value{ get; set; }
        }

        public class Foo 
        {
            public string Value { get; set; }
        }
    }
}