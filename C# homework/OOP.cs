//1.take an array and reverse the contents of it.
/*
using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = GenerateNumbers(10);

        Reverse(numbers);

        PrintNumbers(numbers);
    }

    static int[] GenerateNumbers(int length)
    {
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = i + 1;
        }
        return array;
    }

    static void Reverse(int[] array)
    {
        int length = array.Length;
        for (int i = 0; i < length / 2; i++)
        {
            int temp = array[i];
            array[i] = array[length - i - 1];
            array[length - i - 1] = temp;
        }
    }

    static void PrintNumbers(int[] array)
    {
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
        Console.ReadLine();

    }
}
*/



//2.Fibonacci sequence
/*
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the position of the Fibonacci number you want: ");
        int n = int.Parse(Console.ReadLine());

        int result = Fibonacci(n);
        Console.WriteLine($"The {n}th Fibonacci number is {result}");
        Console.ReadLine();

    }

    static int Fibonacci(int n)
    {
        // Base cases: if it's the 1st or 2nd number, the value will be 1
        if (n == 1 || n == 2)
        {
            return 1;
        }

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}
*/



//3.Designing and Building Classes using object-oriented principles
/*
using System;

namespace OOPDemo
{
    // Abstraction: Define an abstract Person class
    public abstract class Person
    {
        // Encapsulation: Private fields with public properties
        private string _name;
        private DateTime _dateOfBirth;

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException("Name cannot be null");
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (value > DateTime.Now) throw new ArgumentException("Date of Birth cannot be in the future");
                _dateOfBirth = value;
            }
        }

        private decimal _salary;
        public decimal Salary
        {
            get => _salary;
            set
            {
                if (value < 0) throw new ArgumentException("Salary cannot be negative");
                _salary = value;
            }
        }

        public List<string> Addresses { get; } = new List<string>();

        public void AddAddress(string address) => Addresses.Add(address);

        public List<string> GetAddresses() => Addresses;

        // Abstract method for Polymorphism
        public abstract decimal CalculateSalary();

        public int CalculateAge() => DateTime.Now.Year - DateOfBirth.Year;
    }

    // Interface for common person-related services
    public interface IPersonService
    {
        int CalculateAge();
        decimal CalculateSalary();
    }

    // Interface inheritance for students and instructors
    public interface IStudentService : IPersonService
    {
        void EnrollInCourse(Course course, char grade);
        double CalculateGPA();
    }

    public interface IInstructorService : IPersonService
    {
        int CalculateYearsOfExperience();
    }

    // Student Class
    public class Student : Person, IStudentService
    {
        private readonly Dictionary<Course, char> _grades = new Dictionary<Course, char>();

        public void EnrollInCourse(Course course, char grade)
        {
            if (!_grades.ContainsKey(course))
            {
                _grades[course] = grade;
                course.EnrollStudent(this);
            }
        }

        public double CalculateGPA()
        {
            double totalPoints = 0;
            foreach (var grade in _grades.Values)
            {
                totalPoints += GradeToPoint(grade);
            }

            return _grades.Count == 0 ? 0 : totalPoints / _grades.Count;
        }

        private double GradeToPoint(char grade)
        {
            return grade switch
            {
                'A' => 4.0,
                'B' => 3.0,
                'C' => 2.0,
                'D' => 1.0,
                'F' => 0.0,
                _ => throw new ArgumentException("Invalid grade")
            };
        }

        public override decimal CalculateSalary() => 0; // Students don't earn a salary
    }

    // Instructor Class
    public class Instructor : Person, IInstructorService
    {
        public Department Department { get; set; }
        public bool IsHeadOfDepartment => Department?.Head == this;
        public DateTime JoinDate { get; set; }

        public int CalculateYearsOfExperience() => DateTime.Now.Year - JoinDate.Year;

        public override decimal CalculateSalary()
        {
            decimal experienceBonus = CalculateYearsOfExperience() * 500; // $500 per year
            return Salary + experienceBonus;
        }
    }

    // Course Class
    public class Course
    {
        public string Name { get; set; }
        public List<Student> EnrolledStudents { get; } = new List<Student>();

        public void EnrollStudent(Student student)
        {
            if (!EnrolledStudents.Contains(student))
            {
                EnrolledStudents.Add(student);
            }
        }
    }

    // Department Class
    public class Department
    {
        public string Name { get; set; }
        public Instructor Head { get; set; }
        public decimal Budget { get; set; }
        public List<Course> Courses { get; } = new List<Course>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a Department
            var compSci = new Department
            {
                Name = "Computer Science",
                Budget = 500000
            };

            // Create an Instructor
            var instructor = new Instructor
            {
                Name = "Dr. Smith",
                DateOfBirth = new DateTime(1980, 5, 15),
                Salary = 80000,
                JoinDate = new DateTime(2010, 8, 1),
                Department = compSci
            };

            compSci.Head = instructor;

            // Create a Student
            var student = new Student
            {
                Name = "Alice",
                DateOfBirth = new DateTime(2000, 3, 10)
            };

            // Create Courses
            var course1 = new Course { Name = "Data Structures" };
            var course2 = new Course { Name = "Algorithms" };

            // Enroll the student in courses
            student.EnrollInCourse(course1, 'A');
            student.EnrollInCourse(course2, 'B');

            // Add courses to the department
            compSci.Courses.Add(course1);
            compSci.Courses.Add(course2);

            // Print details
            Console.WriteLine($"Instructor: {instructor.Name}, Age: {instructor.CalculateAge()}, Salary: {instructor.CalculateSalary()}");
            Console.WriteLine($"Student: {student.Name}, Age: {student.CalculateAge()}, GPA: {student.CalculateGPA()}");
            Console.WriteLine($"Department: {compSci.Name}, Head: {compSci.Head.Name}, Budget: {compSci.Budget}");
            Console.ReadLine();
        }
    }
}
*/



