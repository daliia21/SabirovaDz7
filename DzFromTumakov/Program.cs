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

            string input = "Hello, World!";
            string reversed = ReverseString(input);
            Console.WriteLine($"Original: {input}");
            Console.WriteLine($"Reversed: {reversed}");
        }

        static void Task3()
        {
            /*Упражнение 8.3 Написать программу, которая спрашивает у пользователя имя файла. Если
            такого файла не существует, то программа выдает пользователю сообщение и заканчивает
            работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными
            буквами.*/

            Console.WriteLine("Упражнение 8.3");


        }

        static void Main()
        {
            Task1();
        }
    }
}
