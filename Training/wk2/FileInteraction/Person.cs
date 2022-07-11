using System;
using System.Xml.Serialization;

namespace FileInteraction
{
    public class Person
    {
        // Fields
        public string? name { get; set; }

        // Converts to ...
        // private string? _name;
        // public string? name
        // {
        //     get { return _name; }
        //     set { _name = value; }
        // }

        public decimal? weight { get; set; }
        public decimal? height { get; set; }
        // Constructor

        public Person() { }

        public Person(string name, decimal weight, decimal height)
        {
            this.name = name;
            this.weight = weight;
            this.height = height;
        }

        //Methods
        private XmlSerializer Serializer { get; } = new XmlSerializer(typeof(Person));


        public string SerializeAsXML()
        {
            // var person = new Person(this.fName, this.weight, this.height);
            var stringWriter = new StringWriter();

            Serializer.Serialize(stringWriter, this  /*person*/);
            stringWriter.Close();
            return stringWriter.ToString();

        }


    }
}