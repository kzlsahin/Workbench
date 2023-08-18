using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicParser
{

    class AndLayer : IBoolLayer
    {
        private string[] contents;
        private List<IBoolLayer> nextLayers = new List<IBoolLayer>();
        public AndLayer(string inp)
        {
            Console.WriteLine("And Layer: ");
            Console.WriteLine(inp);
            this.contents = LogicStatement.DismantleParenthesis(inp, '[');
            if (this.contents.Length > 1)
            {

                this.ParseNextLayers();
            }
            else
            {
                contents = contents[0].Split(';');

                foreach (string content in contents)
                {

                    nextLayers.Add(new BoolContent(content));
                }
            }
        }

        private void ParseNextLayers()
        {
            foreach (string content in this.contents)
            {
                nextLayers.Add(new OrLayer(content));
            }
        }

        public Boolean EvalBool(Dictionary<string, string> sbjInfo)
        {
            Boolean res = true;

            foreach (IBoolLayer layer in nextLayers)
            {
                res = res && layer.EvalBool(sbjInfo);
            }
            return res;
        }

    }
}
