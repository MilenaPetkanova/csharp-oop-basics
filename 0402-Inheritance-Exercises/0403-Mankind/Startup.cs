using System;

class Startup
{
    static void Main()
    {
        try
        {
            Student student = InitializeNewStudent();
            Worker worker = InitializeNewWorker();
            PrintOutput(student, worker);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    private static void PrintOutput(Student student, Worker worker)
    {
        Console.WriteLine(student + Environment.NewLine);
        Console.WriteLine(worker);
    }

    private static Worker InitializeNewWorker()
    {
        var workerArgs = Console.ReadLine().Split();
        var firstName = workerArgs[0];
        var secondName = workerArgs[1];
        var salary = decimal.Parse(workerArgs[2]);
        var workingHours = double.Parse(workerArgs[3]);
        var worker = new Worker(firstName, secondName, salary, workingHours);
        return worker;
    }

    private static Student InitializeNewStudent()
    {
        var studentArgs = Console.ReadLine().Split();
        var firstName = studentArgs[0];
        var secondName = studentArgs[1];
        var facultyNumber = studentArgs[2];
        var student = new Student(firstName, secondName, facultyNumber);
        return student;
    }
}
