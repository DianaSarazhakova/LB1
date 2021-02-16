using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace PersonLib
{
    /// <summary>
    /// Класс, описывающий человека
    /// </summary>
    public class Person
    {
        #region Поля

        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст
        /// </summary>
        private int _age;

        /// <summary>
        /// Пол
        /// </summary>
        private Gender _gender;

        #endregion

        #region Свойства

        /// <summary>
        /// Имя
        /// </summary>        
        public string Name
        {
            get 
            { 
                return _name; 
            }
            set
            {
                CheckName(value);
                _name = FirstUpper(value);
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname
        {
            get 
            { 
                return _surname; 
            }
            set
            {
                CheckName(value);
                _surname = FirstUpper(value);
            }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age
        {
            get 
            { 
                return _age; 
            }
            set
            {
                if (value < 0 || value > 150)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must +" +
                        $"be from 0 to 150.");
                }
                _age = value;
            }
        }

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender
        {
            get 
            { 
                return _gender; 
            }
            set 
            { 
                _gender = value; 
            }
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Человек
        /// </summary>
        public Person() { }

        /// <summary>
        /// Человек
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        public Person(string name, string surname, byte age,
            Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        #endregion

        #region Методы

        /// <summary> 
        /// Проверяет имя или фамилию на корректность 
        /// </summary>        
        /// <param name="value">Строка для проверки</param>
        private void CheckName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException($"{nameof(value)} is null or empty.");
            }
            if (!IsNameCorrect(value))
            {
                throw new FormatException($"{nameof(value)} can contain +" +
                    $" only Russian or English letters.");
            }
        }

        /// <summary>
        /// Проверить параметр на соответствие
        /// </summary>
        /// <param name="value">Параметр для проверки</param>       
        private static bool IsNameCorrect(string value)
        {
            Regex nameRegex = new Regex(
                "^(([А-Я]|[а-я]|[A-Z]|[a-z])+)((-)?)(([А-Я]|[а-я]|[A-Z]|[a-z])+)$");

            if (!nameRegex.IsMatch(value))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Измененить первую букву в имени или фамилии на заглавную
        /// с учетом двойного имени или фамилии
        /// </summary>
        /// <param name="value">Строка для изменения</param>      
        private static string FirstUpper(string value)
        {
            value = value.ToLower();
            string[] name = value.Split('-');
            value = null;

            for (int i = 0; i < name.Length; i++)
            {
                name[i] = name[i].First().ToString().ToUpper() +
                    name[i].Substring(1);

                value = value + $"{name[i]}-";
            }

            return value.Substring(0, value.Length - 1);
        }

        /// <summary>
        /// Вывод данных о человеке
        /// </summary>        
        public string PersonInfo()
        {
            return $"Имя: {Name}\nФамилия: {Surname}\nВозраст: {Age}\nПол: {Gender}";
        }        

        #endregion
    }
}
