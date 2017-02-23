using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace macro
{
    class Program
    {
        static string Process(string plain, string key, string value)
        {
            string ret = plain;

            ret = ret.Replace(string.Format("##{0}", key), value);
            //ret = ret.Replace(string.Format("#{0}", key), string.Format("\"{0}\"", key));
            ret = ret.Replace(key, value);

            return ret;
        }

        static void Main(string[] args)
        {
            string plain = File.ReadAllText("1.txt");

            plain = Process(plain, "signx", "+");
            plain = Process(plain, "signy", "+");
            plain = Process(plain, "rx", "x");
            plain = Process(plain, "ry", "y");
            plain = Process(plain, "nx", "p");
            plain = Process(plain, "ny", "p");
            plain = Process(plain, "nf", "n");
            plain = Process(plain, "apply_edge", "true");
            plain = Process(plain, "apply_diag", "true");
            plain = Process(plain, "\\", "");


            File.WriteAllText("2.txt", plain);
        }
    }
}
