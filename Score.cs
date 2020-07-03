using System;

namespace SistemPakarFuzzyMamdani
{
    class Score
    {
        static Setting set = new Setting();

        public double TestWrite { get; set; } = 40;
        public double TestPractice { get; set; } = 40;

        public bool ConfirmTestWrite(double write) => write >= set.writeLow && write <= set.writeHigh;
        public bool ConfirmTestPractice(double practice) => practice >= set.practiceLow && practice <= set.practiceHigh;
    }
}
