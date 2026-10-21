using System;
using System.Globalization;
using SportComplexTemplate.Data;
using SportComplexTemplate.Demos;

namespace SportComplexTemplate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Продвинутый EF Core — Спорткомплекс";

            Console.WriteLine("==================================================================");
            Console.WriteLine("=== ЗАПУСК ШАБЛОНА: ПРОДВИНУТЫЙ EF CORE (Спорткомплекс) ========");
            Console.WriteLine("==================================================================");

            using (var context = new SportComplexDbContext())
            {
                try
                {
                    // 1. Первичная генерация и наполнение спортивной базы данных
                    Console.WriteLine("[БД] Подготовка локальной SQLite базы данных...");
                    DbInitializer.Initialize(context);
                    Console.WriteLine("[БД] База данных 'sportcomplex_adv.db' успешно создана и наполнена!\n");

                    // 2. Запуск демонстрации механизма Change Tracker (Отслеживание состояний объектов)
                    SportChangeTracker.RunDemo(context);

                    // 3. Запуск демонстрации базовых операций CRUD (Создание, чтение, обновление, удаление)
                    SportCrudOperations.RunDemo(context);

                    // 4. Запуск демонстрации связей «Один ко многим» и «Один к одному»
                    SportRelationships.RunDemo(context);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[ОШИБКА] Произошел критический сбой при демонстрации EF Core:");
                    Console.WriteLine(ex.Message);
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Детали: {ex.InnerException.Message}");
                    }
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\n==================================================================");
            Console.WriteLine("Все демонстрации ORM завершены. Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
