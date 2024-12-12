using DzFromTumakov.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzFromTumakov.AbstractModels
{
    class BankAccount
    {
        private static int currentId = 1;



        private int accountNumber;
        private decimal balance;
        private BankAccountType bankAccountType;

        public BankAccount(decimal balance, BankAccountType bankAccountType)
        {
            accountNumber = currentId++;

            this.balance = balance;
            this.bankAccountType = bankAccountType;
        }

        public void ShowInfo()
        {
            ShowMessage($"Номер счета: {accountNumber}, Баланс: {balance}, Тип счета: {bankAccountType}");
        }

        private void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void Input(int amountOfMoney)
        {
            if (amountOfMoney > balance)
            {
                ShowMessage("На счёте недостаточно средств денег");
            }
            else
            {
                balance -= amountOfMoney;
                ShowMessage("Деньги успешно сняты!");
            }
        }

        public void Output(int amountOfMoney)
        {
            balance += amountOfMoney;
            ShowMessage("Счет успешно пополнен!");
        }

        public void Transfer(BankAccount otherAccount, decimal amount)
        {
            if (otherAccount == null)
            {
                ShowMessage("Счет для перевода не существует.");
                return;
            }

            if (amount <= 0)
            {
                ShowMessage("Сумма перевода должна быть больше нуля.");
                return;
            } 

            if (balance < amount)
            {
                ShowMessage("На счёте недостаточно средств для перевода.");
                return;
            }

            balance -= amount;
            otherAccount.balance += amount;

            ShowMessage($"Переведено {amount} со счета {accountNumber} на счет {otherAccount.accountNumber}.");
        }
    }
}
