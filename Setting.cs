using System;

namespace SistemPakarFuzzyMamdani
{
    class Setting
    {
        public int password = 1234;

        public int nip = 6;
        public int age = 17;

        public double writeLow = 40;
        public double writeLowMid = 65;
        public double writeHighMid = 76;
        public double writeHigh = 90;

        public double practiceLow = 40;
        public double practiceLowMid = 55;
        public double practiceHighMid = 60;
        public double practiceHigh = 80;

        public double graduateLow = 45;
        public double graduateHighMid = 60;
        public double graduateLowMid = 65;
        public double graduateHigh = 80;

        public string graduateNot = "Tidak Lulus";
        public string graduateYes = "Lulus";
    }
}
