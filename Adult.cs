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
    public class Adult : Person
    {       

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
                const int minAge = 18;
                const int maxAge = 150;
                if (value < minAge || value > maxAge)
                {
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)}  должен быть от " +
                        $"{minAge} до {maxAge}.");
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
                if (value == null)
                {
                    throw new ArgumentNullException(
                        $"{nameof(Partner)}", "Для партнера не может " +
                        "быть задано пустое значение");
                }

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
                    $"{PassportNumber}\nСемейное положение: {MaritalStatus}";

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

        #region Методы

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

        #endregion
    }
}
