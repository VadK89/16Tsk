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

namespace _16Tsk
{
    class Program
    {
        /*1 Разработать класс для моделирования объекта «Товар». 
         * Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
         * Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
         * Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json». */
        static void Main(string[] args)
        {
            //Задаем ввод адреса и названия файла, где будет храниться массив
            Console.WriteLine("Введите адрес папки и через добавьте название файла с раширением");
            string path = Console.ReadLine();
            if (!File.Exists(path))
            {
                File.CreateText(path).Close();
            }
            //Задаем процедуру записи в файла по указанному адресу
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                //Задаем массив
                Goods[] goods = new Goods[5];

                for (int i = 0; i < goods.Length; i++)
                {
                    //Задаем ввод характеристик товара
                    Goods goods1 = new Goods();
                    Console.WriteLine("Введите код товара:");
                    goods1.Code = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите название товара:");
                    goods1.Name = Console.ReadLine();
                    Console.WriteLine("Введите цену товара:");
                    goods1.Price= Convert.ToDouble(Console.ReadLine());
                    goods[i] = goods1;
                }
                //Задаем опции для JSON
                JsonSerializerOptions option = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                //Задаем строку JSON
                string jsonstr = JsonSerializer.Serialize(goods, option);
                //Записываем в файл
                sw.Write(jsonstr);
            }

        }
    }
    //Задаем класс   
    class Goods
    {        
        public int Code { get; set; }         
        public string Name { get; set; }         
        public double Price { get; set; }
    }

}
