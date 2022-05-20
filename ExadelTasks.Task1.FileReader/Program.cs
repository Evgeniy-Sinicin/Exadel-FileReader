using ExadelTasks.Task1.FileReader;

while (true)
{
    var isInputPathCorrect = false;
    FileMetadata fileMeta = null;

    do
    {
        Console.WriteLine("Enter path to external .dll:");

        try
        {
            fileMeta = new FileMetadata(Console.ReadLine());

            isInputPathCorrect = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    while (!isInputPathCorrect);

    Console.WriteLine($"Types count: {fileMeta.Types.Length}\n");

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
