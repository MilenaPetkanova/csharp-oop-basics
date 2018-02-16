using P03_StudentSystem;
using System;
using System.Collections.Generic;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public StudentSystem()
    {
        this.repo = new Dictionary<string, Student>();
    }

    public void ParseCommand(string command, Action<string> printFunc)
    {
        string[] args = command.Split();

        if (args[0] == "Create")
        {
            CreateStudent(args);
        }
        else if (args[0] == "Show")
        {
            var studentName = args[1];
            if (repo.ContainsKey(studentName))
            {
                printFunc(repo[studentName].ToString());
            }
        }
    }

    private void CreateStudent(string[] args)
    {
        var name = args[1];
        var age = int.Parse(args[2]);
        var grade = double.Parse(args[3]);
        if (!repo.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            repo[name] = student;
        }
    }
}