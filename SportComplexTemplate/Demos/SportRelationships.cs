using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SportComplexTemplate.Data;

namespace SportComplexTemplate.Demos
{
    public static class SportRelationships
    {
        public static void RunDemo(SportComplexDbContext context)
        {
            Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ: СВЯЗИ СУЩНОСТЕЙ (RELATIONSHIPS) ===");

            // 1. Демонстрация связи «Один ко многим»
            Console.WriteLine("\n1. Связь 'Один ко многим' (Абонементы и зарегистрированные клиенты):");
            var memberships = context.Memberships.Include(m => m.Clients).ToList();

            foreach (var m in memberships)
            {
                Console.WriteLine($"Тариф: '{m.Name}' (Цена: {m.Price} руб.)");
                if (!m.Clients.Any())
                {
                    Console.WriteLine("   [-] Нет активных клиентов по данному тарифу");
                }
                else
                {
                    foreach (var client in m.Clients)
                    {
                        Console.WriteLine($"   [-] Клиент: {client.FullName} (Возраст: {client.Age})");
                    }
                }
            }

            // 2. Демонстрация связи «Один к одному»
            Console.WriteLine("\n2. Связь 'Один к одному' (Закрепление электронных ключей за клиентами):");
            var clientsWithKeys = context.Clients.Include(c => c.LockerKey).ToList();

            foreach (var c in clientsWithKeys)
            {
                string keyInfo = c.LockerKey != null
                    ? $"Шкафчик N {c.LockerKey.KeyNumber}"
                    : "Ключ не выдан";

                Console.WriteLine($"Спортсмен: {c.FullName,-30} -> Выданный электронный доступ: {keyInfo}");
            }
        }
    }
}
