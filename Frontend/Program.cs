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
            Console.WriteLine($"Elemento '{dataToInsert}' adicionado en orden.");
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
            Console.WriteLine("La lista ha sido invertida físicamente a orden descendente.");
            Console.WriteLine(list);
            break;

        case "0": // Exit
            Console.WriteLine("Saliendo del sistema. ¡Éxitos en tu entrega!");
            break;

        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.");
            break;
    }

    if (option != "0")
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }

} while (option != "0");

string Menu()
{
    Console.WriteLine("=== TALLER 5: MENU LISTAS DOBLEMENTE LIGADAS ===");
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
