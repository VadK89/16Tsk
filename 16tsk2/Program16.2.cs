using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;

namespace _16tsk2
{
    /*Необходимо разработать программу для получения информации о товаре из json-файла.
     * Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.*/
    class Program
    {
        static void Main(string[] args)
        {
            //Задаем ввод адреса и названия файла, где будет храниться массив
            Console.WriteLine("Введите адрес папки и через добавьте название файла с раширением");
            string path = Console.ReadLine();
            //Считываем файл и ищем наибольшую цену
            JsonSerializerOptions option = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = File.ReadAllText(path);
            Goods[] goods = JsonSerializer.Deserialize<Goods[]>(jsonString, option);
            double max = 0;
            string most="";
            foreach (var i in goods)
            {
                if (i.Price>=max)
                {
                    max = i.Price;
                    most = i.Name;                        
                }
            }
            Console.WriteLine("название самого дорогого товара {0}", most);        
            Console.ReadKey();
            }
    }
    class Goods
    {        
        public int Code { get; set; }        
        public string Name { get; set; }        
        public double Price { get; set; }

    }

}
