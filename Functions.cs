using Gibbed.RED4.ScriptFormats.Definitions;

namespace RED4CGTest
{
    internal static partial class Program
    {
        static FunctionDefinition setAtt;
        static FunctionDefinition addExp;
        static FunctionDefinition giveItem;
        static FunctionDefinition getTransactionSystem;
        static FunctionDefinition stringToInt;

        static void CreateFunctions()
        {
            setAtt = GetDefinition<FunctionDefinition>(cache, "SetAtt");
            addExp = GetDefinition<FunctionDefinition>(cache, "AddExp");

            giveItem = GetDefinition<FunctionDefinition>(cache, "GiveItem",
                                                         f =>
                                                             f.Parameters.Count   == 3          &&
                                                             f.Parameters[0].Name == "gi"       &&
                                                             f.Parameters[1].Name == "itemName" &&
                                                             f.Parameters[2].Name == "amountStr");

            getTransactionSystem = GetDefinition<FunctionDefinition>(cache, "GetTransactionSystem", f => f.Parameters.Count == 1);
            stringToInt          = GetDefinition<FunctionDefinition>(cache, "StringToInt");
        }
    }
}
