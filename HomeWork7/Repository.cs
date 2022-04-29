using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace HomeWork7
{
    struct Repository
    {
        public Worker[] workers;           // Массив, в котором будут храниться данные

        private string path;                // Путь к файлу, откуда будут собираться данные для массива

        int index;                          // Переменная, которая говорит позицию для будущего сотрудника

        public Repository(string Path)      //Конструктор, позволяющий работать с файлом
        {
            this.path = Path;
            this.index = 1;
            this.workers = new Worker[2];
        }

        private void Resize(bool Flag)      //метод, позволяющий увеличивать массив в два раза
        {
            if (Flag)
            {
                Array.Resize(ref this.workers, this.workers.Length * 2);
            }
        }

        public void Add(Worker ConcreteWorker)              //Условие превышения количества сотрудников
        {
            this.Resize(index >= this.workers.Length);
            this.workers[index] = ConcreteWorker;
            this.index++;
        }


        /// <summary>
        /// Количество сотрудников
        /// </summary>
        public int Count { get { return this.index; } }


        public void PrintDbToConsole()              //Метод печати в консоль
        {
            Console.WriteLine($"\t№\tID\tДата добавления\t\t\t\t ФИО\t\t Возраст  Рост\t Дата рождения\t Место рождения");
            Console.WriteLine("");
            for (int i = 1; i < index; i++)
            {
                Console.WriteLine($"{i,10}{this.workers[i].Print()}");
            }

        }

        public void PrintDbToConsoleforDate()              //Метод печати в консоль с сортировкой по диапазону дат
        {
            Console.WriteLine("\nВведите начальную дату. Пример для ввода: 01.01.1990");                           //Запрос первой даты
            DateTime FirstDate = Convert.ToDateTime(Console.ReadLine());             //Ввод и преобразование первой даты
            Console.WriteLine("\nВведите конечную дату. Пример для ввода: 01.01.1990");                            // Запрос второй даты
            DateTime SecondDate = Convert.ToDateTime(Console.ReadLine());            //Ввод и преобразование второй даты

            Console.WriteLine($"\t№\tID\tДата добавления\t\t\t\t ФИО\t\t Возраст  Рост\t Дата рождения\t Место рождения");
            Console.WriteLine("");

            for (uint i = 1; i < workers.Length; i++)
            {
                if (FirstDate < workers[i].ThisMoment && workers[i].ThisMoment < SecondDate)
                {
                    Console.WriteLine($"{i,10}{this.workers[i].Print()}");
                }
            }
        }

        public void PrintDbToConsoleforSortDate()              //Метод печати в консоль с сортировкой по датам
        {
            Console.WriteLine($"\t№\tID\tДата добавления\t\t\t\t ФИО\t\t Возраст  Рост\t Дата рождения\t Место рождения");
            Console.WriteLine("");

            workers = workers.OrderBy(x => x.ThisMoment).ToArray();
            for (uint i = 1; i < workers.Length; i++)
                                
                {
                    Console.WriteLine($"{i,10}{this.workers[i].Print()}");
                }
        }

        public void Delete()              //Метод удаления информации 
        {
            Console.WriteLine("Введите номер сотрудника подлежащего удалению");
            for (; ; )
            {
                String UserSelection2 = Console.ReadLine();
                if (!uint.TryParse(UserSelection2, out uint UserSelection))
                {
                    Console.WriteLine("Введите требуемое числовое значение\n");
                }
                else if (UserSelection >= Count || UserSelection < 1)
                {
                    Console.WriteLine("Введенный номер не соответсвует количеству сотрудников. Введите требуемое значение");

                }
                else{
                    using (StreamWriter sv = new StreamWriter(this.path))           //Создание потока для записи
                    { for (int i = 1; i < index; i++)
                        {
                            if (i == UserSelection)
                            { continue; }
                            else
                                    {sv.WriteLine(this.workers[i].Read());}       //Запись строки
                        }
                    } break;
                    }
            }
        }


        public void Load()                              // Загрузка всех данных из файла
        {

            using (StreamReader sr = new StreamReader(this.path))
            {

                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    Add(new Worker(args[0], Convert.ToDateTime(args[1]), args[2], Convert.ToUInt32(args[4]), Convert.ToDateTime(args[5]), Convert.ToInt32(args[3]), args[6]));
                }
            }
        }

        
        public void Save()                                                  // Загрузка всех данных в файл с правом выбора 
        {
            Console.WriteLine("\n\n\nЕсли вы хотите сохранить данные, то нажмите - 1, Если вы хотите удалить изменения, то нажмите - 2");
                     
            for (; ; )
            {
                String UserSelection2 = Console.ReadLine();
                if (!uint.TryParse(UserSelection2, out uint UserSelection))
                {
                    Console.WriteLine("Введите требуемое значение\n");
                }
                else if (UserSelection == 1)
                {
                            using (StreamWriter sv = new StreamWriter(this.path))           //Создание потока для записи 
                            {
                                for (int i = 1; i < index; i++)       //Цикл считывания массива с рабочими
                                {sv.WriteLine(this.workers[i].Read()); }       //Запись строки
                            }
                    break;
                }
                else if (UserSelection == 2)
                {
                    Console.WriteLine("Ну нет, так нет");
                    break;
                }
                else if (UserSelection != 1 & UserSelection != 2)
                {
                    Console.WriteLine("Ты читать то умеешь? Введите требуемое значение");
                    
                }
            }

            
            
        }
       
    }
}


