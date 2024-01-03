
using System;
using System.Collections.Generic;

class ToDoList
{
    private static readonly List<string> list = new();
    private static bool isParsingSuccessful;

    private static void AddTask()
    {
        const uint MAX_TASKS = 1000;
        if (list.Count > MAX_TASKS)
        {
            Console.WriteLine($"Cannot add more than {MAX_TASKS} tasks.");
            return;
        }

        string? userInput;
        Console.WriteLine("\n** Add Task **");

        do
        {
            Console.WriteLine("Enter task:-");
        }
        while (String.IsNullOrEmpty(userInput = Console.ReadLine()));

        list.Add(userInput);
    }

    private static void ChangeTask()
    {
        if (list.Count == 0)
        {
            Console.WriteLine("\n-- List Is Empty --");
            return;
        }

        Console.WriteLine("\n** Change Task **");
        int selectTaskIndex = SelectTask();
        string? userInput;

        do
        {
            Console.WriteLine("Enter new task:-");
        }
        while (String.IsNullOrEmpty(userInput = Console.ReadLine()));

        list.RemoveAt(selectTaskIndex);
        list.Insert(selectTaskIndex, userInput);
    }

    private static void RemoveTask()
    {
        if (list.Count == 0)
        {
            Console.WriteLine("\n-- List Is Empty --");
            return;
        }

        Console.WriteLine("\n** Remove Task **");
        int selectTaskIndex = SelectTask();
        list.RemoveAt(selectTaskIndex);
    }

    private static int SelectTask()
    {
        int selectTaskIndex;
        do
        {
            Console.Write("Select a task: ");
            isParsingSuccessful = int.TryParse(Console.ReadLine(), out selectTaskIndex);
        }
        while (!isParsingSuccessful || selectTaskIndex <= 0 || selectTaskIndex > list.Count);

        Console.WriteLine(list[selectTaskIndex - 1]);
        return selectTaskIndex - 1;
    }

    private static void DisplayAllTasks()
    {
        if (list.Count == 0)
        {
            Console.WriteLine("\n-- List Is Empty --");
            return;
        }

        Console.WriteLine("\n** Display All Task(s):- **");
        int index = 0;

        foreach (var element in list)
        {
            Console.WriteLine($"{++index}. {element}");
        }
    }

    private static void SelectionMenu()
    {
        char inputCharacter;
        do
        {
            Console.WriteLine("\n***** SELECTION MENU *****");
            Console.WriteLine("Press 'A' to add a task");
            Console.WriteLine("Press 'C' to replace a task");
            Console.WriteLine("Press 'R' to remove a task");
            Console.WriteLine("Press 'D' to display all tasks");
            Console.WriteLine("Press 'E' to exit");
            Console.Write("Enter your choice : ");
            isParsingSuccessful = char.TryParse(Console.ReadLine(), out inputCharacter);

            if (!isParsingSuccessful)
            {
                continue;
            }

            switch (inputCharacter)
            {
                case 'A':
                case 'a':
                    AddTask();
                    break;

                case 'C':
                case 'c':
                    ChangeTask();
                    break;

                case 'R':
                case 'r':
                    RemoveTask();
                    break;

                case 'D':
                case 'd':
                    DisplayAllTasks();
                    break;

                case 'E':
                case 'e':
                    Console.WriteLine("\nPress a key to exit....");
                    break;

                default:
                    Console.WriteLine("\n----- INVALID -----");
                    break;
            }
        }
        while (char.ToUpper(inputCharacter) != 'E');
    }

    static void Main()
    {
        Console.WriteLine("\tWelcome to To Do List\n");
        SelectionMenu();
        Console.ReadKey();
    }
}