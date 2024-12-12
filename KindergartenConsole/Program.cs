using System;
using System.Linq;
using Kindergarten1;
using Kindergarten1.DataBases;

namespace KindergartenConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Получаем контекст базы данных
            var dbContext = data.GetContext();

            // Пример: Вывод всех пользователей из таблицы user
            Console.WriteLine("Список пользователей:");
            var users = data.GetUser();
            foreach (var user in users)
            {
                Console.WriteLine($"Логин: {user.login}, Пароль: {user.password}");
            }

            // Пример: Вывод всех детей из таблицы Deti
            Console.WriteLine("\nСписок детей:");
            var deti = dbContext.Deti.ToList();
            foreach (var det in deti)
            {
                Console.WriteLine($"Имя: {det.FName}, Фамилия: {det.LName}, Телефон родителя: {det.Phone_roditelya}, Группа: {det.Id_gruppa}");
            }

            // Пример: Вывод всех мероприятий из таблицы meropriyatie
            Console.WriteLine("\nСписок мероприятий:");
            var meropriyatie = dbContext.meropriyatie.ToList();
            foreach (var mer in meropriyatie)
            {
                Console.WriteLine($"Название: {mer.Nazvanie}, Дата: {mer.Date}, Цена: {mer.price}, Кружок: {mer.Id_krygok}");
            }

            // Пример: Добавление нового ребенка
            Console.WriteLine("\nДобавление нового ребенка:");
            Console.Write("Введите имя ребенка: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите фамилию ребенка: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите телефон родителя: ");
            string phone = Console.ReadLine();
            Console.Write("Введите ID группы: ");
            int groupId = int.Parse(Console.ReadLine());

            var newChild = new Deti
            {
                FName = firstName,
                LName = lastName,
                Phone_roditelya = phone,
                Id_gruppa = groupId
            };

            dbContext.Deti.Add(newChild);
            dbContext.SaveChanges();

            Console.WriteLine("Ребенок успешно добавлен!");

            // Пример: Удаление ребенка
            Console.WriteLine("\nУдаление ребенка:");
            Console.Write("Введите ID ребенка для удаления: ");
            int childIdToDelete = int.Parse(Console.ReadLine());

            var childToDelete = dbContext.Deti.FirstOrDefault(c => c.Id_dati == childIdToDelete);
            if (childToDelete != null)
            {
                dbContext.Deti.Remove(childToDelete);
                dbContext.SaveChanges();
                Console.WriteLine("Ребенок успешно удален!");
            }
            else
            {
                Console.WriteLine("Ребенок не найден.");
            }

            // Пример: Обновление данных ребенка
            Console.WriteLine("\nОбновление данных ребенка:");
            Console.Write("Введите ID ребенка для обновления: ");
            int childIdToUpdate = int.Parse(Console.ReadLine());

            var childToUpdate = dbContext.Deti.FirstOrDefault(c => c.Id_dati == childIdToUpdate);
            if (childToUpdate != null)
            {
                Console.Write("Введите новое имя ребенка: ");
                string newFirstName = Console.ReadLine();
                Console.Write("Введите новую фамилию ребенка: ");
                string newLastName = Console.ReadLine();
                Console.Write("Введите новый телефон родителя: ");
                string newPhone = Console.ReadLine();
                Console.Write("Введите новый ID группы: ");
                int newGroupId = int.Parse(Console.ReadLine());

                childToUpdate.FName = newFirstName;
                childToUpdate.LName = newLastName;
                childToUpdate.Phone_roditelya = newPhone;
                childToUpdate.Id_gruppa = newGroupId;

                dbContext.SaveChanges();
                Console.WriteLine("Данные ребенка успешно обновлены!");
            }
            else
            {
                Console.WriteLine("Ребенок не найден.");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}