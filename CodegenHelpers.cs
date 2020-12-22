using Gibbed.RED4.ScriptFormats;
using Gibbed.RED4.ScriptFormats.Definitions;

namespace RED4CGTest
{
    internal static partial class Program
    {
        static FunctionDefinition CreateFunction(string fileName, string name)
        {
            SourceFileDefinition sourceFile = new SourceFileDefinition(fileName);
            cache.Definitions.Add(sourceFile);

            FunctionDefinition function = new FunctionDefinition
            {
                Name       = name,
                Flags      = FunctionFlags.HasParameters | FunctionFlags.HasLocals | FunctionFlags.HasCode,
                SourceFile = sourceFile
            };

            cache.Definitions.Add(function);

            return function;
        }

        static ParameterDefinition CreateParam(FunctionDefinition function, string name, Definition parent, Definition type)
        {
            ParameterDefinition param = new ParameterDefinition
            {
                Name   = name,
                Parent = parent,
                Type   = type
            };

            cache.Definitions.Add(param);
            function.Parameters.Add(param);

            return param;
        }

        static LocalDefinition CreateLocal(FunctionDefinition function, string name, Definition parent, NativeDefinition type)
        {
            LocalDefinition local = new LocalDefinition
            {
                Name   = name,
                Parent = parent,
                Type   = type
            };

            cache.Definitions.Add(local);
            function.Locals.Add(local);

            return local;
        }
    }
}
