using System;
namespace SQLProgram
{
    class Student : Person
    {
        // Fields
        private int year;
        private float GPA = 0.0f;

        // Constructor

        public Student(int year, string name, string street, string city,
                       string state, int zipcode, string email, string phone,
                       int age)
        {
            this.year = year;
            this.Id = MaxId;
            MaxId++;
            this.name = name;
            this.street = street;
            this.city = city;
            this.state = state;
            this.zipcode = zipcode;
            this.email = email;
            this.phone = phone;
            this.age = age;
        }

        // Methods
    }
}