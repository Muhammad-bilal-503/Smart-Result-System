using System;

namespace SmartResultSystem
{
    // ============================================================
    // Q#1 - Part (i): Person Base Class
    // ============================================================
    public class Person
    {
        // Encapsulation using Properties
        public string Name { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }

        // Constructor
        public Person(string name, int age, string id)
        {
            Name = name;
            Age = age;
            ID = id;
        }

        // Virtual method for result calculation (Polymorphism)
        public virtual string CalculateResult(double marks)
        {
            if (marks >= 50)
                return "Pass";
            else
                return "Fail";
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name} | Age: {Age} | ID: {ID}");
        }
    }

    // ============================================================
    // Q#1 - Part (ii): Student Derived Class
    // Inheritance + Encapsulation + Polymorphism
    // ============================================================
    public class Student : Person
    {
        // Encapsulation using Properties
        public double Marks { get; set; }
        public string Semester { get; set; }
        public string Department { get; set; }

        // Constructor calling base class constructor (Inheritance)
        public Student(string name, int age, string id, double marks, string semester, string dept)
            : base(name, age, id)
        {
            Marks = marks;
            Semester = semester;
            Department = dept;
        }

        // Polymorphism - Override CalculateResult with grade logic
        public override string CalculateResult(double marks)
        {
            if (marks >= 80) return "A Grade - Distinction";
            else if (marks >= 70) return "B Grade - Merit";
            else if (marks >= 60) return "C Grade - Pass";
            else if (marks >= 50) return "D Grade - Pass";
            else return "F Grade - Fail";
        }

        // Predict result using overridden method
        public string PredictResult()
        {
            return CalculateResult(Marks);
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Semester: {Semester} | Dept: {Department} | Marks: {Marks}");
            Console.WriteLine($"Result: {PredictResult()}");
        }
    }
}
