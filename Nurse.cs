using System;

namespace SistemPakarFuzzyMamdani
{
    class Nurse
    {
        public int NurseNIP { get; set; }
        public string NurseName { get; set; }
        public int NurseAge { get; set; }
        public double ScoreFinal { get; set; }
        public string Note { get; set; }

        public int TestWrite { get; set; }
        public int TestPractice { get; set; }

        public bool ConfirmNIP(int nip) => nip == 6;
        public bool ConfirmAge(int age) => age > 17;
        public bool ConfirmTestWrite(int x) => x >= 20 && x <= 90;
        public bool ConfirmTestPractice(int x) => x >= 20 && x <= 90;
    }
}
