using System;
namespace SQLProgram
{
    class Course
    {
        private string Id;
        private string name;
        private string department;
        private string location;
        private DateTime startDate;
        private List<Student> roster;
        private Teacher instructors;
        private int capacity;
        private List<Course> preReqs;
        private int creditHours;
        private static int MaxId = 1;

        public Course(string Name, string department, string location,
                      DateTime startDate, int creditHours)
        {
            this.Id = department.Substring(0, 3) + MaxId.ToString();
            MaxId++;
            this.name = Name;
            this.department = department;
            this.location = location;
            this.startDate = startDate;
            this.creditHours = creditHours;
        }
    }
}