﻿using PersonLib;
using System;

namespace ProgramTestLB2
{
    /// <summary>
    /// Класс для тестирования созданной библиотеки.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка вхождения.
        /// </summary>
        /// <param name="args">Аргументы</param>
        static void Main(string[] args)
        {
            Console.Write("Генерируем 7 человек:\n");

            var persons = new PersonList();

            for (int i = 0; i < 7; i++)
            {
                persons.Add(RandomPerson.GetRandomAdultOrChild());
                Console.WriteLine(persons[i].Info);
                Console.WriteLine();
            }
            
            Console.Write("Четвертый человек в списке - это ");

            if (persons[3] is Adult)
            {
                Console.WriteLine("взрослый человек.");
                var person = persons[3] as Adult;
                Console.WriteLine(person.GoToNightclub(person));
            }
            else if (persons[3] is Child)
            {
                Console.WriteLine("ребенок.");
                var person = persons[3] as Child;
                Console.WriteLine(person.GoToNightclub(person));
            }

            Console.ReadKey();
        }
    }
}
    

