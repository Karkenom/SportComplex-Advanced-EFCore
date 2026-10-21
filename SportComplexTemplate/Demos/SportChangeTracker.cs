using System;
using Microsoft.EntityFrameworkCore;
using SportComplexTemplate.Data;
using SportComplexTemplate.Models;

namespace SportComplexTemplate.Demos
{
    public static class SportChangeTracker
    {
        public static void RunDemo(SportComplexDbContext context)
        {
            Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ: CHANGE TRACKER (Отслеживание состояний) ===");

            // 1. Состояние Detached
            var newClient = new Client { FullName = "Кузнецов Олег Петрович", Age = 28, MembershipId = 1 };
            PrintState(context, newClient, "После создания объекта");

            // 2. Состояние Added
            context.Clients.Add(newClient);
            PrintState(context, newClient, "После вызова метода context.Clients.Add()");

            // 3. Состояние Unchanged
            context.SaveChanges();
            PrintState(context, newClient, "После вызова метода context.SaveChanges()");

            // 4. Состояние Modified
            newClient.Age = 29;
            PrintState(context, newClient, "После изменения возраста (Age = 29)");

            // 5. Состояние Deleted
            context.Clients.Remove(newClient);
            PrintState(context, newClient, "После вызова метода context.Clients.Remove()");

            // Фиксируем удаление в базе данных
            context.SaveChanges();
        }

        private static void PrintState(SportComplexDbContext context, Client client, string actionDescription)
        {
            var state = context.Entry(client).State;
            Console.WriteLine($"Действие: {actionDescription,-45} | Текущее состояние EF Core: {state}");
        }
    }
}
