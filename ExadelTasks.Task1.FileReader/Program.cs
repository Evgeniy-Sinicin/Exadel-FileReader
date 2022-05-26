using ExadelTasks.Task1.FileReader;

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
                    Console.WriteLine($"Method: {method}");
                }

                foreach (var property in FileMetadata.GetTypeProperties(type))
                {
                    Console.WriteLine($"Property: {property}");
                }

                foreach (var member in FileMetadata.GetTypeMembers(type))
                {
                    Console.WriteLine($"Member: {member}");
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
