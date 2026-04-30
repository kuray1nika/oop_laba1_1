using proga_laba1_3;
using System;

namespace proga_laba1_3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== ЛАБОРАТОРНАЯ РАБОТА №1. ЗАДАНИЕ №3 ===\n");
            Console.WriteLine("Древовидная структура данных\n");
            Console.WriteLine("Вариант №4. Дерево с выводом листьев\n");

            // Создание дерева (не менее 3 уровней вложенности)
            Console.WriteLine("1. СОЗДАНИЕ ДЕРЕВА:");

            // Уровень 0 (корень)
            TreeNode root = new TreeNode("Компания");

            // Уровень 1
            TreeNode dept1 = root.AddChild("Отдел разработки");
            TreeNode dept2 = root.AddChild("Отдел маркетинга");
            TreeNode dept3 = root.AddChild("Отдел продаж");

            // Уровень 2 — подотделы разработки
            TreeNode team1 = dept1.AddChild("Команда фронтенда");
            TreeNode team2 = dept1.AddChild("Команда бэкенда");
            TreeNode team3 = dept1.AddChild("Команда тестирования");

            // Уровень 2 — подотделы маркетинга
            TreeNode team4 = dept2.AddChild("SMM-отдел");
            TreeNode team5 = dept2.AddChild("SEO-отдел");

            // Уровень 2 — подотделы продаж
            TreeNode team6 = dept3.AddChild("Корпоративные продажи");
            TreeNode team7 = dept3.AddChild("Розничные продажи");

            // Уровень 3 — сотрудники (листья)
            team1.AddChild("Иван Петров");
            team1.AddChild("Мария Сидорова");

            team2.AddChild("Алексей Иванов");
            team2.AddChild("Ольга Смирнова");
            team2.AddChild("Дмитрий Кузнецов");

            team3.AddChild("Елена Попова");
            team3.AddChild("Сергей Васильев");

            team4.AddChild("Анна Козлова");
            team4.AddChild("Павел Морозов");

            team5.AddChild("Наталья Орлова");

            team6.AddChild("Виктор Соколов");
            team6.AddChild("Галина Новикова");
            team6.AddChild("Роман Фёдоров");

            team7.AddChild("Татьяна Белова");

            Console.WriteLine("Дерево создано!\n");

            // 2. Вывод всего дерева
            Console.WriteLine("2. ОБЩИЙ ВЫВОД ДЕРЕВА:");
            Console.WriteLine("─────────────────────────────────");
            TreePrinter.PrintTree(root);

            // 3. Статистика дерева
            Console.WriteLine("\n3. СТАТИСТИКА ДЕРЕВА:");
            int totalNodes = TreePrinter.CountNodes(root);
            int leafCount = TreePrinter.CountLeaves(root);
            Console.WriteLine($"   Всего узлов: {totalNodes}");
            Console.WriteLine($"   Из них листьев: {leafCount}");
            Console.WriteLine($"   Внутренних узлов (не листьев): {totalNodes - leafCount}");

            // 4. Вывод только листьев
            Console.WriteLine("\n4. ВЫВОД ТОЛЬКО ЛИСТОВЫХ УЗЛОВ:");
            Console.WriteLine("─────────────────────────────────");
            TreePrinter.PrintLeaves(root);

            // 5. Дополнительно: проверка IsLeaf() для отдельных узлов
            Console.WriteLine("\n5. ПРОВЕРКА IsLeaf() ДЛЯ ОТДЕЛЬНЫХ УЗЛОВ:");
            Console.WriteLine($"   '{team1.Value}' — лист? {team1.IsLeaf()}");
            Console.WriteLine($"   '{team1.Children[0].Value}' — лист? {team1.Children[0].IsLeaf()}");
            Console.WriteLine($"   '{root.Value}' — лист? {root.IsLeaf()}");

            // 6. Вывод поддерева (отдел маркетинга)
            Console.WriteLine("\n6. ПОДДЕРЕВО 'ОТДЕЛ МАРКЕТИНГА':");
            Console.WriteLine("─────────────────────────────────");
            TreePrinter.PrintTree(dept2);
            Console.WriteLine($"   Узлов в поддереве: {TreePrinter.CountNodes(dept2)}");
            Console.WriteLine($"   Листьев в поддереве: {TreePrinter.CountLeaves(dept2)}");

            Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ ЗАВЕРШЕНА ===");
            Console.ReadKey();
        }
    }
}