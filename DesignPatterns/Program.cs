using DesignPatterns.Creational.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns
{
    class Program
    {

        static void Main(string[] args)
        {
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "Paras");
            builder.AddChild("li", "Pratik");
            builder.AddChild("li", "Ruby");
            WriteLine(builder.ToString());
            Read();            
        }
    }
}
