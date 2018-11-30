using System;

namespace Functional.Pipe
{
    public static class PipeExtensions
    {
        /// <summary>
        /// Applies the given function to the input, resulting in the expected result. 
        /// Originally, map applies to list, but this extension method accepts a single element. 
        /// https://en.wikipedia.org/wiki/Map_(higher-order_function)
        /// </summary>
        /// <typeparam name="TSource">Input</typeparam>
        /// <typeparam name="TResult">Output</typeparam>
        /// <param name="this"></param>
        /// <param name="func">function to apply</param>
        /// <returns>Returns Output TResult</returns>
        public static TResult Pipe<TSource, TResult>(this TSource @this, Func<TSource, TResult> func ) 
            => func(@this);

        public static T Pipe<T>(this T @this, Action<T> action )
        {
            action(@this);
            return @this;
        }

        /// <summary>
        /// Like T Splitter, it splits the execution by 1) returning the input and 2) apply action to the input. 
        /// For more info, check https://en.wikipedia.org/wiki/Tee_(command)
        /// </summary>
        /// <typeparam name="T">Input</typeparam>
        /// <param name="this"></param>
        /// <param name="act">function to apply</param>
        /// <returns>Returns the input T</returns>
        public static T Tee<T>(this T @this, Action<T> act)
        {
            act(@this);
            return @this;
        }

    }
}