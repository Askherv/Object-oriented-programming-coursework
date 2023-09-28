/*********************************************************************************
**                                SAKARYA ÜNİVERSİTESİ
**                         BİLGİSAYAR VE BİLİŞİM BİLİMLER FAKÜLTESİ       
**                             BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**                            NESNEYE DAYALI PROGRAMLAMA DERSİ
**                                2021-2022 BAHAR DÖNEMİ
**
**                         ÖDEV NUMARASI: 1
**                         ÖĞRENCİ ADI: NIHAD ASGAROV
**                         ÖĞRENCİ NUMARASI: B211210554
**                         DERSİN ALINDIĞI GRUP: A
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp8
{
    class Program
    {
        public static int upperScore;
        public static int lowerScore;
        public static int digitScore;
        public static int symbolScore;
        public static int total;

        public static class PasswordStrengthChecker
        {
            private static int GetLengthScore(string password)
            {
                return Math.Min(0, password.Length) + 10;
            }
            private static int GetUpperScore(string password)
            {
                int rawScore = password.Length - Regex.Replace(password, "[A-Z]", "").Length;
                upperScore = rawScore;
                return Math.Min(2, rawScore) * 10;
            }
            private static int GetLowerScore(string password)
            {
                int rawScore = password.Length - Regex.Replace(password, "[a-z]", "").Length;
                lowerScore = rawScore;
                return Math.Min(2, rawScore) * 10;
            }
            private static int GetDigitScore(string password)
            {
                int rawScore = password.Length - Regex.Replace(password, "[0-9]", "").Length;
                digitScore = rawScore;
                return Math.Min(2, rawScore) * 10;
            }
            private static int GetSymbolScore(string password)
            {
                int rawScore = Regex.Replace(password, "[a-zA-Z0-9]", "").Length;
                symbolScore = rawScore;
                return rawScore * 10;
            }
            private static string GeneratePasswordScore(string password)
            {
                if (!password.Any(char.IsUpper))
                    return "Şifre en az 1 büyük harf içermelidir!";

                if (!password.Any(char.IsLower))
                    return "Şifre en az 1 küçük harf içermelidir!";

                if (!password.Any(char.IsDigit))
                    return "Şifre en az 1 rakam içermelidir!";

                if (!password.Any(char.IsSymbol))
                    return "Şifre en az 1 sembol içermelidir!";

                if (password.Length < 9)
                    return "Şifre en az 9 karakter içermelidir!";

                if (password == null)
                    return "Şifre boş olamaz!";

                if (password.Contains(" "))
                    return "Şifre boşluk içeremez";

                int lengthScore = GetLengthScore(password);
                int upperScore = GetUpperScore(password);
                int lowerScore = GetLowerScore(password);
                int digitScore = GetDigitScore(password);
                int symbolScore = GetSymbolScore(password);
                int totalScore = lengthScore + upperScore + lowerScore + digitScore + symbolScore;
                total = totalScore;
                Console.Write("Puanınız: ");
                return Convert.ToString(total);
            }
            static void Main(string[] args)
            {
                Console.Write("Şifre giriniz: ");
                Console.WriteLine(GeneratePasswordScore(Console.ReadLine()));
                Console.Write("Büyük harf sayısı: ");
                Console.WriteLine(upperScore);
                Console.Write("Küçük harf sayısı: ");
                Console.WriteLine(lowerScore);
                Console.Write("Rakam sayısı: ");
                Console.WriteLine(digitScore);
                Console.Write("Sembol sayısı: ");
                Console.WriteLine(symbolScore);
                Console.WriteLine("");
                if (total < 70)
                {
                    Console.WriteLine("Kabul edilemez");
                    Console.ReadLine();
                }
                if (total >= 70 && total < 90)
                {
                    Console.WriteLine("Kabul edilir");
                    Console.ReadLine();
                }
                if (total >= 90 && total <= 100)
                {
                    Console.WriteLine("Kabul edilir ve güçlü");
                    Console.ReadLine();
                }
            }
        }
    }
}