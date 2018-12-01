using System;

namespace Functional.Pipe
{
    public static class ActionExtensions
    {
        public static Func<int> ToFunc(this Action action) 
            => () =>
            {
                action();
                return 0;
            };
    }
}