namespace TodoTracker
{
    public class Scanner
    {
        private readonly string _directory;

        public Scanner(string directory)
        {
            _directory = directory;
        }

        public string Scan()
        {
            return _directory;
        }
    }
}
