using System.Collections.Generic;
using TodoTracker.Enums;

namespace TodoTracker.Scanners
{
    public abstract class Scanner
    {
        public string Directory { get; set; } = System.IO.Directory.GetCurrentDirectory();
        public OutputFormat OutputFormat { get; set; }

        protected List<string> RegexPatterns { get; set; }
        protected List<string> FileTypes { get; set; }

        public Scanner() { }

        public abstract string Scan();
    }
}
