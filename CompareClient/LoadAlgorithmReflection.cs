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
        public LoadAlgorithmReflection(List<string> main, List<string> child)
        {
            _mainCode = main;
            _childCode = child;
            GetAllAlgorithms();
        }

        public void GetAllAlgorithms()
        {
            List<IAlgorithm> allCompare = new List<IAlgorithm>();
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
                        allCompare.Add(myAlgorithm);
                    }
                }
            }
        }
    }
}
