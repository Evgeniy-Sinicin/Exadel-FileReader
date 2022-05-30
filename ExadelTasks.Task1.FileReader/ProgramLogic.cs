using ExadelTasks.Task1.FileReader.Extensions;

namespace ExadelTasks.Task1.FileReader
{
    public static class ProgramLogic
    {
        private static List<string> _menuItems = new List<string>()
        {
            "Reflect .dll's from command line args",
            "Reflect .dll from custom input",
            "Clear console",
            "Exit"
        };

        public static int ExitNumber { get => _menuItems.Count; }

        public static void StartProgram(string[] args)
        {
            bool isNeedRepeat = true;

            do
            {
                bool isValidNumber, isNumberInDiapason, isExitNumber;
                string? sSelectedItem;

                ShowMenu();
                sSelectedItem = Console.ReadLine();
                Console.WriteLine();
                isValidNumber = int.TryParse(sSelectedItem, out int iSelectedItem);

                if (isValidNumber)
                {
                    isExitNumber = iSelectedItem == ExitNumber;

                    if (!isExitNumber)
                    {
                        isNumberInDiapason = iSelectedItem >= 1 && iSelectedItem <= ExitNumber;

                        if (isNumberInDiapason)
                        {
                            ExecuteMenuItem(iSelectedItem, args);
                        }
                        else
                        {
                            Console.WriteLine("Error! Selected menu item is out of list");
                        }
                    }
                    else
                    {
                        isNeedRepeat = false;
                        Console.WriteLine("Ciao :)");
                    }
                }
                else
                {
                    Console.WriteLine("Error! Not number was entered");
                }
            }
            while (isNeedRepeat);
        }

        public static void ShowMenu()
        {
            for (int i = 0; i < ExitNumber; i++)
            {
                Console.WriteLine($"{i + 1}. {_menuItems[i]}");
            }

            Console.Write("Selected item: ");
        }

        private static void ExecuteMenuItem(int itemNumber, string[] args)
        {
            switch (itemNumber)
            {
                case 1:
                    ReflectFromCommandLine(args);
                    break;
                case 2:
                    ReflectFromCustomInput();
                    break;
                case 3:
                    ClearConsole();
                    break;
            }
        }

        private static void ReflectFromCommandLine(string[] args)
        {
            Array.ForEach(args, path =>
            {
                Console.WriteLine($"File path: {path}\n");
                ShowFileInfo(path);
            });
        }

        private static void ReflectFromCustomInput()
        {
            Console.Write("Path to .dll file: ");
            ShowFileInfo(Console.ReadLine());
        }
        
        private static void ClearConsole()
        {
            Console.Clear();
        }

        private static void ShowFileInfo(string path)
        {
            FileMetadata? fileMeta;

            if (File.Exists(path))
            {
                try
                {
                    fileMeta = new FileMetadata(path);

                    Console.WriteLine($"Types count: {fileMeta?.Types.Length}\n");

                    foreach (var type in fileMeta.Types)
                    {
                        Console.WriteLine($"Type: {type}");

                        foreach (var method in FileMetadata.GetTypeMethods(type))
                        {
                            Console.WriteLine(method.GetInfo());

                            if (method.IsExecutable())
                            {
                                Console.WriteLine();
                                Console.WriteLine("Static method without params was found.");
                                Console.WriteLine("Press Enter to execute it or other key to continue...");
                                if (Console.ReadKey().Key == ConsoleKey.Enter)
                                {
                                    Console.WriteLine($"Method returned object: {method.Invoke(null, null)}");
                                }
                                Console.WriteLine();
                            }
                        }

                        foreach (var property in FileMetadata.GetTypeProperties(type))
                        {
                            Console.WriteLine(property.GetInfo());
                        }

                        foreach (var field in FileMetadata.GetTypeFields(type))
                        {
                            Console.WriteLine(field.GetInfo());
                        }

                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine($"Path '{path}' isn't exist\n");
            }
        }
    }
}
