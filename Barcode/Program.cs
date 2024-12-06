using BarcodeLibrary;
using ShowcaseLibrary;
using ProductLibrary;

class Program
{
    static void TestLab1()
    {
        while (true)
        {
            Console.WriteLine("(Для выхода нажмите Enter)");
            Console.Write("Текст для кодирования: ");
            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                Barcode barcode = new(input);

                Console.WriteLine("(Для выхода нажмите Enter)");
                Console.WriteLine("1 - Только текст");
                Console.WriteLine("2 - Только штрих-код");
                Console.Write("3 - Полный вывод\n>>");

                string? choice = Console.ReadLine();
                if (!string.IsNullOrEmpty(choice))
                {
                    switch (choice)
                    {
                        case "1":
                            Barcode.Type = BarcodeType.Text;
                            break;

                        case "2":
                            Barcode.Type = BarcodeType.Barcode;
                            break;

                        case "3":
                            Barcode.Type = BarcodeType.Full;
                            break;

                        default:
                            Console.WriteLine("Неверная команда");
                            break;
                    };
                }
                else break;

                Console.WriteLine(barcode);
                Console.WriteLine();
            }
            else break;
        }
    }

    //static void TestLab2()
    //{
    //    Console.WriteLine("".PadLeft(80, '='));
    //    Showcase showcase1 = 6;
    //    Showcase showcase2 = 1;
    //    var sample = new Smartphone(6, "Xiaomi POCO M5", 4, 6.58, 50, "Чёрный");
    //    var lab2Data = new List<Phone> {
    //        new Smartphone(5, "Apple iPhone 16", 8, 6.1, 48, "Ультрамарин"),
    //        new Smartphone(4, "Samsung Galaxy S24 Ultra", 12,  6.8,  200, "Титановый чёрный"),
    //        new Smartphone(2, "OPPO Find N3", 16, 7.82, 48, "Золотой"),
    //        new Smartphone(3, "Tecno SPARK 30 5G", 12, 6.67, 108, "Мятный"),
    //        new Smartphone(1, "Sony Xperia 1 III", 12, 6.5, 12, "Чёрный")
    //    };

    //    foreach (var product in lab2Data)
    //        showcase1.Add(product);

    //    showcase1.Add(5, sample);

    //    Console.WriteLine("BEFORE:\n" + showcase1);
    //    showcase1.SortById();
    //    Console.WriteLine("AFTER sorting by ID:\n" + showcase1);

    //    showcase1.SortByModel();
    //    Console.WriteLine("AFTER sorting by MODEL:\n" + showcase1);

    //    showcase1.ShowcaseId++;
    //    Console.WriteLine("AFTER updating showcase1 ID:\n" + showcase1);

    //    showcase1.Delete();
    //    Console.WriteLine("AFTER deleting last item:\n" + showcase1);

    //    showcase1.Delete(3);
    //    Console.WriteLine("AFTER deleting #3:\n" + showcase1);

    //    showcase1.Swap(2, 0);
    //    Console.WriteLine("AFTER swapping #0 and #3:\n" + showcase1);

    //    showcase1.ReplaceItem(3, lab2Data[0]);
    //    Console.WriteLine("AFTER replacing #3 with Apple iPhone 16:\n" + showcase1);

    //    Console.WriteLine("Enter an ID: ");
    //    int query_id = Convert.ToInt32(Console.ReadLine());
    //    int index = showcase1.Search(query_id);
    //    Console.WriteLine($"{(index > -1 ? "Ячейка #" + index : "Не найден")}\n");

    //    Console.WriteLine("Enter an model: ");
    //    string query_model = Console.ReadLine();
    //    index = showcase1.Search(query_model);
    //    Console.WriteLine($"{(index > -1 ? "Ячейка #" + index : "Не найден")}\n");

    //    Showcase.MoveToShowcase(showcase1[1], showcase2);
    //    Console.WriteLine("AFTER moving #1 to showcase #2:\n" + showcase1);
    //    Console.WriteLine("AFTER moving #1 to showcase #2:\n" + showcase2);
    //}

    static void TestLab3()
    {
        Console.Clear();

        var lab3Data = new List<Phone> {
            new Smartphone(3000, "Samsung Galaxy S24 Ultra", 12, 6.8, 200, "Титановый чёрный"),
            new Smartphone(1000, "Sony Xperia 1 III", 12, 6.5, 12, "Чёрный"),
            new Smartphone(2000, "Xiaomi POCO M5", 4, 6.58, 50, "Чёрный")
        };
        var lab3Data2 = new List<FoldableSmartphone> {
            new(5555, "HONOR Magic V3", 12, 6.43, 50, "Чёрный", 7.92),
            new(6666, "OPPO Find N3 Flip", 16, 3.26, 48, "Золотой", 7.82)
        };

        IShowcase<IProduct> a1 = (Showcase<IProduct>)7;
        a1.ShowcaseId = 1;
        Showcase<FoldableSmartphone> a2 = (Showcase<FoldableSmartphone>)(3, 10);

        foreach (var item in lab3Data)
            a1.Add(item);

        foreach (var item in lab3Data2)
            a1.Add(item);

        a1.SortByModel();

        var sample1 = new FoldableSmartphone(7777, "Huawei Mate X3", 12, 6.4, 40, "Тёмно-зелёный", 7.85);
        var sample2 = new Smartphone(4000, "Apple iPhone 16", 8, 6.1, 48, "Ультрамарин");

        a2[0] = sample1;
        a1[5] = a2[0];
        a1[6] = sample2;

        Console.WriteLine("=== Смена ИД витрины a1");
        Console.WriteLine(a1.ShowcaseId);
        a1.ShowcaseId = 2;  // смена ИД витрины
        Console.WriteLine(a1.ShowcaseId);
        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("\n=== Смена ИД товара sample1");
        Console.WriteLine(sample1);
        sample1.Id++;       // смена ИД товара, должен сброситься и включать в себя только ИД товара
        Console.WriteLine(sample1);
        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("\n=== Смена ИД товара sample2 с перезаписью штрих-кода");
        Console.WriteLine(sample2);
        sample2.Id++;       // смена ИД товара, будет перезаписан штрих-код
        Console.WriteLine(sample2);
        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("\n=== Проверка правильного отображения штрих-кода");
        Console.WriteLine(a1);
        a2[0] = (FoldableSmartphone)a1[5];
        Console.WriteLine(a2);
    }

    static void Main(string[] args)
    {
        //TestLab1();
        //TestLab2();
        TestLab3();
        Console.ReadLine();
    }
}
