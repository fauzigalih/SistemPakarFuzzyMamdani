using System;

namespace SistemPakarFuzzyMamdani
{
    class Formula
    {
        static readonly Setting set = new Setting();

        public readonly double writeLow;
        public readonly double writeLowMid;
        public readonly double writeHighMid;
        public readonly double writeHigh;

        public readonly double practiceLow;
        public readonly double practiceLowMid;
        public readonly double practiceHighMid;
        public readonly double practiceHigh;

        public Formula()
        {
            writeLow = set.writeLow;
            writeLowMid = set.writeLowMid;
            writeHighMid = set.writeHighMid;
            writeHigh = set.writeHigh;
            practiceLow = set.practiceLow;
            practiceLowMid = set.practiceLowMid;
            practiceHighMid = set.practiceHighMid;
            practiceHigh = set.practiceHigh;
        }

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
            else if (write > writeLowMid || write < writeHighMid) x = 1;
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
            else if (practice > practiceLowMid || practice < practiceHighMid) x = 1;
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
            else if (writeLowConjunction >= practiceLowConjunction) x = practiceLowConjunction;
            return x;
        }

        public double Disjunction2(double writeLowConjunction, double practiceMidConjunction)
        {
            double x = -1;
            if (writeLowConjunction < practiceMidConjunction) x = writeLowConjunction;
            else if (writeLowConjunction >= practiceMidConjunction) x = practiceMidConjunction;
            return x;
        }

        public double Disjunction3(double writeMidConjunction, double practiceLowConjunction)
        {
            double x = -1;
            if (writeMidConjunction < practiceLowConjunction) x = writeMidConjunction;
            else if (writeMidConjunction >= practiceLowConjunction) x = practiceLowConjunction;
            return x;
        }

        public double Disjunction4(double writeMidConjunction, double practiceMidConjunction)
        {
            double x = -1;
            if (writeMidConjunction < practiceMidConjunction) x = writeMidConjunction;
            else if (writeMidConjunction >= practiceMidConjunction) x = practiceMidConjunction;
            return x;
        }

        public double GraduateNot(double disjunction1, double disjunction3)
        {
            double x = -1;
            if (disjunction1 > disjunction3) x = disjunction1;
            else if (disjunction1 <= disjunction3) x = disjunction3;
            return x;
        }

        public double GraduateYes(double disjunction2, double disjunction4)
        {
            double x = -1;
            if (disjunction2 > disjunction4) x = disjunction2;
            else if (disjunction2 <= disjunction4) x = disjunction4;
            return x;
        }

        public string GraduateFinal(double defuzzyfication, double graduateLowMid)
        {
            string x = "Not Found!";
            if (defuzzyfication <= graduateLowMid) x = set.graduateNot;
            else if (defuzzyfication > graduateLowMid) x = set.graduateYes;
            return x.ToUpper();
        }
    }
}
