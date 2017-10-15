/**********************************
 * Copyright 2017 Netium
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using System.Reflection;

namespace PicturesCategorizor
{
    class Options
    {
        [Option('r', null, Required = false, DefaultValue = false, HelpText = "Scan all the sub-directory in the source directory recursively")]
        public bool IsRecursive { get; set; }

        [Option('s', "source", Required = true, HelpText = "Source directory")]
        public string SourceDirectory { get; set; }

        [Option('t', "target", Required = true, HelpText = "Target directory")]
        public string TargetDirectory { get; set; }

        [Option('m', "method", Required = false, DefaultValue = "date", HelpText = "The method used to categorize the media files")]
        public string Method { get; set; }

        [Option('p', Required = false, DefaultValue = "", HelpText = "The parameter that will pass to the method")]
        public string MethodParameter { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var usage = new StringBuilder();
            usage.AppendLine("PicturesCategorizor " + Assembly.GetEntryAssembly().GetName().Version.ToString());
            return usage.ToString();
        }
    }
}
