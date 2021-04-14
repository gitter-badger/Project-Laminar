﻿using OpenFlow_PluginFramework.Registration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFlow_Core.Management
{
    public static class InbuiltPluginsLoader
    {
        public static IEnumerable<IPlugin> GetInbuiltPlugins()
        {
            foreach (string projectPath in Directory.EnumerateDirectories(InbuiltPluginsFolder))
            {
                if (PluginLoader.TryLoadFromFolder(GetBinFromProjectFolder(projectPath), out IPlugin plugin))
                {
                    yield return plugin;
                }
            }
        }

        private static string GetBinFromProjectFolder(string projectFolder)
        {
            string debugs = Path.Combine(projectFolder, @"bin\Debug");
            foreach (string path in Directory.EnumerateDirectories(debugs))
            {
                return path;
            }

            return null;
        }

        private static string InbuiltPluginsFolder => Path.Combine(GetSolutionFileFolder().FullName, @"src\Plugins");

        private static DirectoryInfo GetSolutionFileFolder()
        {
            DirectoryInfo directory = new(Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }

            return directory;
        }
    }
}
