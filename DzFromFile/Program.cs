using DzFromFile.AbstractModels;

namespace DzFromFile
{
    internal class Program
    {
        static void Task()
        {
            Employee timur = new Employee("Тимур", "Генеральный директор");
            Employee rashid = new Employee("Рашид", "Финансовый директор", timur);
            Employee ilham = new Employee("О Ильхам", "Директор по автоматизации", timur);
            Employee lukas = new Employee("Лукас", "Бухгалтер", rashid);

            Employee arkadiy = new Employee("Оркадий", "Начальник ИТ", ilham);
            Employee volodya = new Employee("Володя", "Зам. начальника ИТ", ilham);

            Employee ilshat = new Employee("Ильшат", "Главный системщик", arkadiy);
            Employee ivanych = new Employee("Иваныч", "Зам. системщика", arkadiy);
            Employee ilya = new Employee("Илья", "Системщик", ilshat);
            Employee vitia = new Employee("Витя", "Системщик", ilshat);
            Employee zhenya = new Employee("Женя", "Системщик", ilshat);

            Employee sergey = new Employee("Сергей", "Главный разработчик", arkadiy);
            Employee laisan = new Employee("Ляйсан", "Зам. разработчика", sergey);
            Employee marat = new Employee("Марат", "Разработчик", laisan);
            Employee dina = new Employee("Дина", "Разработчик", laisan);
            Employee ildar = new Employee("Ильдар", "Разработчик", laisan);
            Employee anton = new Employee("Антон", "Разработчик", laisan);

            ilshat.AssignTask(arkadiy, "Настроить сеть"); 
            marat.AssignTask(dina, "Обновить модуль"); 
            laisan.AssignTask(sergey, "Проверить код"); 
            ilham.AssignTask(timur, "Автоматизировать отчёты"); 
            lukas.AssignTask(rashid, "Подготовить баланс");
        }

        static void Main()
        {
            Task();
        }
    }
}
