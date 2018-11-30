using System;
using Xunit;

namespace Functional.Pipe.Tests
{
    enum Animals
    {
        Dog,
        Cat
    }

    
    public class PipeTests
    {
        [Fact]
        public void Should_pipe_from_enums()
        {
            var dog = Animals.Dog;

            Assert.Equal("Dog", Animals.Dog.Pipe(d => d.ToString()));
        }

        [Fact]
        public void Should_pipe_to_function()
        {
            Assert.Equal(3, 2.Pipe(n => n + 1));
        }

        [Fact]
        public void Should_pipe_to_action_method()
        {
            Assert.Equal(3, 3.Pipe(n => Console.WriteLine(3)));
        }
    }
}