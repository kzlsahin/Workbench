using Plugin_Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Class_Rules;
using ClassRules_RefObjects;
using TL_RuleDocClassLib;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlTypes;
using System.Windows.Controls.Primitives;
using System.Xml;

namespace ConsoleApp1
{
    internal class Program
    {
        internal static Logger Logger;
        static void Main(string[] args)
        {
            Logger = new Logger("ConsoleApp");
            LoadAddin();

            Rules rule = new Rules();
            int i = 1;
            foreach (string ruleName in rule.ListOfRules)
            {
                Console.WriteLine($"rule-{i} {ruleName}");
            }
            i = 0;
            do
            {
                Console.WriteLine($"please select a rule from {rule.ListOfRules.Length} rules.");
                i = int.Parse(Console.ReadLine());
            } while (i >= rule.ListOfRules.Length);


            rule.RuleName = rule.ListOfRules[i];
            Console.WriteLine($"rule-{i} {rule.RuleName}");
            rule.AssignmentLists(rule.RuleName);

            foreach (string item in rule.ListNavigationNotation)
            {
                Console.WriteLine($"rule-{i} {item}");
            }

            Console.Read();
        }

        internal static void LoadAddin()
        {
            string URLString = "RuleAddinList.xml";
            XmlTextReader Reader = new XmlTextReader(URLString);
            Reader.MoveToContent();
            while (Reader.Read())
            {
                Console.WriteLine($"reading {Reader.Name}");
                switch (Reader.NodeType)
                {                    
                    case System.Xml.XmlNodeType.Element:
                        Console.WriteLine($"reading node element {Reader.Name}");
                        string ruleName = string.Empty;
                        string className = string.Empty;
                        string explanation = "-";
                        while (Reader.MoveToNextAttribute())
                        {
                            Console.WriteLine($"reading attribute {Reader.Name}");
                            
                            if (Reader.Name == "rule-name")
                            {
                                ruleName = Reader.Value;
                            }
                            if (Reader.Name == "class-name")
                            {
                                className = Reader.Value;
                            }
                            if (Reader.Name == "discription")
                            {
                                explanation = Reader.Value;
                            }
                            if (ruleName == string.Empty || className == string.Empty)
                            {
                                continue;
                            }
                            Console.WriteLine($"name ? {ruleName} class name ? {className}");
                        }
                        break;
                    case System.Xml.XmlNodeType.Text:
                    case System.Xml.XmlNodeType.EndElement:
                        break;
                }
            }
        }
        internal class Solution
        {
            public class ListNode
            {
                public int val;
                public ListNode next;
                public ListNode(int val = 1, ListNode next = null)
                {
                    this.val = val;
                    this.next = next;
                }
            }
            public ListNode RemoveElements(ListNode head, int val)
            {
                if (head == null) return null;
                while (head != null && head.val == val)
                {
                    head = head.next ?? null;
                }
                if (head == null) return null;
                ListNode iterHead = head;
                while (true)
                {
                    if (iterHead.next.val == val)
                    {
                        iterHead.next = iterHead.next.next;
                    }
                    iterHead = iterHead.next;
                    if (iterHead == null) break;
                }
                return head;
            }
        }

        internal void RunPlugins()
        {
            AssemblyName Plugin1Name = new AssemblyName();
            Plugin1Name.Name = "Plugin1.Plugin1";
            Plugin1Name.Version = new Version("1.0.0.0");
            Plugin1Name.CultureInfo = new CultureInfo("");
            Plugin1Name.ProcessorArchitecture = ProcessorArchitecture.MSIL;
            Plugin1Name.SetPublicKeyToken(Encoding.ASCII.GetBytes("b696124c3a75060f"));
            Assembly Plugin1Assembly = Assembly.Load("Plugin1");

            //"Plugin1, Version = 1.1.1.0, Culture = neutral, PublicKeyToken = b696124c3a75060f"
            string name2 = "Plugin1";
            Assembly plugin2Assembly = Assembly.LoadFrom("plugin1.v_1.1.1\\Plugin1.dll");

            Type Plugin1 = Plugin1Assembly.GetType("Plugin1.MyPlugin");
            IPluginCommand plugin1 = (IPluginCommand)Activator.CreateInstance(Plugin1);
            //plugin1.Logger = Logger;
            plugin1.Name = "Hi my name is plugin1"; plugin1.Execute();


            AssemblyName plugin2Name = plugin2Assembly.GetName();
            Console.WriteLine(plugin2Name.FullName);
            string pKey = Convert.ToBase64String(plugin2Name.GetPublicKeyToken());
            Console.WriteLine(pKey);
            if (plugin2Name.Version.ToString() == "1.1.1.0" || pKey == "b696124c3a75060f")
            {
                Type Plugin2 = plugin2Assembly.GetType("Plugin1.MyPlugin");
                IPluginCommand plugin2 = (IPluginCommand)Activator.CreateInstance(Plugin2);
                //plugin2.Logger = Logger;
                plugin2.Name = "Hi my name is plugin1";
                plugin2.Execute();
            }
        }
    }
}
