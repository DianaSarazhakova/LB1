using PersonLib;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PersonTest
{
    /// <summary>
    /// Класс, позволяющий получить рандомного человека
    /// </summary>
    public static class RandomPerson
    {
        #region Методы

        /// <summary>
        /// Создание рандомного человека
        /// </summary> 
        /// <returns>Рандомного человека</returns>
        public static Person GetRandomPerson()
        {                          
            string[] nameMan =
            {
                "Сергей", "Иван", "Алексей", "Михаил", "Андрей", "Федот",
                "Александр", "Арутр", "Кирилл", "Олег", "Матвей", "Игорь"
            };
            string[] nameWoman =
            {
                "Диана", "Ирина", "Валерия", "Марина", "Алена", "Зина",
                "Евгения", "Наташа", "Екатерина", "Оля", "Елена", "Аня"
            };
            string[] surnameMan =
            {
                "Канзычаков", "Бурнаков", "Бурлутский", "Вилков", 
                "Воронов", "Петров", "Чаптыков", "Чуев",
                "Козлов", "Алексеев", "Журавлев", "Ничаев",
            };
            string[] surnameWoman =
            {
                "Космачева", "Саражакова", "Кунучакова", "Воронкова", 
                "Алексеева", "Петрова", "Аткнина", "Иванова",
                "Воронова", "Зайцева", "Чаптыкова", "Зуева",
            };

            Random random = new Random();
            Person randomizedPerson = new Person("Имя", "Фамилия", 0, Gender.М);

            var genderPerson = random.Next(0, 1);
            switch (genderPerson)
            {
                case 0:
                    {
                        randomizedPerson.Gender = Gender.Ж;
                        randomizedPerson.Name = namePerson(nameWoman);
                        randomizedPerson.Surname = namePerson(surnameWoman);
                        break;
                    }
                case 1:
                    {
                        randomizedPerson.Gender = Gender.М;
                        randomizedPerson.Name = namePerson(nameMan);
                        randomizedPerson.Surname = namePerson(surnameMan);
                        break;
                    }
            }              

            randomizedPerson.Age = random.Next(0, 150);

            return randomizedPerson;
        }

        /// <summary>
        /// Назначене имени человеку
        /// </summary>        
        /// <param name="names">Строковый массив, содержащий имена</param>
        /// <returns>Имя или фамилию человека</returns>
        static public string namePerson(string[] names)
        {
            Random random = new Random();            
            int count = random.Next(0, names.Length - 1);
            string name = names[count];         
              
            return name;
        }
        #endregion
    }
} 
