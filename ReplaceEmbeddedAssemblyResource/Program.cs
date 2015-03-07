using Mono.Cecil;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ReplaceEmbeddedAssemblyResource
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Smarter handling of command line parameters if there ever are additional ones
            if (args.Length < 4 || args.Length == 5 || args.Length > 6)
            {
                Console.Error.WriteLine("Expected arguments: <Assembly-Path> <New-Assembly-Path> <Resource-Name> <Resource-Path> [-snk <Strong-Name-Key-Path>]");
                Environment.Exit(1);
            }
            else if (args.Length == 6 && args[4] != "-snk")
            {
                Console.Error.WriteLine("Available options are:");
                Console.Error.WriteLine("\t-snk: Path to strong name key file (.snk).");
                Environment.Exit(1);
            }

            var assemblyPath    = args[0];
            var newAssemblyPath = args[1];
            var resourceName    = args[2];
            var resourcePath    = args[3];
            var snkPath         = args.Length == 6 ? args[5] : null;

            var assemblyDef = AssemblyDefinition.ReadAssembly(assemblyPath);

            Console.WriteLine("Loaded assembly " + assemblyDef);

            // TODO: Support other modules than MainModule

            var resources = assemblyDef.MainModule.Resources;

            var selectedResource = resources.FirstOrDefault(x => x.Name == resourceName);

            if (selectedResource != null)
            {
                var newResource = new EmbeddedResource(resourceName, selectedResource.Attributes, File.ReadAllBytes(resourcePath));
                resources.Remove(selectedResource);
                resources.Add(newResource);
                if (snkPath == null)
                    assemblyDef.Write(newAssemblyPath);
                else
                {
                    Console.WriteLine("Using strong name key file " + snkPath);
                    assemblyDef.Write(newAssemblyPath, new WriterParameters() { StrongNameKeyPair = new StrongNameKeyPair(File.ReadAllBytes(snkPath)) });
                }

                Console.WriteLine("Replaced embedded resource " + resourceName + " successfully!");
            }
            else
            {
                Console.Error.WriteLine("Could not find a resource with name " + resourceName);
                Console.Error.WriteLine("Available resources: " + String.Join(", ", resources.Select(x => x.Name).DefaultIfEmpty("<none>")));
            }
        }
    }
}
