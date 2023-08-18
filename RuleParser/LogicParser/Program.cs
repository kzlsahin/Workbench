using System;
using System.Collections.Generic;

namespace LogicParser
{
    /// <summary>
    /// This program is a preliminary study of a logical parser for conditionals of regulatory rules defining scopes of the statements.
    /// LogicParser parses a condition statement and checks the attributes of the rule subject whether the subject is in scope or not
    /// </summary>
    class Program
    {
        public static string strIconditionalStringput = "[(ship.L << 24;ship.klas == klasli;ship.type == tanker);(ship.L >> 24;ship.klas == klasli)]";
        public static Dictionary<string, string> subjectAttributes = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            subjectAttributes.Add("ship.L", "20");
            subjectAttributes.Add("ship.klas", "klasli");
            subjectAttributes.Add("ship.type", "genelkargo");
            try
            {
                LogicStatement statement = new (strIconditionalStringput);

                if (statement.EvalBool(subjectAttributes))
                {
                    Console.WriteLine("+ Subject is in scope of the condition");
                }
                else
                {
                    Console.WriteLine("- Subject is Not in scope of the condition");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
