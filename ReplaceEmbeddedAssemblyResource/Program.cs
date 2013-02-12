using Mono.Cecil;
using System;
using System.IO;
using System.Linq;

namespace ReplaceEmbeddedAssemblyResource
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                Console.Error.WriteLine("Expected arguments: <Assembly-Path> <New-Assembly-Path> <Resource-Name> <Resource-Path>");
                Environment.Exit(1);
            }

            var assemblyPath    = args[0];
            var newAssemblyPath = args[1];
            var resourceName    = args[2];
            var resourcePath    = args[3];

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
                assemblyDef.Write(newAssemblyPath);

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
