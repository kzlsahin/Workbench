using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicParser
{    
    internal class LogicStatement : IBoolLayer
    {
        IBoolLayer boolLayers;
        public LogicStatement(string txt)
        {
            string[] content;

            Console.WriteLine(txt);

            if (txt[0] == '[' && txt[txt.Length - 1] == ']')
            {
                content = txt.Split('[', ']');
                boolLayers = new OrLayer(content[1]);
            }
            else if (txt[0] == '(' && txt[txt.Length - 1] == ')')
            {
                content = txt.Split('(', ')');
                boolLayers = new AndLayer(content[1]);
            }
            else
            {
                throw (new ArgumentException("Parenthes enclosing is not proper"));
            }
        }

        public Boolean EvalBool(Dictionary<string, string> sbjInfo)
        {
            
            return boolLayers.EvalBool(sbjInfo);
        }

        public static string[] DismantleParenthesis(string txt, char opennerParenthesis)
        {
            Console.WriteLine("Parsing the logic string:");
            List<string> result = new List<string>();
            char closingParenthesis;

            switch (opennerParenthesis)
            {
                case '(':
                    closingParenthesis = ')';
                    break;
                case '[':
                    closingParenthesis = ']';
                    break;
                default:
                    throw (new ArgumentException("opennerParenthes argument is not parenthesis character"));
            }

            int counterOpenParenthesis = 0;
            int indexStart = 0;
            Boolean paranthesisFound = false;

            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i] == opennerParenthesis)
                {
                    paranthesisFound = true;

                    if (counterOpenParenthesis == 0)
                    {
                        counterOpenParenthesis++;
                        indexStart = i + 1;
                    }
                }
                else if (txt[i] == closingParenthesis)
                {
                    if (counterOpenParenthesis == 1)
                    {
                        counterOpenParenthesis--;
                        result.Add(txt.Substring(indexStart, i - indexStart));
                    }
                    else
                    {
                        throw (new Exception($"a closing paranthesis at position {i} without apenning paranthesis"));
                    }
                }
                else
                {
                    continue;
                }

            }

            if (counterOpenParenthesis > 0)
            {
                throw (new Exception(" a closing paranthesis is missing"));
            }

            if (!paranthesisFound)
            {
                return new string[] { txt };
            }

            return result.ToArray();
        }

    } 
}
