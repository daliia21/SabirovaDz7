using DzFromTumakov.AbstractModels;
using DzFromTumakov.Enums;


namespace DzFromTumakov
{
    internal class Program
    {
        static void Task1()
        {
            /*Упражнение 8.1 В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить
            метод, который переводит деньги с одного счета на другой. У метода два параметра: ссылка
            на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.*/

            Console.WriteLine("Упражнение 8.1");

            BankAccount bankAccount = new BankAccount(100, BankAccountType.Accumulation);

            bankAccount.ShowInfo();

            BankAccount bankAccount1 = new BankAccount(120, BankAccountType.Savings);
            
            bankAccount1.ShowInfo();

            bankAccount.Transfer(bankAccount1, 50);

            bankAccount.ShowInfo();

            bankAccount1.ShowInfo();
            
        }
        static void Task2()
        {
            /*Упражнение 8.2 Реализовать метод, который в качестве входного параметра принимает
            строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.
            Протестировать метод.*/

            Console.WriteLine("Упражнение 8.2");

            string input = Console.ReadLine()!;
            string reversed = ReverseString(input);

            Console.WriteLine($"Исходный текст: {input}");
            Console.WriteLine($"Перевернутый текст: {reversed}");
        }

        static string ReverseString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);

        }


        static void Task3()
        {
            /*Упражнение 8.3 Написать программу, которая спрашивает у пользователя имя файла. Если
            такого файла не существует, то программа выдает пользователю сообщение и заканчивает
            работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными
            буквами.*/

            Console.WriteLine("Упражнение 8.3");
            Console.Write("Введите имя файла: ");
            string inputFileName = Console.ReadLine();
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);


            if (!File.Exists(inputFileName))
            {
                Console.WriteLine("Файл не найден. Завершение программы.");
                return;
            }

            FileCheck(inputFileName);
        }

        static void FileCheck(string inputFileName)
        
        {
            string outputFileName = "new" + inputFileName;

            try
            {
                string content = File.ReadAllText(inputFileName);
                string upperContent = content.ToUpper();
                File.WriteAllText(outputFileName, upperContent);
                Console.WriteLine($"Содержимое файла записано в {outputFileName} заглавными буквами.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        static void Task4()
        {
            /*Упражнение 8.4 Реализовать метод, который проверяет реализует ли входной параметр
            метода интерфейс System.IFormattable. Использовать оператор is и as. (Интерфейс
            IFormattable обеспечивает функциональные возможности форматирования значения объекта
            в строковое представление.)*/

            Console.WriteLine("Упражнение 8.4");

            object testValue1 = 123.45;
            object testValue2 = "Hello, World!";

            CheckIfFormattable(testValue1);
            CheckIfFormattable(testValue2);
        }


        public static void CheckIfFormattable(object value)
        {
            if (value is IFormattable)
            {
                Console.WriteLine($"Объект типа {value.GetType().Name} реализует IFormattable.");
            }
            else
            {
                Console.WriteLine($"Объект типа {value.GetType().Name} не реализует IFormattable.");
            }

            var formattableValue = value as IFormattable;
            if (formattableValue != null)
            {
                Console.WriteLine($"С использованием 'as': Объект типа {value.GetType().Name} реализует IFormattable.");
            }
            else
            {
                Console.WriteLine($"С использованием 'as': Объект типа {value.GetType().Name} не реализует IFormattable.");
            }
        }

        static void Task5()
        {
            /*Домашнее задание 8.1 Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail
            адрес. Разделителем между ФИО и адресом электронной почты является символ #:
            Иванов Иван Иванович # iviviv@mail.ru
            Петров Петр Петрович # petr@mail.ru
            Сформировать новый файл, содержащий список адресов электронной почты.
            Предусмотреть метод, выделяющий из строки адрес почты. Методу в
            качестве параметра передается символьная строка s, e-mail возвращается в той же строке s:
            public void SearchMail (ref string s).*/

            Console.WriteLine("Домашнее задание 8.1");
            
            string inputFile = "input.txt";
            string outputFile = "emails.txt";

            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), inputFile);

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Файл с входными данными не найден.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(inputFile);
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    foreach (string line in lines)
                    {
                        string email = line;
                        SearchMail(ref email);
                        if (!string.IsNullOrEmpty(email))
                        {
                            writer.WriteLine(email);
                        }
                    }
                }

                Console.WriteLine($"Адреса электронной почты сохранены в файл {outputFile}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
            
        }

        public static void SearchMail(ref string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                email = string.Empty;
                return;
            }

            int hashIndex = email.IndexOf('#');
            if (hashIndex != -1 && hashIndex + 1 < email.Length)
            {
                email = email.Substring(hashIndex + 1).Trim();
            }
            else
            {
                email = string.Empty; 
            }
        }

        static void Task6()
        {
            /*Домашнее задание 8.2 Список песен. В методе Main создать список из четырех песен. В
            цикле вывести информацию о каждой песне. Сравнить между собой первую и вторую
            песню в списке. Песня представляет собой класс с методами для заполнения каждого из
            полей, методом вывода данных о песне на печать, методом, который сравнивает между
            собой два объекта:
            class Song{
            string name; //название песни
            string author; //автор песни
            Song prev; //связь с предыдущей песней в списке
            //метод для заполнения поля name

            //метод для заполнения поля author
            //метод для заполнения поля prev
            //метод для печати названия песни и ее исполнителя
            public string Title(){... /*возвращ название+исполнитель*/
            //...}
            //метод, который сравнивает между собой два объекта-песни:
            //public bool override Equals(object d) { ...}
            //}

            Console.WriteLine("Домашнее задание 8.2");
            
            Song song1 = new Song("Song A", "Author A");
            Song song2 = new Song("Song B", "Author B", song1);

            song2.PrintChain();

            Console.WriteLine(song1.Equals(song2)); 
            Console.WriteLine(song1.Equals(new Song("Song A", "Author A")));

        }
        static void Main()
        {
            //Task1();
            //Task2();
            //Task3();
            //Task4();
            //Task5();
            Task6();
        }
    }
}
