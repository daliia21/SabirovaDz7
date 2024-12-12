using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzFromFile.AbstractModels
{
    internal class Employee
    {
        public string Name { get; }
        public string Role { get; }
        public Employee Manager { get; }
        public List<Employee> Subordinates { get; }

        public Employee(string name, string role, Employee manager = null)
        {
            Name = name;
            Role = role;
            Manager = manager;
            Subordinates = new List<Employee>();

            if (manager != null)
            {
                manager.Subordinates.Add(this);
            }
        }

        public bool CanAssignTask(Employee from)
        {
            Employee current = this;

            while (current != null)
            {
                if (current == from)
                    return true;

                current = current.Manager;
            }

            return false;
        }

        public void AssignTask(Employee from, string task)
        {
            if (CanAssignTask(from))
            {
                Console.WriteLine($"{from.Name} даёт задачу \"{task}\" {Name}. Задача принята.");
            }
            else
            {
                Console.WriteLine($"{from.Name} даёт задачу \"{task}\" {Name}. Задача отклонена.");
            }
        }
    }
}
