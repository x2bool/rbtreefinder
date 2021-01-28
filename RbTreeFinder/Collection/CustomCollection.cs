using System.IO;

namespace RbTreeFinder.Collection
{
    public class CustomCollection
    {
        private readonly RbTree<string, string> _redBlackTree;

        public CustomCollection()
        {
            _redBlackTree = new RbTree<string, string>((one, two) => one.CompareTo(two));
        }
        
        public CustomCollection(string fileName)
            : this()
        {
            Append(fileName);
        }

        public void Append(string fileName)
        {
            var lines = File.ReadAllLines(fileName);

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    _redBlackTree.Add(line, line);
                }
            }
        }

        public string Find(string key)
        {
            return _redBlackTree.GetValueForKeyOrGreater(key);
        }
    }
}