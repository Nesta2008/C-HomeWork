using System;
using System.IO;
using System.Linq;

namespace HomeWork7
{

    class Program
    {
        /// <summary>
        /// Метод проверки ввода численного значения
        /// </summary>
        /// <returns></returns>
        static int Check()
        {
            int b;
            for (; ; )
            {
                string a = Console.ReadLine();


                if (!int.TryParse(a, out b))
                {
                    Console.WriteLine("Введите требуемое значение\n");
                }
                else
                {
                    break;
                }
            }
            return b;
        }

        static void Main(string[] args)
        {

            string path = @"newdata.csv";                   // Внесение адреса файла
            Repository rep = new Repository(path);          // Создание репозитория
            rep.Load();                                     // Прогрузка всех данных из файла
            rep.PrintDbToConsole();                         // Печать в консоль всех данных



            //Console.WriteLine(rep.Count);                  // Печать количество сотрудников
            //Console.ReadKey();

            //Console.Clear();                                // Команда очистки консоли

            Console.WriteLine("\nEcли вы хотите добавить нового сотрудника - нажмите 1\nЕсли вы хотите изменить данные уже введенного сотрудника - нажмите 2\nЕсли вы хотите отсортировать данные по дате ввода - нажмите 3\nЕсли вы хотите отсортировать данные по выбранному диапазону - нажмите 4\nЕсли вы хотите удалить данные - нажмите 5  ");
            
            

            switch (Check()) {

            case 1:             // Вариант с вводом нового сотрудника
                        Console.WriteLine("\nВведите нового сотрудника. При этом данные вводить в следующем порядке:\nНомер ID\t\tФИО\t\tРост\t\tДата рождения\t\tВозраст\t\tМесто рождения");
                        Console.WriteLine("");

                       rep.Add(new Worker(Console.ReadLine(), DateTime.Now, Console.ReadLine(), Convert.ToUInt32(Console.ReadLine()), Convert.ToDateTime(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Console.ReadLine()));

                        Console.Clear();                                // Команда очистки консоли

                        rep.PrintDbToConsole();                         // Печать в консоль всех данных   

                                                                   
                        rep.Save();                                     // Метод записи в файл
                        break;

             case 2:           // Вариант с изменением действующего  сотрудника     
                    Console.WriteLine("\nВведите порядковый номер сотрудника, подлежащий корректировке");
                    
                    int UserSelection = Check();                   //Создание переменной выбора пользователя по требуемой операции с проверкой введенной информации.
                    
                    Console.WriteLine("\nВведите откорректированные данные. При этом данные вводить в следующем порядке:\n\nНомер ID\tФИО\t\tРост\t\tДата рождения\t\tВозраст\t\tМесто рождения");
                    Console.WriteLine("");
                    rep.workers[UserSelection] = new Worker(Console.ReadLine(), DateTime.Now, Console.ReadLine(), Convert.ToUInt32(Console.ReadLine()), Convert.ToDateTime(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Console.ReadLine());
                    Console.Clear();                                // Команда очистки консоли
                    rep.PrintDbToConsole();                         // Печать в консоль всех данных  
                    rep.Save();                                   // Метод записи в файл
                    break;
                case 3:             // Вариант с сортировкой данных по дате ввода
                    Console.Clear();                                  // Команда очистки консоли   
                    
                    rep.PrintDbToConsoleforSortDate();                         // Печать в консоль всех данных  с сортировкой по датам



                    break;
                case 4:             // Вариант с сортировкой данных по выбранному диапазону
                    Console.Clear();                                  // Команда очистки консоли   

                    rep.PrintDbToConsoleforDate();                         // Печать в консоль всех данных  с сортировкой по датам



                    break;
                case 5:             // Вариант с удалением данных
                    rep.Delete();
                    rep.Load();
                    
                    break;
                default:
                    Console.WriteLine("Сломал систему. Иди застрелись ");
                    break;
            }
        }
    }
}
    

        
            
           
        
    