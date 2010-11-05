using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class AutoSuggest 
    {
        string optionListText = "";
        private Dictionary<string, string> list;
        public AutoSuggest(string source)
        {
            list = new Dictionary<string, string>();
            string[] sourceList = source.Split(new char[] { '\n' });
            //list.Add(sourceList, "");
            foreach(string k in sourceList){
                list.Add(k,"");
            }

        }

        public static AutoSuggest FactoryFromFile(string file){
            return new AutoSuggest(System.IO.File.ReadAllText(file));
        }

        public IOrderedEnumerable<string> FilterPrefix(string prefix)
        {
            //list.Find(new Predicate<string>(delegate(string s) { return s.StartsWith(prefix); }));
            var res =from k in list.Keys where k.StartsWith(prefix) 
                   orderby k ascending select k;
            return res; 
        }
    }
}
