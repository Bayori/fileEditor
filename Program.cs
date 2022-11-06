using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace fileEditor
{
    internal class Program
    {
        static void fileCreate(string path) // Создание файла
        {
            FileInfo MyFile = new FileInfo(path); // Путь до файла
            using (StreamWriter mf = MyFile.CreateText());
        }
        static void fileRead(string path) // Считывание первой строчки файла
        {
            {
                Console.Write("Line number: ");
                try
                {
                    Console.WriteLine(File.ReadLines(path).Skip(Convert.ToInt32(Console.ReadLine())).First());
                }
                catch
                {
                    Console.WriteLine("Line not found");
                }
            }
        }
        static void voidFileWrite(string path) // Запись строчки в пустой файл
        {
            if (File.ReadAllLines(path).Length == 0) // Проверяем, существуют-ли строчки в файле (Пустой \ не пустой)
            {
                Console.WriteLine("This file is empty");
            }
            else
            {
                using (StreamWriter vf = new StreamWriter(path)) // Путь до пустого файла
                {
                    vf.WriteLine(Console.ReadLine()); // Принудительная запись строки в файл
                }
            }
        }
        static void fileReplace(string path)
        {
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(Console.ReadLine()); // Перезапись файла
                fs.Write(info, 0, info.Length);
            }
        }
        static void fileAddLine(string path)
        {
            using (StreamWriter vf = new StreamWriter(path, true)) // Путь до файла
            {
                vf.WriteLine("\n"+Console.ReadLine()); // Добавление строки в файл
            }
        }

        static void Main(string[] args)
        {
            string path = @"C:\Users\super\OneDrive\Desktop\files\MyFile.txt"; // Путь до файла с текстом
            fileCreate(path); // Создание файла
            fileRead(path); // Считывание первой строчки из файла
            voidFileWrite(path); // Принудительная запись строки в файл
            fileReplace(path); // Перезапись файла
            fileAddLine(path); // Добавление новой строчки в файл
        }
    }
}
