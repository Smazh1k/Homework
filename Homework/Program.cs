using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Homework
{
    internal class Program
    {
        static void Main()
        {
            using (var context = new DbContext())
            {
                var crud = new CrudOperations(context);

                Console.WriteLine("1. Dodaj nowy przedmiot");
                Console.WriteLine("2. Odczytaj przedmiot po ID");
                Console.WriteLine("3. Usuń przedmiot po ID");
                Console.WriteLine("4. Usuń przedmiot po typie");
                Console.WriteLine("0. Zakończ");

                while (true)
                {
                    Console.Write("Wybierz opcję: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Podaj nazwę przedmiotu: ");
                            var name = Console.ReadLine();
                            Console.Write("Podaj typ przedmiotu: ");
                            var type = Console.ReadLine();

                            var newItem = new Item { Name = name, Type = type };
                            crud.AddItem(newItem);
                            Console.WriteLine($"Dodano przedmiot: {newItem.Name}, Typ: {newItem.Type}, ID: {newItem.Id}");
                            break;

                        case "2":
                            Console.Write("Podaj ID przedmiotu: ");
                            if (int.TryParse(Console.ReadLine(), out var id))
                            {
                                var getItem = crud.GetItemById(id);
                                if (getItem != null)
                                {
                                    Console.WriteLine($"Znaleziono przedmiot: {getItem.Name}, Typ: {getItem.Type}, ID: {getItem.Id}");
                                }
                                else
                                {
                                    Console.WriteLine("Przedmiot o podanym ID nie istnieje.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nieprawidłowy format ID.");
                            }
                            break;

                        case "3":
                            Console.Write("Podaj ID przedmiotu do usunięcia: ");
                            if (int.TryParse(Console.ReadLine(), out var idToRemove))
                            {
                                crud.RemoveItemById(idToRemove);
                                Console.WriteLine("Przedmiot usunięty.");
                            }
                            else
                            {
                                Console.WriteLine("Nieprawidłowy format ID.");
                            }
                            break;

                        case "4":
                            Console.Write("Podaj typ przedmiotu do usunięcia: ");
                            var typeToRemove = Console.ReadLine();
                            crud.RemoveItemByType(typeToRemove);
                            Console.WriteLine("Przedmioty o podanym typie usunięte.");
                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Nieprawidłowy wybór. Wybierz ponownie.");
                            break;
                    }
                }
            }
        }
    }
}
