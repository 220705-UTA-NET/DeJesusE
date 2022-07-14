using System;
namespace SQLProgram
{
    class Teacher : Person
    {
        private string subject;
        private string office;
        private bool tenure;
        private decimal salary;
        private List<string> certifications;

        public Teacher(string subject, string office, bool tenure, decimal salary,
                       List<string> certifications, string name, string street, string city,
                       string state, int zipcode, string email, string phone, int age)
        {
            this.name = name;
            this.Id = MaxId;
            MaxId++;
            this.email = email;
            this.phone = phone;
            this.street = street;
            this.city = city;
            this.state = state;
            this.zipcode = zipcode;
            this.age = age;
            this.subject = subject;
            this.office = office;
            this.tenure = tenure;
            this.salary = salary;
            this.certifications = certifications;
        }

    }
}