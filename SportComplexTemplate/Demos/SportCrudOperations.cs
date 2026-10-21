using System;
using System.Linq;
using SportComplexTemplate.Data;
using SportComplexTemplate.Models;

namespace SportComplexTemplate.Demos
{
    public static class SportCrudOperations
    {
        public static void RunDemo(SportComplexDbContext context)
        {
            Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ: БАЗОВЫЕ ОПЕРАЦИИ CRUD ===");

            // 1. CREATE
            Console.WriteLine("\n[CREATE] Добавляем нового клиента...");
            var tempClient = new Client { FullName = "Попова Анна Игоревна", Age = 22, MembershipId = 2 };
            context.Clients.Add(tempClient);
            context.SaveChanges();
            Console.WriteLine($"Клиент {tempClient.FullName} успешно сохранен с ID: {tempClient.Id}");

            // 2. READ
            Console.WriteLine("\n[READ] Читаем информацию о клиенте из БД...");
            var dbClient = context.Clients.FirstOrDefault(c => c.Id == tempClient.Id);
            if (dbClient != null)
            {
                Console.WriteLine($"Найден клиент: {dbClient.FullName}, Возраст: {dbClient.Age} лет");
            }

            // 3. UPDATE
            Console.WriteLine("\n[UPDATE] Переводим клиента на другой абонемент...");
            if (dbClient != null)
            {
                dbClient.MembershipId = 3;
                context.SaveChanges();
                Console.WriteLine($"Данные обновлены. Новый ID абонемента у клиента: {dbClient.MembershipId}");
            }

            // 4. DELETE
            Console.WriteLine("\n[DELETE] Удаляем тестового клиента из базы данных...");
            if (dbClient != null)
            {
                context.Clients.Remove(dbClient);
                context.SaveChanges();

                // Проверяем удаление
                var checkedClient = context.Clients.FirstOrDefault(c => c.Id == tempClient.Id);
                Console.WriteLine(checkedClient == null ? "Клиент успешно удален из БД." : "Ошибка удаления.");
            }
        }
    }
}
