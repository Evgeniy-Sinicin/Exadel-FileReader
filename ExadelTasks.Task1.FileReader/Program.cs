using ExadelTasks.Task1.FileReader;
using ExadelTasks.Task1.FileReader.Extensions;

FileMetadata? fileMeta = null;

Array.ForEach(args, path =>
{
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
        Console.WriteLine($"Path '{path}' isn't exist");
    }
});
