using System;
using System.Diagnostics;
using Xunit;

namespace Functional.Pipe.Tests
{
    public class ToFuncTests
    {
        [Fact]
        public void Should_convert_to_func()
        {
            // arrange
            // act
            var result1 = Time("test operation", () => 1);
            Time("test operation with no return value", () => Console.WriteLine("test1"));

            Action action1 = () => Console.WriteLine("test2");
            Time("test operation with no return value", action1.ToFunc());

            Time("test operation with no return value", ((Action) (() => Console.WriteLine("test3"))).ToFunc());

            // assert
            Assert.Equal(1, result1);
        }

        private static void Time(string operation, Action action)
            => Time(operation, action.ToFunc());
        
        public static T Time<T>(string operation, Func<T> func)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            T t = func();

            stopwatch.Stop();
            Console.WriteLine($"{operation} took {stopwatch.ElapsedMilliseconds} ms");
            return t;
        }
    }
}