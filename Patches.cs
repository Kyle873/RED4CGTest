using System.IO;
using System.Linq;

using Gibbed.RED4.ScriptFormats;
using Gibbed.RED4.ScriptFormats.Definitions;
using Gibbed.RED4.ScriptFormats.Emit;

namespace RED4CGTest
{
    internal static partial class Program
    {
        static void AddAllRecipes()
        {
            string[]            itemHashes = File.ReadAllLines("ItemHashes.txt"); // Item hash text file dump, one item hash per line
            FunctionDefinition  function   = CreateFunction(@"_\kyle873\AddAllRecipes.script", "AddAllRecipes");
            Label               endLabel   = cg.DefineLabel();
            ParameterDefinition gi         = CreateParam(function, "gameInstance", function, gameInstance);
            LocalDefinition     type       = CreateLocal(function, "type",   function, stringNative);
            LocalDefinition     amount     = CreateLocal(function, "amount", function, stringNative);

            OpAssign(amount, "1");

            foreach (string hash in itemHashes.Where(h => h.Contains("Recipe")))
            {
                OpAssign(type, hash);

                OpCall(endLabel, giveItem, gi, type, amount);
            }

            cg.MarkLabel(endLabel);
            cg.Emit(Opcode.Nop);

            function.Code.AddRange(cg.GetCode());
        }

        static void MakeOP()
        {
            const string AttributeMax = "20";
            const string ExpMax       = "1000000000";

            string[] attributes =
            {
                "Strength", // Body
                "Reflexes",
                "TechnicalAbility",
                "Intelligence",
                "Cool"
            };

            string[] proficiencies =
            {
                "Level",
                "StreetCred",

                "Assault",
                "Athletics",
                "Brawling",
                "ColdBlood",
                "CombatHacking", // Quickhacks
                "Crafting",
                "Demolition", // Annihilation
                "Engineering",
                "Gunslinger",
                "Hacking",
                "Kenjutsu", // Blades
                "Stealth"
            };

            FunctionDefinition  function = CreateFunction(@"_\kyle873\MakeOP.script", "MakeOP");
            Label               endLabel = cg.DefineLabel();
            ParameterDefinition gi       = CreateParam(function, "gameInstance", function, gameInstance);
            LocalDefinition     type     = CreateLocal(function, "type",   function, stringNative);
            LocalDefinition     amount   = CreateLocal(function, "amount", function, stringNative);

            foreach (string att in attributes)
            {
                OpAssign(type,   att);
                OpAssign(amount, AttributeMax);

                OpCall(endLabel, setAtt, gi, type, amount);
            }

            foreach (string prof in proficiencies)
            {
                OpAssign(type,   prof);
                OpAssign(amount, ExpMax);

                OpCall(endLabel, addExp, gi, type, amount);
            }

            cg.MarkLabel(endLabel);
            cg.Emit(Opcode.Nop);

            function.Code.AddRange(cg.GetCode());
        }
    }
}
