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
            //#region Simple Builder
            //var builder = new HtmlBuilder("ul");
            //builder.AddChild("li", "Paras");
            //builder.AddChild("li", "Pratik"); ;
            //builder.AddChild("li", "Ruby");
            //WriteLine(builder.ToString());
            //Read();
            //#endregion

            //#region Fluent Builder
            //var fluentbuilder = new HtmlBuilder("ul");
            //fluentbuilder.AddChildFluent("li", "Paras")
            //    .AddChildFluent("li", "Pratik")
            //    .AddChildFluent("li", "Ruby");
            //WriteLine(fluentbuilder.ToString());
            //Read();
            //#endregion

            //#region Communicating Intent : Fluent Builder
            //var comm = HtmlElement
            //    .Create("ul")
            //    .AddChildFluent("li", "Paras")
            //    .AddChildFluent("li", "Pratik")
            //    .AddChildFluent("li", "Ruby");
            //WriteLine(comm);
            //Read();
            //#endregion

            #region Composite Builder
            var pb = new PersonBuilder();
            Person person = pb
                .Lives
                .AtStreet("63-64 Yoginagar")
                .InCity("Borivali(W), Mumbai")
                .WithPostCode("400092")
                .Works
                .AtCompany("Kale Logistics Solutions Pvt. Ltd.")
                .WithDesignation("Lead Analyst")
                .Earning(100);
            WriteLine(person);
            Read();
            #endregion
        }
    }
}
