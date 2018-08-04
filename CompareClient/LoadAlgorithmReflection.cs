using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TempleteAlgorithm;
namespace CoDEmpare
{
    class LoadAlgorithmReflection
    {
        private readonly string _folder = Directory.GetCurrentDirectory() + "\\Algorithm\\";
        private readonly List<string> _mainCode;
        private readonly List<string> _childCode;
        private List<IAlgorithm> _allCompare;
        public LoadAlgorithmReflection(List<string> main, List<string> child)
        {
            _allCompare = new List<IAlgorithm>();
            _mainCode = main;
            _childCode = child;
            GetAllAlgorithms();
        }

        private void GetAllAlgorithms()
        {
            string[] files = Directory.GetFiles(_folder, "*.dll");
            foreach (string file in files)
            {
                Assembly assembly = Assembly.LoadFile(file);
                Type[] types = assembly.GetTypes();
                foreach (Type type in assembly.GetTypes())
                {
                    Type iInrerface = type.GetInterface("TempleteAlgorithm.IAlgorithm");
                    if (iInrerface != null)
                    {
                        IAlgorithm myAlgorithm = (IAlgorithm)Activator.CreateInstance(type, new object[] { new List<string>(), new List<string>(), });
                        _allCompare.Add(myAlgorithm);
                    }
                }
            }
        }

        public List<string> LocalCompareRun()
        {
            List<string> resultLocal = new List<string>();
            foreach (IAlgorithm algo in _allCompare)
            {
                try
                {
                    
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            return resultLocal;
        }
    }
}
