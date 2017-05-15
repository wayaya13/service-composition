using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Timers;
namespace test
{
    class GetData
    {
        public static List<ServiceSet>[] splitedatafromfile(string[] filepath, int gridim)
        {
            List<ServiceSet>[] wlist = new List<ServiceSet>[gridim];
            for (int i = 0; i < gridim; i++)
                wlist[i] = new List<ServiceSet>();
            for (int i = 0; i < gridim; i++)
            {
                FileStream fsr = new FileStream(filepath[i], FileMode.Open);
                StreamReader reader = new StreamReader(fsr);
                string regEx = "^#.*$";
                Regex re = new Regex(regEx);
                string temp;
                // int length = 0;
                while ((temp = reader.ReadLine()) != null)
                {
                    if (temp.Length != 0 && !re.IsMatch(temp))
                    {
                        string[] tempsplite = temp.Split(new char[] { ',' });
                        wlist[i].Add(new ServiceSet(double.Parse(tempsplite[0]), double.Parse(tempsplite[1]), double.Parse(tempsplite[2]), double.Parse(tempsplite[3])));

                    }
                }
                reader.Close();
                fsr.Close();
            }
            return wlist;
        }
    }
}