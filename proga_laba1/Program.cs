using proga_laba1;
using System;

namespace proga_laba1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== ЛАБОРАТОРНАЯ РАБОТА №1. ЗАДАНИЕ №1 ===\n");
            Console.WriteLine("Вариант №10. Многочлен (Polynomial)\n");

            // 1. Создание объектов
            Console.WriteLine("1. СОЗДАНИЕ ОБЪЕКТОВ:");
            var p1 = new Polynomial(-1, 3, 2);      // 2x^2 + 3x - 1
            var p2 = new Polynomial(-4, 0, 1);      // x^3 - 4  (ошибка в комментарии? проверим: -4, 0, 1 -> 1x^2 + 0x - 4)
            var p3 = new Polynomial(5);             // 5
            var p4 = new Polynomial(0, 0, 4);       // 4x^2 (ведущие нули отбрасываются)
            var p5 = new Polynomial(0);             // 0

            Console.WriteLine($"p1 = {p1}");
            Console.WriteLine($"p2 = {p2}");
            Console.WriteLine($"p3 = {p3}");
            Console.WriteLine($"p4 (0, 0, 4) = {p4}");
            Console.WriteLine($"p5 (0) = {p5}");

            // Проверка свойств (только для чтения)
            Console.WriteLine("\n2. ПРОВЕРКА СВОЙСТВ (ТОЛЬКО ДЛЯ ЧТЕНИЯ):");
            Console.WriteLine($"p1.Degree = {p1.Degree}");
            Console.WriteLine($"p1.Coefficients: [{string.Join(", ", p1.Coefficients)}]");

            // 3. Арифметические операции
            Console.WriteLine("\n3. АРИФМЕТИЧЕСКИЕ ОПЕРАЦИИ:");
            var p6 = new Polynomial(1, 1);          // x + 1
            var p7 = new Polynomial(-1, 1);         // x - 1

            Console.WriteLine($"p6 = {p6}");
            Console.WriteLine($"p7 = {p7}");
            Console.WriteLine($"p6 + p7 = {p6 + p7}");
            Console.WriteLine($"p6 - p7 = {p6 - p7}");
            Console.WriteLine($"p6 * p7 = {p6 * p7}");

            // 4. Операторы сравнения
            Console.WriteLine("\n4. ОПЕРАТОРЫ СРАВНЕНИЯ:");
            var p8 = new Polynomial(-1, 3, 2);      // Такой же как p1
            Console.WriteLine($"p1 = {p1}");
            Console.WriteLine($"p8 = {p8}");
            Console.WriteLine($"p1 == p8 -> {p1 == p8}");
            Console.WriteLine($"p1 == p6 -> {p1 == p6}");
            Console.WriteLine($"p1 != p6 -> {p1 != p6}");

            // 5. Вычисление значения в точке
            Console.WriteLine("\n5. ВЫЧИСЛЕНИЕ ЗНАЧЕНИЯ В ТОЧКЕ Evaluate(x):");
            var poly = new Polynomial(1, 2, 3);     // 3x^2 + 2x + 1
            Console.WriteLine($"Многочлен: {poly}");
            Console.WriteLine($"Evaluate(2) = {poly.Evaluate(2)} (3*4 + 2*2 + 1 = 17)");
            Console.WriteLine($"Evaluate(0) = {poly.Evaluate(0)} (1)");
            Console.WriteLine($"Evaluate(-1) = {poly.Evaluate(-1)} (3 - 2 + 1 = 2)");

            // 6. Доказательство неизменяемости
            Console.WriteLine("\n6. ДОКАЗАТЕЛЬСТВО НЕИЗМЕНЯЕМОСТИ:");
            var original = new Polynomial(1, 2);    // 2x + 1
            Console.WriteLine($"Исходный объект: {original}");
            var result = original + new Polynomial(0, 3);  // добавляем 3x
            Console.WriteLine($"Выполнена операция: original + 3x");
            Console.WriteLine($"Результат: {result}");
            Console.WriteLine($"Исходный объект после операции: {original} (НЕ ИЗМЕНИЛСЯ)");

            // 7. Обработка граничных случаев и ошибок
            Console.WriteLine("\n7. ОБРАБОТКА ГРАНИЧНЫХ СЛУЧАЕВ И ОШИБОК:");

            // Нулевой многочлен
            var zero = new Polynomial(0, 0, 0);
            Console.WriteLine($"Многочлен из нулей: '{zero}'");
            Console.WriteLine($"zero == new Polynomial(0): {zero == new Polynomial(0)}");

            // Умножение на ноль
            var multByZero = p1 * zero;
            Console.WriteLine($"p1 * zero = {multByZero}");

            // Сложение с нулём
            var addZero = p1 + zero;
            Console.WriteLine($"p1 + zero = {addZero}");
            Console.WriteLine($"p1 == addZero: {p1 == addZero}");

            // Ошибка: пустой конструктор
            try
            {
                var bad = new Polynomial();
                Console.WriteLine("ОШИБКА: Исключение не выброшено!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Успешно перехвачено исключение: {ex.Message}");
            }

            // 8. Форматы вывода согласно заданию
            Console.WriteLine("\n8. ПРОВЕРКА ФОРМАТОВ ВЫВОДА ToString():");
            var format1 = new Polynomial(-1, 3, 2);
            var format2 = new Polynomial(-4, 0, 0, 1);
            var format3 = new Polynomial(5);

            Console.WriteLine($"format1 = {format1}   (ожидается: 2x^2 + 3x - 1)");
            Console.WriteLine($"format2 = {format2}   (ожидается: x^3 - 4)");
            Console.WriteLine($"format3 = {format3}   (ожидается: 5)");

            Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ ЗАВЕРШЕНА ===");
            Console.ReadKey();
        }
    }
}