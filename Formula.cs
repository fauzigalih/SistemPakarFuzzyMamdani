using System;

namespace SistemPakarFuzzyMamdani
{
    class Formula
    {
        static Setting set = new Setting();

        public double writeLow = set.writeLow;
        public double writeLowMid = set.writeLowMid;
        public double writeHighMid = set.writeHighMid;
        public double writeHigh = set.writeHigh;

        public double practiceLow = set.practiceLow;
        public double practiceLowMid = set.practiceLowMid;
        public double practiceHighMid = set.practiceHighMid;
        public double practiceHigh = set.practiceHigh;

        public double WriteLow(double write)
        {
            double x = -1;
            if (write <= writeLow) x = 1;
            else if (write >= writeLow && write <= writeLowMid) x = (writeLowMid - write) / (writeLowMid - writeLow);
            else if (write >= writeLowMid) x = 0;
            return x;
        }

        public double WriteMid(double write)
        {
            double x = -1;
            if (write <= writeLow || write >= writeHigh) x = 0;
            else if (write >= writeLow && write <= writeLowMid) x = (write - writeLow) / (writeLowMid - writeLow);
            else if (write >= writeHighMid && write <= writeHigh) x = (writeHigh - write) / (writeHigh - writeHighMid);
            else x = 1;
            return x;
        }

        public double WriteHigh(double write)
        {
            double x = -1;
            if (write <= writeHighMid) x = 0;
            else if (write >= writeHighMid && write <= writeHigh) x = (write - writeHighMid) / (writeHigh - writeHighMid);
            else if (write >= writeHigh) x = 1;
            return x;
        }

        public double PracticeLow(double practice)
        {
            double x = -1;
            if (practice <= practiceLow) x = 1;
            else if (practice >= practiceLow && practice <= practiceLowMid) x = (practiceLowMid - practice) / (practiceLowMid - practiceLow);
            else if (practice >= practiceLowMid) x = 0;
            return x;
        }

        public double PracticeMid(double practice)
        {
            double x = -1;
            if (practice <= practiceLow || practice >= practiceHigh) x = 0;
            else if (practice >= practiceLow && practice <= practiceLowMid) x = (practice - practiceLow) / (practiceLowMid - practiceLow);
            else if (practice >= practiceHighMid && practice <= practiceHigh) x = (practiceHigh - practice) / (practiceHigh - practiceHighMid);
            else x = 1;
            return x;
        }

        public double PracticeHigh(double practice)
        {
            double x = -1;
            if (practice <= practiceHighMid) x = 0;
            else if (practice >= practiceHighMid && practice <= practiceHigh) x = (practice - practiceHighMid) / (practiceHigh - practiceHighMid);
            else if (practice >= practiceHigh) x = 1;
            return x;
        }

        public double Disjunction1(double writeLowConjunction, double practiceLowConjunction)
        {
            double x = -1;
            if (writeLowConjunction < practiceLowConjunction) x = writeLowConjunction;
            else x = practiceLowConjunction;
            return x;
        }

        public double Disjunction2(double writeLowConjunction, double practiceMidConjunction)
        {
            double x = -1;
            if (writeLowConjunction < practiceMidConjunction) x = writeLowConjunction;
            else x = practiceMidConjunction;
            return x;
        }

        public double Disjunction3(double writeMidConjunction, double practiceLowConjunction)
        {
            double x = -1;
            if (writeMidConjunction < practiceLowConjunction) x = writeMidConjunction;
            else x = practiceLowConjunction;
            return x;
        }

        public double Disjunction4(double writeMidConjunction, double practiceMidConjunction)
        {
            double x = -1;
            if (writeMidConjunction < practiceMidConjunction) x = writeMidConjunction;
            else x = practiceMidConjunction;
            return x;
        }

        public double GraduateNot(double disjunction1, double disjunction3)
        {
            double x = -1;
            if (disjunction1 > disjunction3) x = disjunction1;
            else x = disjunction3;
            return x;
        }

        public double GraduateYes(double disjunction2, double disjunction4)
        {
            double x = -1;
            if (disjunction2 > disjunction4) x = disjunction2;
            else x = disjunction4;
            return x;
        }

        public string GraduateFinal(double defuzzyfication, double graduateLowMid)
        {
            string x = "Not Found!";
            if (defuzzyfication <= graduateLowMid) x = "Tidak Lulus";
            else if (defuzzyfication > graduateLowMid) x = "Lulus";
            return x.ToUpper();
        }
    }
}
