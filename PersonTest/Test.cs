using PersonLib;
using System;

namespace PersonTest
{
    /// <summary>
    /// Класс для проверки работы PersonLib
    /// </summary>
    public class Test
    {
        //TODO: RSDN +
        static public PersonList Students = new PersonList(); 
        static public PersonList Dancers = new PersonList();          
            
        static public Person[] PeopleForStudents = new Person[]
        {
            new Person("Мария", "Лебедева", 23, Gender.Ж),
            new Person("Николай", "Маков", 22, Gender.М),
            new Person("Кирилл", "Соловьев", 26, Gender.М)
        };

        static public Person[] PeopleForDancers = new Person[]
        {
            new Person("Михаил", "Николаев", 56, Gender.М),
            new Person("Дмитрий", "Харлеев", 12, Gender.М),
            new Person("Диана", "Пануфик", 34, Gender.Ж)
        };
        
        /// <summary>
        /// Точка вхождения.
        /// </summary>
        /// <param name="args">Аргументы</param>
        public static void Main(string[] args)
        {
            AddInList(PeopleForStudents, Students);
            AddInList(PeopleForDancers, Dancers);
                       
            PrintList(Students);
            PrintList(Dancers);

            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.WriteLine();

            Console.Write("Добавляем нового человека в первый список: ");
            Person newStudent = new Person("Александр", "Юдашкин", 24, Gender.М);
            Students.Add(newStudent);

            PrintList(Students);

            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.WriteLine();

            Console.Write("Копируем второго человека из первого списка во второй: ");
            Dancers.Add(Students[1]);

            PrintList(Students);
            PrintList(Dancers);

            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.WriteLine();

            Console.Write("Удаляем второго человека из первого списка: ");
            Students.DeleteByIndex(1);

            PrintList(Students);

            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.WriteLine();

            Console.Write("Очищаем второй список: ");
            Dancers.Clear();

            PrintList(Dancers);

            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.WriteLine();

            Console.Write("Добавляем во второй список случайного человека: ");
            Dancers.Add(RandomPerson.GetRandomPerson());

            PrintList(Dancers);

            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("Добавим во второй список человека, " +
                "получая параметры от пользователя: ");
            Dancers.Add(ForConsole.NewPerson());
            Console.WriteLine();

            Console.WriteLine("Теперь второй список выглядит так: ");
            
            PrintList(Dancers);

            Console.Write("Для завершения нажмите любую клавишу...");
            Console.ReadKey();
        }               

        /// <summary>
        /// Вывести содержимое списка на экран
        /// </summary>
        /// <param name="personList">cписок для вывода</param>        
        static public void PrintList(PersonList personList)
        {
            Console.WriteLine($"Список {nameof(personList)}\n");            

            for (int i = 0; i < personList.Length; i++)
            {
                Console.WriteLine(personList[i].Info);
                Console.WriteLine();
            }              

            Console.WriteLine();                 
        }

        /// <summary>
        /// Добавление в PersonList
        /// </summary>
        /// <param name="personList">массив, из которого происходит добавление</param>     
        /// <param name="personList">cписок для заполнения</param>
        static public void AddInList(Person[] persons, PersonList personList)
        {
            foreach (Person person in persons)
            {
                personList.Add(person);
            }
        }
    }
}
