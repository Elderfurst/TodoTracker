using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Reflection;

namespace TodoTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "TodoTracker",
                Description = "Scan source code and get documentation on all of your TODOs throughout the project"
            };

            app.HelpOption("-?|-h|--help");

            app.VersionOption("-v|--version", () => {
                return string.Format("Version {0}", Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion);
            });

            app.OnExecute(() =>
            {
                return 0;
            });

            try
            {
                app.Execute(args);
            }
            catch (CommandParsingException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to execute application: {0}", ex.Message);
            }
        }
    }
}
