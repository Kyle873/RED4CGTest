using Gibbed.RED4.ScriptFormats;
using Gibbed.RED4.ScriptFormats.Definitions;
using Gibbed.RED4.ScriptFormats.Emit;

namespace RED4CGTest
{
    internal static partial class Program
    {
        static void OpAssign(Definition def)
            => OpAssign<int?>(def, null);

        static void OpAssign<T>(Definition def, T value)
        {
            cg.Emit(Opcode.Assign);
            {
                switch (def)
                {
                    case LocalDefinition l:
                        cg.Emit(Opcode.LocalVar, l);

                        break;
                }

                if (value != null)
                    switch (value)
                    {
                        case string s:
                            cg.Emit(Opcode.StringConst, s);

                            break;
                    }
            }
        }

        static void OpCall(Label endLabel, FunctionDefinition function, params Definition[] args)
        {
            cg.Emit(Opcode.FinalFunc, endLabel, 0, function);
            {
                foreach (Definition arg in args)
                    switch (arg)
                    {
                        case ParameterDefinition p:
                            cg.Emit(Opcode.ParamVar, p);

                            break;
                        case LocalDefinition l:
                            cg.Emit(Opcode.LocalVar, l);

                            break;

                        case null:
                            cg.Emit(Opcode.Nop);

                            break;
                    }

                cg.Emit(Opcode.ParamEnd);
            }
        }
    }
}
