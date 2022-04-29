using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace HomeWork7
{
    struct Worker
    {
        
        public string ID { get; set; }                       // переменная ID
        public DateTime ThisMoment { get; set; }             // Время добавления записи
        public string FIO { get; set; }                      // Переменная ФИО
        public int Age { get; set; }                        // Переменная возраста
        public uint Height { get; set; }                     // переменная роста
        public DateTime DayOfBirth { get; set; }               // дата рождения
        public string BirthPlace { get; set; }               // место рождения

        /// <summary>
        /// Создание нового сотрудника
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="ThisMoment"></param>
        /// <param name="FIO"></param>
        /// <param name="Age"></param>
        /// <param name="Height"></param>
        /// <param name="DayOfBirth"></param>
        /// <param name="BirthPlace"></param>
        public Worker(string ID, DateTime Date, string FIO, uint Height, DateTime DayOfBirth, int Age, string BirthPlace)
        {
            
            this.ID = ID;
            this.ThisMoment = Date;
            this.FIO = FIO;
            this.Age = ThisMoment.Year - DayOfBirth.Year;
            this.Height = Height;
            this.DayOfBirth = DayOfBirth;
            this.BirthPlace = BirthPlace;
        }
        public string Print()       //Вывод
        {
            return $"{ID,10}\t {ThisMoment,20} {FIO,30}\t {Age,5}\t {Height,5}\t {DayOfBirth.ToShortDateString(),10}\t {BirthPlace,15}" ;
        }

        
        public string Read()        //Сохранение для записи
        {
            return $"{ID}#{ThisMoment}#{FIO}#{Age}#{Height}#{DayOfBirth.ToShortDateString()}#{BirthPlace}";
        }

       
        ///// <summary>
        ///// Метод проверки ввода численного значения
        ///// </summary>
        ///// <returns></returns>
        //static int Check()
        //{
        //    int b;
        //    for (; ; )
        //    {
        //        string a = Console.ReadLine();


        //        if (!int.TryParse(a, out b))
        //        {
        //            Console.WriteLine("Введите требуемое значение\n");
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    return b;
        //}

    }






}
