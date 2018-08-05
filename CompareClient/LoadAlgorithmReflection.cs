using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CoDEmpare.ObjectParamsSender;
using TempleteAlgorithm;
namespace CoDEmpare
{
    class LoadAlgorithmReflection
    {
        private readonly string _folder = Directory.GetCurrentDirectory() + "\\Algorithm\\";
        private ResultCompareObject _localCompare;
        private Dictionary<string, IAlgorithm> _compareAll;
        public LoadAlgorithmReflection(ResultCompareObject resultServer)
        {
            _localCompare = resultServer;
            _compareAll = new Dictionary<string, IAlgorithm>();
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
                        IAlgorithm myAlgorithm = (IAlgorithm)Activator.CreateInstance(type, new object[] { _localCompare.TokkingMainCode, _localCompare.TokkingChildCode });
                        _compareAll.Add(type.Name, myAlgorithm);
                    }
                }
            }
        }

        public void LocalCompareRun()
        {
            
            foreach (KeyValuePair<string, IAlgorithm> localAlgo in _compareAll)
            {
                try
                {
                   double resultCompare = localAlgo.Value.CompereCode();
                    _localCompare.ResultCompare.Add(String.Format("{1} : {0:0.##}", resultCompare, localAlgo.Key));

                }
                catch (Exception e)
                {
                    return;
                }
            }

        }
    }
}
