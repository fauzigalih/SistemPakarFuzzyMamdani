using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemPakarFuzzyMamdani
{
    class Program : Fuzzy
    {
        static bool _password = false;
        static bool _error = false;
        static string messageError;

        static Score score = new Score();
        static Nurse nurse = new Nurse();
        static Setting set = new Setting();

        static List<Nurse> nurseList = new List<Nurse>();

        static void Main(string[] args)
        {
            Home();
        }

        static void Home()
        {
            ConfirmPassword();
            Welcome();
            Console.WriteLine("Menu Utama : \n" +
                "1. Tes Sertifikasi Perawat \n" +
                "2. Data Yang Tersimpan \n" +
                "3. Keluar \n");
            Console.Write("Jawab: ");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    Console.Clear();
                    TestSertification();
                    break;
                case "2":
                    Console.Clear();
                    DataSave();
                    break;
                case "3":
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Tidak ada menu tersedia yang kamu pilih");
                    Console.WriteLine();
                    Home();
                    break;
            }
        }

        static void TestSertification()
        {
            Welcome();
            InputData();
            InputScore();
            ConfirmProcess();
            ConfirmSave();
        }

        static void ConfirmPassword()
        {
            while(!_password)
            {
                Console.Write("Masukan password utk melanjutkan: ");
                string answer = Console.ReadLine();
                if (answer == set.password.ToString())
                {
                    _password = true;
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Password Salah!");
                }
            }
        }

        static void ConfirmProcess()
        {
            Console.WriteLine();
            Console.Write("Apakah data diatas sudah benar dan ingin melanjutkan proses?(y/n) : ");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y" || answer == "yes" || answer == "ya") Calculation();
            else if (answer == "n" || answer == "no")
            {
                Console.Clear();
                Home();
            }
            else
            {
                Console.WriteLine("Tidak ada pilihan yg tersedia. \n");
                ConfirmProcess();
            }
        }

        static void ConfirmSave()
        {
            Console.WriteLine();
            Console.Write("Apakah anda ingin menyimpan data ini?(y/n) : ");
            string answer = Console.ReadLine();
            if (answer == "y" || answer == "yes" || answer == "ya")
            {
                nurseList.Add(new Nurse()
                {
                    NurseNIP = nurse.NurseNIP,
                    NurseName = nurse.NurseName,
                    NurseAge = nurse.NurseAge,
                    ScoreFinal = defuzzyfication,
                    Note = graduateFinal
                });
                Console.Clear();
                Console.WriteLine("Data anda telah disimpan. \n");
                Home();
            }
            else if (answer == "n" || answer == "no")
            {
                Console.Clear();
                Home();
            }
            else
            {
                Console.WriteLine("Tidak ada pilihan yg tersedia. \n");
                ConfirmSave();
            }
        }

        static void Welcome()
        {
            Console.WriteLine("Selamat Datang di Sistem Pakar \n" +
                "Aplikasi Sertifikasi Perawat \n");
        }

        static void InputData()
        {
            Console.WriteLine();
            if (_error) Console.WriteLine(messageError + ", masukan ulang kembali data anda dgn benar!");

            Console.Write("Masukan NIP: ");
            string nip = Console.ReadLine();
            nurse.NurseNIP = Convert.ToInt32(nip);
            if (!nurse.ConfirmNIP(nip.Length))
            {
                Console.Clear();
                _error = true;
                messageError = "NIP harus 6 digit";
                RefreshInputData();
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
                    RefreshInputData();
                }
                else _error = false;
            }
        }

        static void _InputData(bool cache = true)
        {
            string add = "Masukan ";
            Console.WriteLine();
            Console.WriteLine((cache ? add : "") + "NIP: " + nurse.NurseNIP);
            Console.WriteLine((cache ? add : "") + "Nama: " + nurse.NurseName);
            Console.WriteLine((cache ? add : "") + "Umur: " + nurse.NurseAge);
        }

        static void InputScore()
        {
            Console.WriteLine();
            if (_error) Console.WriteLine(messageError + ", masukan ulang kembali data anda dgn benar!");

            Console.Write("Masukan Nilai Tes Tulis ({0}-{1}): ", set.writeLow, set.writeHigh);
            double testWrite = Convert.ToDouble(Console.ReadLine());
            score.TestWrite = testWrite;
            if (!score.ConfirmTestWrite(testWrite))
            {
                Console.Clear();
                _error = true;
                messageError = $"Nilai Tes Tulis harus {set.writeLow}-{set.writeHigh}";
                RefreshInputScore();
            }
            else
            {
                _error = false;
                Console.Write("Masukan Nilai Tes Praktek ({0}-{1}): ", set.practiceLow, set.practiceHigh);
                double testPractice = Convert.ToDouble(Console.ReadLine());
                score.TestPractice = testPractice;
                if (!score.ConfirmTestPractice(testPractice))
                {
                    Console.Clear();
                    _error = true;
                    messageError = $"Nilai Tes Praktek harus {set.practiceLow}-{set.practiceHigh}";
                    RefreshInputScore();
                }
                else _error = false;
            }
        }

        static void _InputScore(bool cache = true)
        {
            string add = "Masukan ";
            string write = $"({set.writeLow}-{set.writeHigh})";
            string practice = $"({set.practiceLow}-{set.practiceHigh})";
            Console.WriteLine();
            Console.WriteLine((cache ? add : "") + $"Nilai Tes Tulis {(cache ? write : "\u0008")}: {score.TestWrite}");
            Console.WriteLine((cache ? add : "") + $"Nilai Tes Praktek {(cache ? practice : "\u0008")}: {score.TestPractice}");
        }

        static void RefreshInputData()
        {
            Welcome();
            InputData();
        }

        static void RefreshInputScore()
        {
            Welcome();
            _InputData();
            InputScore();
        }

        static void Calculation()
        {
            Console.Clear();
            Welcome();
            _InputData(false);
            _InputScore(false);
            RunFuzzy(score.TestWrite, score.TestPractice);
            Level();
            Conjunction();
            Disjunction();
            Defuzzyfication();
            ResultTest();
        }

        static void Level()
        {
            Console.WriteLine();
            Console.WriteLine($"Derajat Keanggotaan: \n" +
                $"Tes Tulis Kurang: {writeLowLevel} \t Tes Praktek Kurang: {practiceLowLevel} \n" +
                $"Tes Tulis Cukup: {writeMidLevel} \t Tes Praktek Cukup: {practiceMidLevel} \n" +
                $"Tes Tulis Baik: {writeHighLevel} \t Tes Praktek Baik: {practiceHighLevel}");
        }

        static void Conjunction()
        {
            Console.WriteLine();
            Console.WriteLine($"Konjungsi: \n" +
                $"Tes Tulis Kurang: {writeLowLevel} AND Tes Praktek Kurang: {practiceLowLevel} \n" +
                $"Tes Tulis Kurang: {writeLowLevel} AND Tes Praktek Cukup: {practiceMidLevel} \n" +
                $"Tes Tulis Cukup: {writeMidLevel} AND Tes Praktek Kurang: {practiceLowLevel} \n" +
                $"Tes Tulis Cukup: {writeMidLevel} AND Tes Praktek Cukup: {practiceMidLevel}");
        }

        static void Disjunction()
        {
            Console.WriteLine();
            Console.WriteLine($"Disjungsi: \n" +
                $"Tes Tulis Kurang: {disjunction1} OR Tes Praktek Kurang: {disjunction3} THEN Tidak Lulus {graduateNot} \n" +
                $"Tes Tulis Cukup: {disjunction2} OR Tes Praktek Cukup: {disjunction4} THEN Lulus {graduateYes}");
        }

        static void Defuzzyfication()
        {
            Console.WriteLine();
            Console.WriteLine($"Defuzzyfikasi: \n" +
                $"Total Penilaian: {defuzzyfication}");
        }

        static void ResultTest()
        {
            Console.WriteLine();
            Console.WriteLine($"Hasil dari perhitungan adalah {graduateFinal}");
        }

        static void DataSave()
        {
            var dataList = from nurse in nurseList
                           orderby nurse.NurseName ascending
                           select nurse;
            if (dataList.Count() == 0)
            {
                Console.WriteLine("Tidak ada data yang tersimpan. \n");
                Home();
            }
            else
            {
                Console.WriteLine("Berikut data yang telah tersimpan: ");
                foreach (var data in dataList)
                {
                    Console.WriteLine($"- NIP:{data.NurseNIP}, Nama:{data.NurseName}, Umur:{data.NurseAge}, " +
                        $"Nilai:{data.ScoreFinal}, Keterangan:{data.Note}");
                }
                Console.WriteLine();
                Home();
            }
        }
    }
}