using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace _NET_End_Translator
{
    class Program
    {
        [Serializable]
        public class Translator
        {
          
            public string Eng_Word { set; get; }
            
            public string Russ_Word { set; get; }

            public Translator() { }
            public Translator(string EW, string RW)
            {
                Eng_Word = EW;
                Russ_Word = RW;
            }
           
        }
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Dictionary<string, Translator> translator = new Dictionary<string, Translator>();
            Dictionary<string, Translator> translator2 = new Dictionary<string, Translator>();

            FileStream fileStream = new FileStream("TranslatorEng.xml", FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Dictionary<string,Translator>));// создание обьекта
            xmlSerializer.Serialize(fileStream, translator);
            
            FileStream file = new FileStream("TranslatorRuss.xml", FileMode.Create);
            XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(Dictionary<string,Translator>));
            xmlSerializer1.Serialize(file, translator2);
            
            Console.WriteLine("Выберите тип словоря: 1) Англо-русский 2)Русско-английский");
            int E= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите на какой язык хотите перевести --> 1)Английски 2)Русский");
            int A1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите cлово которое хотите перевести");
            string word = Console.ReadLine();
           
            translator.Add("Car", new Translator { Eng_Word = "Car", Russ_Word = "Машина" });
            translator.Add("Apple", new Translator { Eng_Word = "Apple", Russ_Word = "Яблоко" });
            translator.Add("Apple",new Translator { Eng_Word = "Apple", Russ_Word = "Дом" });
            translator.Add("Cat", new Translator { Eng_Word = "Cat", Russ_Word = "Кошка" });

            translator2.Add("Машина",new Translator { Eng_Word = "Машина", Russ_Word = "Car" });
            translator2.Add("Яблоко",new Translator { Eng_Word = "Яблоко", Russ_Word = "Apple" });
            translator2.Add("Дом",new Translator { Eng_Word = "Дом", Russ_Word = "House" });
            translator2.Add("Кошка",new Translator { Eng_Word = "Кошка", Russ_Word = "Cat" });

            /* foreach()
            {
                Console.WriteLine($"");
            }*/
            
            if (A1==1)
            {
                if (translator.ContainsKey(word))
                {
                    Console.WriteLine(word + "-->" + translator[word]);
                }
                else
                {
                    Console.WriteLine("Такой слова нет!!");
                }
            }
            if (A1==2)
            {
                if (translator2.ContainsKey(word))
                {
                    Console.WriteLine(word+"-->"+translator2[word]);
                }
                else
                {
                    Console.WriteLine("Такой слова нет!!");
                }
            }

            Console.WriteLine("Введите на какой язык хотите перевести слово и добавить в словарь --> 1)Английски 2)Русский");
            int v = Convert.ToInt32(Console.ReadLine());
            if (v==2)
            {
                Console.WriteLine("Введите английское слово");
                string w = Console.ReadLine();
                Console.WriteLine("Введите русское слово");
                string word1 = Console.ReadLine();
                Translator translator_2 = new Translator(w,word1);//записываю мои новые слова
                translator.Add(w, translator_2);
                
            }
            
            if (v==1)
            {
                Console.WriteLine("Введите русское слово");
                string word1 = Console.ReadLine();
                Console.WriteLine("Введите английское слово");
                string w = Console.ReadLine();
                Translator translator1 = new Translator(word1, w);//записываю мои новые слова
                translator.Add(word1, translator1);
            }

            Console.WriteLine("Введите на каком языке хотите удалить слово и его перевод ---> 1)Английский, 2)Русский");
            int temp = Convert.ToInt32(Console.ReadLine());

            if (temp == 1)
            {
                Console.WriteLine("Введите слово на английском языке которое хотите удалить из словаря ");
                string word3 = Console.ReadLine();
                if (translator.ContainsKey(word3))
                {
                    translator.Remove(word3);
                }
                else
                {
                    Console.WriteLine("Такого слова в словаре нет !!!");
                }
            }
            if (temp==2)
            {
                Console.WriteLine("Введите слово на русском языке которое хотите удалить из словаря ");
                string word_3 = Console.ReadLine();
                if (translator.ContainsKey(word_3))
                {
                    translator.Remove(word_3);
                }
                else
                {
                    Console.WriteLine("Такого слова в словаре нет !!!");
                }
            }
            Console.WriteLine("Введите на какое слово хотите заменить слово и добавить в словарь --> 1)Английски 2)Русский");
            int z = Convert.ToInt32(Console.ReadLine());
            
            if (z==1)
            {
                Console.WriteLine("Введите слово на английском языке которое хотите заменить");
                string q = Console.ReadLine();
                if (translator.ContainsKey(q))//проверка на наличие слова в словаре
                {
                    Console.WriteLine("Введите новое русское слово");
                    string tq = Console.ReadLine();
                    translator.Update(q, new Translator(q, tq));
                    
                }
                else
                {
                    Console.WriteLine("такого слова нету в словаре!!");
                }
            }
            if (z==2)
            {
                Console.WriteLine("Введите слово на русском языке которое хотите заменить");
                string q = Console.ReadLine();
                if (translator2.ContainsKey(q))
                {
                    Console.WriteLine("Введите новое английское слово");
                    string nr = Console.ReadLine();
                    translator2.Update(q,new Translator(q,nr));
                }
                else
                {
                    Console.WriteLine("такого слова нету в словаре!!");
                }
            }
            
        }
    }

         
   
}

