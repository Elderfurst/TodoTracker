using Microsoft.Extensions.CommandLineUtils;
using System;
using System.IO;
using System.Reflection;
using TodoTracker.Scanners;

namespace TodoTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO Testing this project
            var app = new CommandLineApplication
            {
                Name = "TodoTracker",
                Description = "Scan source code and get documentation on all of your TODOs throughout the project"
            };
            //TODO: Testing this project
            app.HelpOption("-?|-h|--help");

            app.VersionOption("-v|--version", () => {
                return string.Format("Version {0}", Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion);
            });
            // TODO: Testing this project
            var directoryOption = app.Option("-d|--directory <directory>",
                    "The Directory to scan, defaults to the current directory if not specified",
                    CommandOptionType.SingleValue);
            //TODO Testing this project
            app.OnExecute(() =>
            {
                var directory = Directory.GetCurrentDirectory();
                if (directoryOption.HasValue())
                {
                    directory = directoryOption.Value();
                }

                var scanner = ScannerFactory.GetScanner();
                var outputFileLocation = scanner.Scan();

                Console.WriteLine(string.Format("Output file containing TODOs located here: {0}", outputFileLocation));
                return 0;
            });
            //todo: testing this project
            try
            {
                //todo testing this project
                app.Execute(args);
            }
            catch (CommandParsingException ex)
            {
                // todo: testing this project
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                // todo testing this project
                Console.WriteLine("Unable to execute application: {0}", ex.Message);
            }
        }
    }
}
