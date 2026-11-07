using Backend;

var list = new DoublyLinkedList<string>();
var option = string.Empty;

do
{
    option = Menu();
    switch (option)
    {
        case "1": // Add
            Console.Write("Ingrese el valor a adicionar: ");
            var dataToInsert = Console.ReadLine()!;
            list.Add(dataToInsert);
            Console.WriteLine($"Elemento '{dataToInsert}' adicionado");
            break;

        case "2": // Show forward
            Console.WriteLine("\nLista hacia adelante:");
            Console.WriteLine(list);
            break;

        case "3": // Show backward
            Console.WriteLine("\nLista hacia atrás:");
            Console.WriteLine(list.ToStringReverse());
            break;

        case "4": // Sort in descending order
            list.SortDescending();
            Console.WriteLine("La lista ha sido ordenada de forma descendente.");
            Console.WriteLine(list);
            break;

        case "5": // Show mode
            var modes = list.GetModes();
            if (modes.Count == 0)
            {
                Console.WriteLine("La lista está vacía.");
            }
            else if (modes.Count == 1)
            {
                Console.WriteLine($"La moda es: {modes[0]}");
            }
            else
            {
                Console.WriteLine($"Las modas son: {string.Join(", ", modes)}");
            }
            break;
        case "6": // 
            Console.WriteLine("\nGráfico de ocurrencias:");
            Console.WriteLine(list.GenerateGraph());
            break;

        case "7": // 
            Console.Write("Ingrese el valor a buscar: ");
            var itemToSearch = Console.ReadLine()!;
            Console.WriteLine(list.Contains(itemToSearch)
                ? $"El elemento: '{itemToSearch}' ¡SÍ existe!"
                : $"El elemento: '{itemToSearch}' NO existe.");
            break;

        case "8": // 
            Console.Write("Ingrese el valor a eliminar (una ocurrencia): ");
            var itemToRemoveOne = Console.ReadLine()!;
            if (list.RemoveOne(itemToRemoveOne))
            {
                Console.WriteLine($"La primera ocurrencia de '{itemToRemoveOne}' fue eliminada.");
            }
            else
            {
                Console.WriteLine($"El elemento '{itemToRemoveOne}' no existe en la lista.");
            }
            break;

        case "9": //
            Console.Write("Ingrese el valor a eliminar (todas las ocurrencias): ");
            var itemToRemoveAll = Console.ReadLine()!;
            int removedCount = list.RemoveAll(itemToRemoveAll);
            if (removedCount > 0)
            {
                Console.WriteLine($"Se eliminaron {removedCount} ocurrencia(s) de '{itemToRemoveAll}'.");
            }
            else
            {
                Console.WriteLine($"El elemento '{itemToRemoveAll}' no existe en la lista.");
            }
            break;

        case "0": // Exit
            break;

        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.");
            break;
    }

  

} while (option != "0");

string Menu()
{
    Console.WriteLine(" ");
    Console.WriteLine("MENU");
    Console.WriteLine("1. Adicionar.");
    Console.WriteLine("2. Mostrar hacia adelante.");
    Console.WriteLine("3. Mostrar hacia atrás.");
    Console.WriteLine("4. Ordenar descendentemente.");
    Console.WriteLine("5. Mostrar la(s) moda(s).");
    Console.WriteLine("6. Mostrar gráfico.");
    Console.WriteLine("7. Existe.");
    Console.WriteLine("8. Eliminar una ocurrencia.");
    Console.WriteLine("9. Eliminar todas las ocurrencias.");
    Console.WriteLine("0. Salir.");
    Console.Write("Seleccione una opción: ");
    return Console.ReadLine()!;
}
