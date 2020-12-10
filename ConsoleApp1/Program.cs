using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\TTT\Desktop\123.xml");

            XmlNode root = doc.SelectSingleNode("bookstore");
            XmlNodeList childlist = root.ChildNodes;
            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);

            Console.WriteLine("XML -> JSON: {0}", json);

            using (FileStream fs = new FileStream(@"C:\Users\TTT\Desktop\boolist.json", FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(json);
                }
            }
        }
    }
  
}
