using PersonLib;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace ProgramTestLB2
{
    /// <summary>
    /// Класс, позволяющий получить рандомного человека
    /// </summary>
    public static class RandomPerson
    {
        #region Методы

        /// <summary>
        /// Создание рандомного взрослого или ребенка
        /// </summary> 
        /// <returns>Рандомного человека</returns>
        public static PersonBase GetRandomAdultOrChild()
        {
            Random random = new Random();
            if (random.Next(1, 4) != 1)
            {
                return GetRandomAdult();
            }
            else
            {
                return GetRandomChild();
            }
        }

        /// <summary>
        /// Создание рандомного человека
        /// </summary> 
        /// <param name="randomizedPerson">Человек, для которого рандомятся параметры</param>
        /// <returns>Рандомного человека</returns>
        public static PersonBase GetRandomPerson(PersonBase randomizedPerson)
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

            var genderPersonBool = random.Next(0, 2) == 0;
            
            if (genderPersonBool)
            {
                randomizedPerson.Gender = Gender.Female;
                randomizedPerson.Name = namePerson(nameWoman);
                randomizedPerson.Surname = namePerson(surnameWoman);                
            }
            else
            {
                randomizedPerson.Gender = Gender.Male;
                randomizedPerson.Name = namePerson(nameMan);
                randomizedPerson.Surname = namePerson(surnameMan);                
            }        

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

        /// <summary>
        /// Сгенерировать
        /// </summary>
        /// <param name="maritalStatus">Состоит ли в браке</param>  
        /// <param name="partner">Кто партнер</param>  
        /// <returns>Сгенерированный взрослый</returns>
        public static Adult GetRandomAdult(MaritalStatus maritalStatus = MaritalStatus.Single, 
            Adult partner = null)
        {
            string[] companies =
            {
                "Ладист", "Кегели", "Дирса", "Чистофф", "ДаркЛайтс", "Продиджи",
                "Паутина", "Альфа", "Верона", "Apple", "Google", "Джойжи"
            };

            var randomizedAdult = new Adult("Имя", "Фамилия", 18, Gender.Male,
                "0000", "000000", maritalStatus, null);

            GetRandomPerson(randomizedAdult);

            if (partner != null)
            {
                while (Convert.ToString(partner.Gender) == Convert.ToString(randomizedAdult.Gender))
                {
                    GetRandomPerson(randomizedAdult);
                }
            } 

            Random random = new Random();
            randomizedAdult.Age = random.Next(Adult.MinAge, Adult.MaxAge);

            if (maritalStatus == MaritalStatus.Single)
            {
                randomizedAdult.MaritalStatus = (MaritalStatus)random.Next(0, 3);
                if (randomizedAdult.MaritalStatus == MaritalStatus.Married)
                {
                    randomizedAdult.Partner = GetRandomAdult(MaritalStatus.Married, randomizedAdult);
                }
            }
            else 
            {
                randomizedAdult.Partner = partner;
            }

            var work = random.Next(0, 1);
            switch (work)
            {
                case 0:
                    {                        
                        randomizedAdult.PlaceOfWork = namePerson(companies);                        
                        break;
                    }
                case 1:
                    {
                        randomizedAdult.PlaceOfWork = null;                        
                        break;
                    }
            }

            randomizedAdult.PassportSerial = GetPassportData(4);
            randomizedAdult.PassportNumber = GetPassportData(6);            

            return randomizedAdult;
        }        

        /// <summary>
        /// Сгенерировать номер/серию паспорта
        /// </summary>
        /// <param name="quantity">Количество цифр в желаемом числе</param>
        /// <returns>Серию/номер паспорта</returns>
        private static string GetPassportData(int quantity)
        {            
            Random random = new Random();

            string data = Convert.ToString(random.Next(1, 9));
            
            for (int i = 1; i < quantity; i++)
            {
                data = data + Convert.ToString(random.Next(0,9));
            }          
            
            return data;
        }

        /// <summary>
        /// Сгенерировать нового ребенка
        /// </summary>
        /// <returns>Сгенерированный ребенок</returns>
        public static Child GetRandomChild()
        {
            string[] kindergardens =
            {
                "Зоренька", "Ивушка", "Сказка", "Золушка", "Дельфин", "Китенок",
                "Корытце", "Сударушка", "Ласточка", "Филиппок", "Рябинушка", "Светлячок"
            };

            string[] schools =
            {
                "Школа №25", "Лицей №14", "Школа №11", "Лицей №8", "Школа №26", "Школа №5",
                "Школа №12", "Школа №11", "Школа №19", "Школа №18", "Школа №1", "Школа №2"
            };

            var randomizedChild = new Child("Имя", "Фамилия", 0, Gender.Male,
            "Школа", null, null);

            GetRandomPerson(randomizedChild);             
            Random random = new Random();
            randomizedChild.Age = random.Next(Child.MinAge, Child.MaxAge);

            int haveMother = random.Next(0, 4) ;

            randomizedChild.Mother = GetRandomAdult();

            if (haveMother != 0)
            {
                while (randomizedChild.Mother.Gender != Gender.Female)
                {
                    randomizedChild.Mother = GetRandomAdult();
                }                

            }

            if (haveMother != 0 && randomizedChild.Mother.MaritalStatus == MaritalStatus.Married)
            {
                randomizedChild.Father = randomizedChild.Mother.Partner;
            }
            else
            {
                int haveFather = random.Next(0, 4);

                if (haveFather != 0)
                {
                    while (randomizedChild.Mother.Gender == Gender.Male)
                    {
                        randomizedChild.Father = GetRandomAdult();
                    }
                    
                }
            }

            if (randomizedChild.Age < 7)
            {
                randomizedChild.KindergardenOrSchool = namePerson(kindergardens);
            }
            else
            {
                randomizedChild.KindergardenOrSchool = namePerson(schools);
            }                       
            
            return randomizedChild;
        }        

        #endregion
    }
}