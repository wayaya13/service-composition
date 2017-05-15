using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Timers;

namespace PSO
{
    class GetData
    {
        public static List<Server>[] splitedatafromfile(string[] filepath, int gridim)
        {
            List<Server>[] wlist = new List<Server>[gridim];
            for (int i = 0; i < gridim; i++)
                wlist[i] = new List<Server>();
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
                        wlist[i].Add(new Server(double.Parse(tempsplite[0]), double.Parse(tempsplite[1]), double.Parse(tempsplite[2]), double.Parse(tempsplite[3])));

                    }
                }
                reader.Close();
                fsr.Close();
            }
            return wlist;
        }
        public static List<Relation> GetRelation(string filepath)
        {
            List<Relation> wlist = new List<Relation>();
         
            FileStream fsr = new FileStream(filepath, FileMode.Open);
            StreamReader reader = new StreamReader(fsr);
            string temp;
            // int length = 0;
            while ((temp = reader.ReadLine()) != null)
            {
                if (temp.Length != 0 )
                {
                    string[] tempsplite = temp.Split(new char[] { ',' });
                    wlist.Add(new Relation(new int[] { int.Parse(tempsplite[0]), int.Parse(tempsplite[1]) }, double.Parse(tempsplite[2]), new int[] { int.Parse(tempsplite[3]), int.Parse(tempsplite[4])}));
                }
            }
            reader.Close();
            fsr.Close();
            return wlist;
        }
    }
}
