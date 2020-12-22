using Gibbed.RED4.ScriptFormats;
using Gibbed.RED4.ScriptFormats.Emit;
using System;
using System.Collections.Generic;
using System.IO;

namespace RED4CGTest
{
    internal static partial class Program
    {
        static readonly List<Action> Patches = new List<Action>
        {
            AddAllRecipes,
            MakeOP,
        };

        static CacheFile     cache;
        static CodeGenerator cg;

        public static void Main(string[] args)
        {
            if (args[0].Length == 0)
                throw new ArgumentException("You must provide a final.redscripts file!");

            byte[] fileBytes = File.ReadAllBytes(args[0]);

            using MemoryStream input  = new MemoryStream(fileBytes, false);
            using MemoryStream output = new MemoryStream();

            cache = CacheFile.Load(input, false);
            cg    = new CodeGenerator();

            CreateNatives();
            CreateFunctions();

            ApplyPatches();

            cache.Save(output);
            output.Flush();

            File.WriteAllBytes("output.redscripts", output.ToArray());
        }

        static void ApplyPatches()
        {
            foreach (Action func in Patches)
            {
                func.Invoke();
                cg.Reset();
            }
        }
    }
}
