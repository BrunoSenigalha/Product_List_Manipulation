using Predicate_PersonalExercise.Entities;
using Predicate_PersonalExercise.Services;

Product product;
List<Product> list = new List<Product>();
HashSet<Product> set;
bool exit = false;

do
{
    Console.WriteLine("........Product Menu........\n");

    Console.WriteLine("Type an option number: ");
    Console.WriteLine("1 - Read list of existing product");
    Console.WriteLine("2 - Register product");
    Console.WriteLine("3 - Remove duplicate product");
    Console.WriteLine("4 - Sort by price");
    Console.WriteLine("5 - List products");
    Console.WriteLine("6 - Remove by filter");
    Console.WriteLine("7 - Exit");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();
            List<Product> list2 = new List<Product>(StreamReaderService.ReadLog(path));
            foreach (Product products in list2)
                list.Add(products);

            Console.WriteLine("All products have been added");
            break;

        case "2":
            Console.Clear();
            Console.Write("Enter a products name: ");
            string name = Console.ReadLine();
            Console.Write("Enter a products price: ");
            double price = Convert.ToDouble(Console.ReadLine());
            product = new Product(name, price);
            list.Add(product);
            break;

        case "3":
            Console.Clear();
            List<Product> uniqueProducts = list.Distinct(new RemoveDuplicate()).ToList();
            list = new List<Product>(uniqueProducts);
            break;

        case "4":
            Console.Clear();
            Comparison<Product> comparison = (p1, p2) => p1.Price.CompareTo(p2.Price);
            list.Sort(comparison);
            Console.WriteLine();
            break;

        case "5":
            Console.Clear();
            Console.WriteLine();
            foreach (Product products in list)
                Console.WriteLine(products);

            break;

        case "6":
            Console.Clear();
            Console.WriteLine("Type a price that you'd like to remove (equal or greater): ");
            double number = Convert.ToDouble(Console.ReadLine());
            list.RemoveAll(p => p.Price >= number);
            break;

        case "7":
            Console.Clear();
            Console.WriteLine("Exit.....");
            exit = true;
            break;

        default:
            Console.WriteLine("Wrong choice");
            break;
    }

} while (exit != true); 