using System;

namespace SistemPakarFuzzyMamdani
{
    class Nurse
    {
        static Setting set = new Setting();

        public int NurseNIP { get; set; }
        public string NurseName { get; set; }
        public int NurseAge { get; set; }
        public double ScoreFinal { get; set; }
        public string Note { get; set; }

        public bool ConfirmNIP(int nip) => nip == set.nip;
        public bool ConfirmAge(int age) => age > set.age;
    }
}
