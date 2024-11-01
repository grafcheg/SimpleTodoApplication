namespace SimpleTodoApplication
{
    internal class Program
    {
        enum UserChoice
        {
            AddTask = 1,
            DeleteTask,
            Exit
        }

        static void Main(string[] args)
        {
            List<string> toDoList = new List<string>();

            while (true) 
            {
                if (toDoList.Count > 0)
                {
                    Console.WriteLine("Your To-do list:");

                    for (int i = 0; i < toDoList.Count; i++)
                    {
                        Console.WriteLine($" - {toDoList[i]}");
                    }

                    Console.WriteLine("");
                }
                else 
                {
                    Console.WriteLine("You currently have no tasks in your To-do list. \n");
                }

                Console.WriteLine("1. Add task");
                Console.WriteLine("2. Delete task");
                Console.WriteLine("3. Exit");
                Console.Write("Enter the number of option you want to do: ");

                var userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int result))
                {
                    if (result <= 0 || result > Enum.GetNames(typeof(UserChoice)).Length)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input! Try again.");
                        continue;
                    }

                    if (result == (int)UserChoice.AddTask)
                    {
                        Console.Write("Enter task: ");
                        string task = Console.ReadLine();
                        toDoList.Add(task);
                        Console.Clear();
                        Console.WriteLine("Task added successfully!");
                    }
                    else if (result == (int)UserChoice.DeleteTask)
                    {
                        if (toDoList.Count > 0)
                        {
                            Console.WriteLine("Enter the number of the task you want to delete:");

                            for (int i = 0; i < toDoList.Count; i++)
                            {
                                Console.WriteLine($"({i + 1}) {toDoList[i]}");
                            }

                            if (int.TryParse(Console.ReadLine(), out int taskNumber))
                            {
                                taskNumber--;

                                if (taskNumber >= 0 && taskNumber < toDoList.Count)
                                {
                                    toDoList.RemoveAt(taskNumber);
                                    Console.Clear();
                                    Console.WriteLine("Task deleted succesfully! \n");
                                }
                                else 
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid task number. \n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. \n");
                            }
                        }
                    }
                    else if (result == (int)UserChoice.Exit)
                    {
                        Console.WriteLine("Quiting...");
                        break;
                    }
                }
            }
        }
    }
}
