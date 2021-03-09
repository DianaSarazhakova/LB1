using PersonLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonTest
{

    /// <summary>
    /// Ввод/вывод данных в консоль
    /// </summary>
    public static class ForConsole
    {
        #region Свойства

        /// <summary>
        /// Добавление Person через консоль        
        /// </summary>
        /// <returns>Нового человека</returns>
        public static Person NewPerson()
        {
            Person newPerson = new Person("Имя" ,"Фамилия", 0, Gender.М);            
            List<Action> actions = new List<Action>()            
            {
                new Action(() =>
                {
                    Console.Write("Имя: ");
                    newPerson.Name = Console.ReadLine();                   
                }),
                new Action(() =>
                {
                    Console.Write("Фамилия: ");
                    newPerson.Surname = Console.ReadLine();
                }),
                new Action(() =>
                {
                    Console.Write("Возраст (0-150): ");
                    newPerson.Age = int.Parse(Console.ReadLine());
                }),
                new Action(() =>
                {
                    Console.Write("Пол (Ж/М): ");
                    string gender = Console.ReadLine();
                    gender = gender.First().ToString().ToUpper();
                    newPerson.Gender = (Gender)Enum.Parse(
                        typeof(Gender), gender);
                }),
            };
            actions.ForEach(SetValue);            
            return newPerson;
        }
        
        #endregion

        #region Методы

        /// <summary>
        /// Получить пользовательский ввод и задать параметр
        /// </summary>
        /// <param name="action">Делегат с заданием параметра</param>
        public static void SetValue(Action action)
        {
            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }                
                catch (Exception exception)
                {
                    Console.WriteLine($"\n{exception.Message}\n");                    
                }              
            }
        }

        #endregion
    }
}
