using System;
using System.Collections.Generic;

namespace SistemPakarFuzzyMamdani
{
    class Program
    {
        static bool _password = false;
        static bool _error = false;
        static string messageError;

        static Score score = new Score();
        static Nurse nurse = new Nurse();
        static List<Nurse> nurseList = new List<Nurse>();
        static void Main()
        {
            ConfirmPassword();
        }

        static void Home()
        {
            Welcome();
            InputData();
            Console.WriteLine();
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
                else
                {
                    Console.Clear();
                    Console.WriteLine("Password Salah!");
                }
            }
        }

        static void Welcome()
        {
            Console.WriteLine("Selamat Datang di Sistem Pakar \n" +
                "Aplikasi Sertifikasi Perawat \n\n");
        }

        static void InputData()
        {
            if (_error) Console.WriteLine(messageError + ", masukan ulang kembali data anda dgn benar!");

            Console.Write("Masukan NIP: ");
            string nip = Console.ReadLine();
            nurse.NurseNIP = Convert.ToInt32(nip);
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
                nurse.NurseName = name;
                Console.Write("Masukan Umur: ");
                int age = Convert.ToInt32(Console.ReadLine());
                nurse.NurseAge = age;
                if (!nurse.ConfirmAge(age))
                {
                    Console.Clear();
                    _error = true;
                    messageError = "Umur harus diatas 17 thn";
                    Home();
                }
                else _error = false;
            }
        }

        static void _InputData()
        {
            Console.WriteLine("Masukan NIP: " + nurse.NurseNIP);
            Console.WriteLine("Masukan Nama: " + nurse.NurseName);
            Console.WriteLine("Masukan Umur: " + nurse.NurseAge);
        }

        static void InputScore()
        {
            if (_error) Console.WriteLine(messageError + ", masukan ulang kembali data anda dgn benar!");

            Console.Write("Masukan Nilai Tes Tulis: ");
            int testWrite = Convert.ToInt32(Console.ReadLine());
            nurse.TestWrite = testWrite;
            if (!nurse.ConfirmTestWrite(testWrite))
            {
                Console.Clear();
                _error = true;
                messageError = "Salah Tulis";
                Welcome();
                _InputData();
                InputScore();
            }
            else _error = false;

            Console.Write("Masukan Nilai Tes Praktek: ");
            int testPractice = Convert.ToInt32(Console.ReadLine());
            nurse.TestPractice = testPractice;
            if (!nurse.ConfirmTestPractice(testPractice))
            {
                Console.Clear();
                _error = true;
                messageError = "Salah praktek";
                Welcome();
                _InputData();
                InputScore();
            }
            else _error = false;
        }
    }
}
