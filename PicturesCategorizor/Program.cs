/**********************************
 * Copyright 2017 Netium
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PicturesCategorizor
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                AbstractCategorizationMethod method = null;
                switch (options.Method)
                {
                    case "date":
                        method = new ByCaptureDateMethod(options.MethodParameter);
                        break;
                    default:
                        Console.Error.WriteLine("Undefined method: " + options.Method);
                        Environment.Exit(1);
                        break;
                }

                CategorizeFiles(options.SourceDirectory, options.TargetDirectory, options.IsRecursive, method);
            }
        }

        static void CategorizeFiles(string sourceDirectory, string targetDirectory, bool recursing, AbstractCategorizationMethod method)
        {
            foreach (var file in Directory.GetFiles(sourceDirectory))
            {
                var targetSubDirectory = method.GetTargetFolder(file);
                if (targetSubDirectory != null)
                {
                    var finalTargetFolder = Path.Combine(targetDirectory, targetSubDirectory);
                    if (!Directory.Exists(finalTargetFolder))
                    {
                        Directory.CreateDirectory(finalTargetFolder);
                    }
                    File.Copy(file, Path.Combine(finalTargetFolder, Path.GetFileName(file)), false);
                    Console.WriteLine("Copied:\t" + Path.GetFileName(file) + " to " + finalTargetFolder);
                }
                else
                {
                    Console.WriteLine("Skipped:\t" + file);
                }
            }

            if (recursing)
            {
                foreach (var directory in Directory.GetDirectories(sourceDirectory))
                {
                    CategorizeFiles(directory, targetDirectory, recursing, method);
                }
            }
        }
    }
}
