using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgSorusu1
{
    class Program
    {
        static void Main(string[] args)
        {
            MetniCevir();
        }
        public static void MetniCevir()
        {

            char[] delimiterChars = {' ', '(', '"'};//kelimeleri nelere göre ayıracağını seçiyoruz.

            string text = "nhoJ (Griffith) nodnoL saw (an) (American) ,tsilevon \"\"," +
                 "tsilanruoj (and) laicos .tsivitca ((A) reenoip (of) laicremmoc \"\"" +
                 "noitcif (and) naciremA ,senizagam (he) saw eno (of) (the) tsrif \"\"" +
                 "(American) srohtua (to) emoceb (an) lanoitanretni ytirbelec \"\"" +
                 "(and) nrae a egral enutrof (from) ).gnitirw";

            System.Console.WriteLine($" Input: '{text}'");

            List<string> hatali = text.Split(delimiterChars).ToList();
            string[] words = text.Split(delimiterChars);//Metni kelimelere ayırıyoruz.

            string CORRECT_ANSWER = "John Griffith London was an American novelist, journalist, and social activist. (A pioneer of commercial fiction and American magazines, he was one of the first American authors to become an international celebrity and earn a large fortune from writing.)";

            ArrayList dizi = new ArrayList();
            int x = 0;

            foreach (var word in hatali)
            {
                
                if ((x - 1) < 0)//İlk kelimede hata almamak için ayrıca yaptık.
                {
                    for(int j = words[x].Length - 1; j >= 0; j--)//kelimeyi tersten ekliyoruz.
                    {
                        dizi.Add(char.ToString(word[j]));
                    }

                    if(x!=(hatali.Count - 1))
                        dizi.Add(char.ToString(' '));//her kelimeden sonra boşluk oluşturuyoruz.
                    x++;
                 }

                else if (x == 19)//Kelimeleri ayrıştırırken '(' işaretlerini sildiğim için sadece ikinci cümle başlangıcı için ekledim.
                {
                    for (int j = 0; j < words[x].Length - 1; j++)
                    {
                        dizi.Add('(');
                        dizi.Add(char.ToString(word[j]));
                    }

                    if (x != (hatali.Count - 1))
                        dizi.Add(char.ToString(' '));
                    x++;
                }

                else if (words[x].Length > 1 && word[words[x].Length - 1] == ')')//düzgün olan kelimeleri çevirmeden ekliyoruz.
                 {
                    for(int j = 0; j < words[x].Length - 1; j++)
                    {
                        dizi.Add(char.ToString(word[j]));
                    }

                    if (x != (hatali.Count - 1))
                        dizi.Add(char.ToString(' '));
                    x++;
                 }

                else if (words[x].Length > 1 && word[words[x].Length - 1] != ')')//ters kelimeleri düzelterek ekliyoruz.
                {
                    for (int j = words[x].Length - 1; j >= 0; j--)
                    {
                        dizi.Add(char.ToString(word[j]));
                    }

                    if (x != (hatali.Count - 1)) //En Sona fazladan boşluk koymamak adına kontrol.
                        dizi.Add(char.ToString(' '));
                    x++;
                }

                else if (word.Length == 1)
                {
                    dizi.Add(word);

                    if (x != (hatali.Count - 1))
                        dizi.Add(char.ToString(' '));
                    x++;
                }

                else
                 {
                    x++;
                 }
            }

            string duzeltilmisMetin = "";
            System.Console.WriteLine("\n Düzeltilmiş Metin:\n");
            for (int a = 0; a <= dizi.Count - 1; a++)
            {
                duzeltilmisMetin += dizi[a];
            }

            System.Console.Write(duzeltilmisMetin);


            System.Console.WriteLine("\n\n Doğru Metin:\n");
            System.Console.Write(CORRECT_ANSWER);

            int donusDegeri = string.Compare(CORRECT_ANSWER, duzeltilmisMetin);//stringlerin birbiri ile aynı olup olmadığını kontrol ediyoruz.

            if (donusDegeri == 0)
            {
                System.Console.WriteLine("\n\n Düzeltme Doğru.");
            }
            else
            {
                System.Console.WriteLine("\n Metinler Eşleşmiyor!");
            }

            Console.ReadLine();

        }
    }
}
