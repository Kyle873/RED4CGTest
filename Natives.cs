using Gibbed.RED4.ScriptFormats.Definitions;

namespace RED4CGTest
{
    internal static partial class Program
    {
        static NativeDefinition stringNative;
        static NativeDefinition int32Native;
        static NativeDefinition floatNative;
        static NativeDefinition gameInstance;
        static NativeDefinition playerPuppet;
        static NativeDefinition transactionSystem;

        static void CreateNatives()
        {
            stringNative      = GetNative(cache, "String");
            int32Native       = GetNative(cache, "Int32");
            floatNative       = GetNative(cache, "Float");
            gameInstance      = GetNative(cache, "GameInstance");
            playerPuppet      = GetNative(cache, "ref:PlayerPuppet");
            transactionSystem = GetNative(cache, "ref:TransactionSystem");
        }
    }
}
