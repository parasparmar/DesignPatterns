using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Builder
{
    /// <summary>
    /// This is the Product created by the respective builders.
    /// </summary>
    class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement()
        {

        }
        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }
        private string ToStringImpl(int indent)
        {
            StringBuilder sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.Append($"{i}<{Name}>\n");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.Append(Text);
                sb.Append("\n");
            }
            foreach (var e in Elements)
            {
                sb.Append(e.ToStringImpl(indent+1));
            }
            sb.Append($"{i}</{Name}>\n");
            return sb.ToString();
        }
        public override string ToString()
        {
            return ToStringImpl(0);
        }
        // FactoryMethod : Create a static HTMLBuilder in the Product itself: HtmlElement.       
        public static HtmlBuilder Create(string name) => new HtmlBuilder(name);
    }


    /// <summary>
    /// This is an implementation of the Concrete Builder for the Product.
    /// It is aware of the end product - HtmlElement and knows that 
    /// the construction steps need to go in a certain order
    /// </summary>
    class HtmlBuilder 
    {
        private readonly string rootName;
        // Hide the constructors so that the public is forced to use
        // the Builder.
        protected HtmlElement root = new HtmlElement();
        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }
        public void AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
        }
        public override string ToString()
        {
            return root.ToString();
        }
        public HtmlBuilder AddChildFluent(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }
        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }

        public static implicit operator HtmlElement(HtmlBuilder builder) => builder.root;
    }

}
