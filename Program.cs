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
        static void fileCreate(string path, string voidFile)
        {
            FileInfo MyFile = new FileInfo(path); // Путь до файла
            FileInfo VoidFile = new FileInfo(voidFile); // Путь до пустого файла
            StreamWriter mf = MyFile.CreateText();
            StreamWriter vf = VoidFile.CreateText();

            mf.WriteLine("This is a text");
            mf.Close();
            vf.Close();
        }
        static void fileRead(string path) 
        {
            using (StreamReader read = new StreamReader(path))
            { 
                Console.WriteLine(read.ReadLine()); // Считывание первой строчки файла
            }
        }
        static void voidFileWrite(string voidFile) 
        {
            using (StreamWriter vf = new StreamWriter(voidFile)) // Путь до пустого файла
            {
                Console.Write("Text: ");
                vf.WriteLine(Console.ReadLine()); // Принудительная запись строки в файл
            }
        }
        static void fileReplace(string path)
        {
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("This is replaced text"); // Перезапись файла
                fs.Write(info, 0, info.Length);
            }
        }
        static void fileAddLine(string path)
        {
            using (StreamWriter vf = new StreamWriter(path, true)) // Путь до файла
            {
                Console.Write("Text: ");
                vf.WriteLine("\n"+Console.ReadLine()); // Добавление строки в файл
            }
        }

        static void Main(string[] args)
        {
            string path = @"C:\Users\super\OneDrive\Desktop\files\MyFile.txt"; // Путь до файла с текстом
            string voidFile = @"C:\Users\super\OneDrive\Desktop\files\voidFile.txt"; // Путь до пустого файла

            fileCreate(path, voidFile); // Создание 2-х файлов: С текстом (Для последующего прочтения) и пустого (для записи)
            fileRead(path); // Считывание строчки из файла с текстом
            voidFileWrite(voidFile); // Принудительная запись строки в файл
            fileReplace(path); // Перезапись файла с текстом
            fileAddLine(path); // Добавление новой строки в файл
        }
    }
}
