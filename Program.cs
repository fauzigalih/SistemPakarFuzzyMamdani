using System;
using System.Collections.Generic;

namespace SistemPakarFuzzyMamdani
{
    class Program
    {
        static bool _password = false;
        static bool _error = false;
        static string messageError;
        static List<Nurse> nurseList = new List<Nurse>();
        static void Main()
        {
            ConfirmPassword();
        }

        static void Home()
        {
            Console.WriteLine("Selamat Datang di Sistem Pakar \n" +
                "Aplikasi Sertifikasi Perawat \n\n");
            InputData();
            InputScore();
        }

        static void ConfirmPassword()
        {
            int password = 1234;
            while(!_password)
            {
                Console.Write("Masukan password utk melanjutkan: ");
                string answer = Console.ReadLine();
                if (answer == password.ToString())
                {
                    _password = true;
                    Console.Clear();
                    Home();
                }
                else Console.WriteLine("Password Salah!");
            }
        }

        static void InputData()
        {
            Nurse nurse = new Nurse();
            if (_error) Console.WriteLine(messageError + ", masukan ulang kembali data anda dgn benar!");

            Console.Write("Masukan NIP: ");
            string nip = Console.ReadLine();
            if (!nurse.ConfirmNIP(nip.Length))
            {
                Console.Clear();
                _error = true;
                messageError = "NIP harus 6 digit";
                Home();
            }
            else
            {
                _error = false;
                Console.Write("Masukan Nama: ");
                string name = Console.ReadLine();
                Console.Write("Masukan Umur: ");
                int age = Convert.ToInt32(Console.ReadLine());
                if (!nurse.ConfirmAge(age))
                {
                    Console.Clear();
                    _error = true;
                    messageError = "Umur harus diatas 17 thn";
                    Home();
                }
                else _error = false;
                Console.WriteLine(1111);
            }
        }

        static void InputScore()
        {
            Console.WriteLine("sdasdasd");
        }
    }
}
