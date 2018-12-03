using TodoTracker.Enums;

namespace TodoTracker.Scanners
{
    public static class ScannerFactory
    {
        public static Scanner GetScanner(ProjectLanguage projectLanguage = ProjectLanguage.CSharp)
        {
            switch (projectLanguage)
            {
                case ProjectLanguage.CSharp:
                default:
                    return new CSharpScanner();
            }
        }
    }
}
