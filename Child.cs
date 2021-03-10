using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    /// <summary>
    /// Ребенок
    /// </summary>
    public class Child : Person
    {
        #region Константы

        /// <summary>
        /// Минимальный возраст ребенка
        /// </summary>
        public new const int MinAge = 0;

        /// <summary>
        /// Максимальный возраст ребенка
        /// </summary>
        public new const int MaxAge = 17;

        #endregion

        #region Поля

        /// <summary>
        /// Мама
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Папа
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Название детского сада или школы
        /// </summary>
        private string _kindergardenOrSchool;

        #endregion        

        #region Свойства

        public override int Age
        {
            get
            {
                return base.Age;
            }
            set
            {                
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentOutOfRangeException(
                    $"{nameof(value)}  должен быть от " +
                    $"{MinAge} до {MaxAge}.");
                }

                base.Age = value;
            }
        }

        /// <summary>
        /// Мама
        /// </summary>
        public Adult Mother
        {
            get
            {
                return _mother;
            }
            set
            {
                _mother = value;
            }
        }

        /// <summary>
        /// Папа
        /// </summary>
        public Adult Father
        {
            get
            {
                return _father;
            }
            set
            {
                _father = value;
            }
        }

        /// <summary>
        /// Название детского сада или школы
        /// </summary>
        public string KindergardenOrSchool
        {
            get
            {
                return _kindergardenOrSchool;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Название учреждения " +
                        "не может быть пустым.");
                }

                _kindergardenOrSchool = value;
            }
        }

        /// <summary>
        /// Вывод данных о ребенке
        /// </summary>  
        /// <returns>Информация о ребенке</returns>
        public override string Info
        {
            get
            {
                var info = base.Info +
                    $"\nНазвание детского сада или школы: " +
                    $"{KindergardenOrSchool}";

                if (Mother != null)
                {
                    info += $"\nМать:" +
                        $" {Mother.Info}";
                }

                if (Father != null)
                {
                    info += $"\nОтец:" +
                        $" {Father.Info}";
                }

                return info;
            }
        }

        #endregion

        #region Конструктор                      

        /// <summary>
        /// Человек
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        public Child(string name, string surname, byte age,
            Gender gender, string kindergardenOrSchool, Adult mother, 
            Adult father) : base(name, surname, age, gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            KindergardenOrSchool = kindergardenOrSchool;
            Mother = mother;
            Father = father;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Пойти в ночной клуб
        /// </summary>    
        /// <param name="person">Человек, который идет в клуб</param>
        public string GoToNightclub(Child person)
        {
            return $"{person.Name} не может пойти в ночной клуб. " +
                $"В таком юном возрасте туда не пустят.";
        }

        #endregion


    }

}
