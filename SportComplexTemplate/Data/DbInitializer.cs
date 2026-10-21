using System.Collections.Generic;
using System.Linq;
using SportComplexTemplate.Models;

namespace SportComplexTemplate.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SportComplexDbContext context)
        {
            // Сбрасываем и создаем БД заново для обновления таблиц
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Memberships.Any()) return;

            // 1. Добавляем абонементы
            var memberships = new List<Membership>
            {
                new Membership { Name = "Месячный Безлимит", Price = 3500 },
                new Membership { Name = "Дневной Лайт", Price = 2000 },
                new Membership { Name = "Годовой VIP", Price = 25000 }
            };
            context.Memberships.AddRange(memberships);
            context.SaveChanges();

            // 2. Добавляем клиентов
            var clients = new List<Client>
            {
                new Client { FullName = "Миронов Артем Сергеевич", Age = 25, MembershipId = memberships[0].Id },
                new Client { FullName = "Смирнова Дарья Дмитриевна", Age = 19, MembershipId = memberships[0].Id },
                new Client { FullName = "Козлов Иван Алексеевич", Age = 34, MembershipId = memberships[1].Id }
            };
            context.Clients.AddRange(clients);
            context.SaveChanges();

            // 3. Добавляем ключи от шкафчиков
            var keys = new List<LockerKey>
            {
                new LockerKey { KeyNumber = "A-105", ClientId = clients[0].Id },
                new LockerKey { KeyNumber = "A-106", ClientId = clients[1].Id },
                new LockerKey { KeyNumber = "B-201", ClientId = clients[2].Id }
            };
            context.LockerKeys.AddRange(keys);
            context.SaveChanges();
        }
    }
}
