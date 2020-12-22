using Gibbed.RED4.ScriptFormats;
using Gibbed.RED4.ScriptFormats.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RED4CGTest
{
    internal static partial class Program
    {
        static T GetDefinition<T>(this CacheFile cache, string name)
            where T : Definition
            => cache.Definitions
                    .OfType<T>()
                    .Single(d => d.Name == name);

        static T GetDefinition<T>(this CacheFile cache, string name, Func<T, bool> predicate)
            where T : Definition
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return cache.Definitions
                        .OfType<T>()
                        .Single(d => d.Name == name && predicate(d));
        }

        static IEnumerable<T> GetDefinitions<T>(this CacheFile cache, Func<T, bool> predicate)
            where T : Definition
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return cache.Definitions
                        .OfType<T>()
                        .Where(d => predicate(d));
        }

        static NativeDefinition GetNative(this CacheFile cache, string name)
            => cache.Definitions
                    .OfType<NativeDefinition>()
                    .Single(d => d.Name == name);

        static ClassDefinition GetClass(this CacheFile cache, string name)
            => cache.Definitions
                    .OfType<ClassDefinition>()
                    .Single(d => d.Name == name);

        static FunctionDefinition GetFunction(this CacheFile cache, string name)
            => cache.Definitions
                    .OfType<FunctionDefinition>()
                    .Single(d => d.Parent == null && d.Name == name);

        static FunctionDefinition GetFunction(this CacheFile cache, string className, string functionName)
            => cache.GetClass(className)
                    .Functions
                    .Single(d => d.Name == functionName);

        static FunctionDefinition GetFunction(this ClassDefinition klass, string name)
            => klass
              .Functions
              .Single(d => d.Name == name);
    }
}
