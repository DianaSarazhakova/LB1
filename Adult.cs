using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    /// <summary>
    /// Взрослый человек
    /// </summary>
    public class Adult : PersonBase
    {

        #region Константы

        /// <summary>
        /// Минимальный возраст взрослого
        /// </summary>
        public new const int MinAge = 18;

        /// <summary>
        /// Максимальный возраст взрослого
        /// </summary>
        public new const int MaxAge = 150;

        #endregion

        #region Поля

        /// <summary>
        /// Номер паспорта
        /// </summary>
        private string _passportNumber;

        /// <summary>
        /// Серия паспорта
        /// </summary>
        private string _passportSerial;

        /// <summary>
        /// Семейное положение
        /// </summary>
        private MaritalStatus _maritalStatus;

        /// <summary>
        /// Партнер
        /// </summary>
        private Adult _partner;                

        /// <summary>
        /// Место работы
        /// </summary>
        private string _placeOfWork;

        #endregion

        #region Свойства

        /// <summary>
        /// Возраст
        /// </summary>
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
                        $"Возраст  должен быть от " +
                        $"{MinAge} до {MaxAge}.");
                }
                base.Age = value;
            }
        }

        /// <summary>
        /// Семейное положение
        /// </summary>
        public MaritalStatus MaritalStatus
        {
            get 
            { 
                return _maritalStatus; 
            }
            set 
            { 
                _maritalStatus = value; 
            }
        }

        /// <summary>
        /// Партнер
        /// </summary>
        public Adult Partner
        {
            get 
            { 
                return _partner; 
            }
            set
            {                

                if (MaritalStatus == MaritalStatus.Married &&
                    value.MaritalStatus == MaritalStatus.Married)
                {
                   
                    _partner = value;
                }
                else
                {
                    throw new ArgumentException(
                        "Один из партнеров не состоит в браке. " +
                        "Проверьте семейное положение.");
                }
            }
        }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string PassportNumber
        {
            get 
            { 
                return _passportNumber; 
            }
            set
            {
                CheckPassport(value, 6);
                _passportNumber = value;
            }
        }

        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string PassportSerial
        {
            get 
            { 
                return _passportSerial; 
            }
            set
            {
                CheckPassport(value, 4);
                _passportSerial = value;
            }
        }

        /// <summary>
        /// Место работы
        /// </summary>
        public string PlaceOfWork
        {
            get 
            { 
                return _placeOfWork; 
            }
            set 
            { 
                _placeOfWork = value; 
            }
        }

        /// <summary>
        /// Вывод данных о взрослом
        /// </summary>
        /// <returns>Информация о взрослом</returns>
        public override string Info
        {
            get
            {
                var info = base.Info +
                    $"\nСерия паспорта: {PassportSerial}\nНомер паспорта: " +
                    $"{PassportNumber}\nСемейное положение: {TranslateMaritalstatus(MaritalStatus)}";

                if (MaritalStatus == MaritalStatus.Married)
                {
                    info += $"\nПартнер: {Partner.Name} " +
                        $"{Partner.Surname}";
                }

                info += "\nМесто работы: ";

                if (string.IsNullOrEmpty(PlaceOfWork))
                {
                    info += "Безработный";
                }
                else
                {
                    info += PlaceOfWork;
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
        /// <param name="passportSerial">Серия паспорта</param>
        /// <param name="passportNumber">Номер паспорта</param>
        /// <param name="maritalStatus">Семейное положение</param>
        /// <param name="placeOfWork">Место работы</param>
        public Adult(string name, string surname, byte age,
            Gender gender, string passportSerial, string passportNumber, 
            MaritalStatus maritalStatus, string placeOfWork) : base(name, surname, age, gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            PassportSerial = passportSerial;
            PassportNumber = passportNumber;
            MaritalStatus = maritalStatus;            
            PlaceOfWork = placeOfWork;
        }

        #endregion

        #region Методы

        /// <summary> 
        /// Прописывает семейное положение русскими буквами
        /// </summary>        
        /// <param name="maritalStatus">Гендер для перевода</param>
        public static string TranslateMaritalstatus(MaritalStatus maritalStatus)
        {
            switch (maritalStatus)
            {
                case MaritalStatus.Married:
                    {
                        return "Женат(замужем)";
                    }                                    
                case MaritalStatus.Widowed:
                    {
                        return  "Вдовец(вдова)";                        
                    }
                case MaritalStatus.Divorced:
                    {
                        return "В разводе";                        
                    }
               default:
                    {
                        return  "Не женат(не замужем)";                        
                    }
            }
        }

        /// <summary>
        /// Проверить серию/номер паспорта на корректность
        /// </summary>
        /// <param name="value">Серия/номер паспорта</param>
        /// <param name="quantity">Количество цифр в серии/номере</param>
        private void CheckPassport(string value, int quantity)
        {
            if (value.Length != quantity)
            {
                throw new ArgumentException(
                    "Проверьте количество цифр.");
            }
                        
            if (!int.TryParse(value, out _))
            {
                throw new FormatException("Введите корректное число.");
            }
        }

        /// <summary>
        /// Пойти в ночной клуб
        /// </summary>  
        /// <param name="person">Человек, который идет в клуб</param>
        public string GoToNightclub(Adult person)
        {
            return $"Быть взрослым классно. " +
                $"{person.Name}, приятно тебе провести время! :)";
        }

        #endregion
    }
}
