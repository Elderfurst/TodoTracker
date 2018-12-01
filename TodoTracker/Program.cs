using Microsoft.Extensions.CommandLineUtils;
using System;
using System.IO;
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

            var directoryOption = app.Option("-d|--directory <directory>",
                    "The Directory to scan, defaults to the current directory if not specified",
                    CommandOptionType.SingleValue);

            app.OnExecute(() =>
            {
                var directory = Directory.GetCurrentDirectory();
                if (directoryOption.HasValue())
                {
                    directory = directoryOption.Value();
                }

                var scanner = new Scanner(directory);
                var outputFileLocation = scanner.Scan();

                Console.WriteLine(string.Format("Output file containing TODOs located here: {0}", outputFileLocation));
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
