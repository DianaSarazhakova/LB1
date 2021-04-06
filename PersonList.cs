using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLib
{
    /// <summary>
    /// Класс, описывающий список людей
    /// </summary>
    public class PersonList
    {
        #region Поля

        /// <summary>
        /// Список людей
        /// </summary>
        private PersonBase[] _persons;

        #endregion

        #region Свойства

        /// <summary>
        /// Возвращает количество элементов в списке
        /// </summary>
        public int Length
        {
            get { return _persons.Length; }
        }

        #endregion
        
        #region Индексатор

        /// <summary>
        /// Возвращает человека из списка по указанному индексу
        /// </summary>
        /// <param name="index">индекс человека в списке</param>       
        public PersonBase this[int index]
        {
            get
            {
                if (index < 0 || index > Length - 1)
                {
                    throw new IndexOutOfRangeException("Такого индекса в списке нет.");
                }
                return _persons[index];
            }
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор списка людей,
        /// осуществляющий инициализацию пустого массива
        /// </summary>
        public PersonList()
        {
            _persons = new PersonBase[0];
        }

        #endregion

        #region Методы

        /// <summary>
        /// Добавление человека
        /// </summary>
        /// <param name="person">Человек</param>
        public void Add(PersonBase person)
        {
            var persons = _persons;

            _persons = new PersonBase[persons.Length + 1];
            for (int i = 0; i < persons.Length; i++)
            {
                _persons[i] = persons[i];
            }
            _persons[persons.Length] = person;
        }     
              
        /// <summary>
        /// Очистка списка
        /// </summary>
        public void Clear()
        {
            _persons = new PersonBase[0];
        }

        /// <summary>
        /// Удаление человека из списка по индексу
        /// </summary>
        /// <param name="index">индекс человека в списке</param>
        public void DeleteByIndex(int index)
        {
            if (index < 0 || index > _persons.Length - 1)
            {
                throw new IndexOutOfRangeException("Такого индекса в списке нет.");
            }

            var persons = _persons;
            int counter = 0;

            _persons = new PersonBase[persons.Length - 1];
            for (int i = 0; i < persons.Length; i++)
            {
                if (i != index)
                {
                    _persons[counter] = persons[i];
                    counter++;
                }
            }
        }

        /// <summary>
        /// Удаление человека из списка 
        /// </summary>
        /// <param name="person">Эксземпляр класса Person</param>
        public void Delete(PersonBase person)
        {
            DeleteByIndex(GetIndex(person));
        }        

        /// <summary>
        /// Возвращает индекс человека, при наличии его в списке
        /// </summary>
        /// <param name="person">Экземпляр объекта класса Person</param>       
        public int GetIndex(PersonBase person)
        {
            for (int i = 0; i < _persons.Length; i++)
            {
                if (_persons[i] == person)
                {
                    return i;
                }
            }

            throw new KeyNotFoundException("Такого человека в списке нет.");
        }        

        #endregion
    }
}