//4. Color and Ball program
using System;

class Color
{
    private int red;
    private int green;
    private int blue;
    private int alpha;

    public Color(int red, int green, int blue, int alpha)
    {
        this.Red = red;
        this.Green = green;
        this.Blue = blue;
        this.Alpha = alpha;
    }

    public Color(int red, int green, int blue) : this(red, green, blue, 255) { }

    public int Red
    {
        get => red;
        set => red = ValidateColorValue(value);
    }

    public int Green
    {
        get => green;
        set => green = ValidateColorValue(value);
    }

    public int Blue
    {
        get => blue;
        set => blue = ValidateColorValue(value);
    }

    public int Alpha
    {
        get => alpha;
        set => alpha = ValidateColorValue(value);
    }

    private int ValidateColorValue(int value)
    {
        if (value < 0 || value > 255)
            throw new ArgumentOutOfRangeException("Color value must be between 0 and 255.");
        return value;
    }

    // Method to calculate the grayscale value
    public int GetGrayscaleValue()
    {
        return (Red + Green + Blue) / 3;
    }
}

class Ball
{
    private int size;
    private Color color;
    private int throwCount;

    public Ball(int size, Color color)
    {
        this.Size = size;
        this.Color = color;
        this.throwCount = 0;
    }

    public int Size
    {
        get => size;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Size cannot be negative.");
            size = value;
        }
    }

    public Color Color
    {
        get => color;
        set => color = value ?? throw new ArgumentNullException("Color cannot be null.");
    }

    // Pop method
    public void Pop()
    {
        Size = 0;
    }

    // Throw method
    public void Throw()
    {
        if (Size > 0)
        {
            throwCount++;
        }
    }

    // Method to get the throw count
    public int GetThrowCount()
    {
        return throwCount;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a few Color objects
        Color redColor = new Color(255, 0, 0);
        Color blueColor = new Color(0, 0, 255);
        Color greenColor = new Color(0, 255, 0);

        // Create Ball objects
        Ball ball1 = new Ball(10, redColor);
        Ball ball2 = new Ball(15, blueColor);
        Ball ball3 = new Ball(12, greenColor);

        ball1.Throw();
        ball1.Throw();
        ball2.Throw();

        ball1.Pop();

        ball1.Throw();

        ball3.Throw();
        ball3.Throw();
        ball3.Throw();

        Console.WriteLine($"Ball 1 throw count: {ball1.GetThrowCount()}"); 
        Console.WriteLine($"Ball 2 throw count: {ball2.GetThrowCount()}");
        Console.WriteLine($"Ball 3 throw count: {ball3.GetThrowCount()}");
        Console.WriteLine($"Ball 3 color grayscale value: {ball3.Color.GetGrayscaleValue()}");
        Console.ReadLine();

    }
}
