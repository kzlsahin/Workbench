using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicParser
{
    internal class BoolContent : IBoolLayer
    {
        private string[] words;
        public BoolContent(string content)
        {
            this.words = content.Split(' ');
            if (words.Length != 3)
            {
                Console.Write(words[0]);
                Console.WriteLine("....");
                throw (new ArgumentException("input has not 3 separate words including a two character long operator string"));
            }
        }
        public Boolean EvalBool(Dictionary<string, string> sbjInfo)
        {
            Boolean res = false;

            // null means ship can have any attributes if not defined
            if (sbjInfo is null) return true;
            if (!sbjInfo.ContainsKey("ship.klas")) return true;

            switch (words[1])
            {
                case "<<":
                    res = int.Parse(sbjInfo[words[0]]) < Int32.Parse(words[2]);
                    break;
                case ">>":
                    res = int.Parse(sbjInfo[words[0]]) > Int32.Parse(words[2]);
                    break;
                case "<=":
                    res = int.Parse(sbjInfo[words[0]]) <= Int32.Parse(words[2]);
                    break;
                case ">=":
                    res = int.Parse(sbjInfo[words[0]]) >= Int32.Parse(words[2]);
                    break;
                case "==":
                    res = sbjInfo[words[0]] == words[2];
                    break;
                case "!=":
                    res = sbjInfo[words[0]] != words[2];
                    break;
                default:
                    throw new ArgumentException("aperotar sign does not match with defined operators!");
            }

            return res;
        }

    }

}
