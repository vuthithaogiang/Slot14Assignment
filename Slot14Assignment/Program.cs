using System.Text;
using Slot14Assignment.classes;
using Slot14Assignment.exception;

public class Program

{
    static List<Student> students = new List<Student>();
    static IFilter filter = new Filter();

    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        int choice;

        do
        {
            Console.WriteLine("----- Student Management -----");
            Console.WriteLine("1. Add student.");
            Console.WriteLine("2. Update student information by ID.");
            Console.WriteLine("3. Remove student by ID.");
            Console.WriteLine("4. Search student by name.");
            Console.WriteLine("5. Sort students by average score (GPA).");
            Console.WriteLine("6. Sort students by name.");
            Console.WriteLine("7. Sort students by ID.");
            Console.WriteLine("8. Display student list.");
            Console.WriteLine("0. Exit.");
            Console.Write("Choose an option: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    UpdateStudent();
                    break;
                case 3:
                    RemoveStudent();
                    break;
                case 4:
                    SearchStudentByName();
                    break;
                case 5:
                    SortByGPA();
                    break;
                case 6:
                    SortByName();
                    break;
                case 7:
                    SortById();
                    break;
                case 8:
                    DisplayStudents();
                    break;
                case 0:
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        } while (choice != 0);
    }

    static void AddStudent()
    {
        
        Console.Write("Enter ID: ");
        var id = int.Parse(Console.ReadLine());

        var studentIdIsExisted = StudentExistedById(id);

        if(studentIdIsExisted == true)
        {
            Console.WriteLine("StudentId is exited. Please enter other id!");
            return;
        }

        Console.Write("Enter name: ");
        var name = Console.ReadLine();
        Console.Write("Enter gender: ");
        var gender = Console.ReadLine();
        Console.Write("Enter age: ");
        var age = int.Parse(Console.ReadLine());

        

        Console.Write("Enter Math score: ");
        var mathScore = double.Parse(Console.ReadLine());
      

        if (!filter.IsScoreValid(mathScore)){
            var msg = "Score is invalid";
            throw new InvalidScoreException(msg, mathScore);
        }
        
        Console.Write("Enter Physics score: ");
        var physicScore = double.Parse(Console.ReadLine());

        if (!filter.IsScoreValid(physicScore))
        {
            var msg = "Score is invalid";
            throw new InvalidScoreException(msg, physicScore);
        }

        Console.Write("Enter Chemistry score: ");
        var chemistryScore = double.Parse(Console.ReadLine());

        if (!filter.IsScoreValid(chemistryScore))
        {
            var msg = "Score is invalid";
            throw new InvalidScoreException(msg, chemistryScore);
        }
       
        Student student = new Student(id, name, age, gender, mathScore, physicScore, chemistryScore);

        students.Add(student);
        Console.WriteLine("Student added successfully.");
    }

    static bool StudentExistedById(int id)
    {
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].Id == id) return true;
        }
        return false;
    }


    static void UpdateStudent()
    {
        Console.Write("Enter ID of student to update: ");
        int id = int.Parse(Console.ReadLine());
        Student student = students.Find(s => s.Id == id);

        if (student != null)
        {
            Console.Write("Enter new name: ");
            student.Name = Console.ReadLine();
            Console.Write("Enter new gender: ");
            student.Gender = Console.ReadLine();
            Console.Write("Enter new age: ");
            student.Age = int.Parse(Console.ReadLine());
            Console.Write("Enter new Math score: ");
            student.MathScore = double.Parse(Console.ReadLine());
            Console.Write("Enter new Physics score: ");
            student.PhysicsScore = double.Parse(Console.ReadLine());
            Console.Write("Enter new Chemistry score: ");
            student.ChemistryScore = double.Parse(Console.ReadLine());
            Console.WriteLine("Student information updated successfully.");
        }
        else
        {
            Console.WriteLine("No student found with this ID.");
        }
    }

    

    static void RemoveStudent()
    {
        Console.Write("Enter ID of student to remove: ");
        int id = int.Parse(Console.ReadLine());
        Student student = students.Find(s => s.Id == id);

        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine("Student removed successfully.");
        }
        else
        {
            Console.WriteLine("No student found with this ID.");
        }
    }

    static void SearchStudentByName()
    {
        Console.Write("Enter name of student to search: ");
        string name = Console.ReadLine();
        List<Student> searchResults = students.FindAll(s => s.Name.Contains(name));

        if (searchResults.Count > 0)
        {
            Console.WriteLine("Search results:");
            DisplayStudentList(searchResults);
        }
        else
        {
            Console.WriteLine("No student found with this name.");
        }
    }

    static void SortByGPA()
    {
        List<Student> sortedList = students.OrderByDescending(s => s.AverageScore).ToList();
        Console.WriteLine("Student list sorted by GPA:");
        DisplayStudentList(sortedList);
    }

    static void SortByName()
    {
        List<Student> sortedList = students.OrderBy(s => s.Name).ToList();
        Console.WriteLine("Student list sorted by name:");
        DisplayStudentList(sortedList);
    }

    static void SortById()
    {
        List<Student> sortedList = students.OrderBy(s => s.Id).ToList();
        Console.WriteLine("Student list sorted by ID:");
        DisplayStudentList(sortedList);
    }

    static void DisplayStudents()
    {
        Console.WriteLine("Student list:");
        DisplayStudentList(students);
    }

    static void DisplayStudentList(List<Student> studentList)
    {
        Console.WriteLine("ID\tName\tGender\tAge\tMath\tPhysics\tChemistry\tAverage\tGPA");
        foreach (var student in studentList)
        {
            Console.WriteLine($"{student.Id}\t{student.Name}\t{student.Gender}\t{student.Age}\t{student.MathScore}\t{student.PhysicsScore}\t{student.ChemistryScore}\t{student.AverageScore}\t{student.GPA}");
        }
    }
}
