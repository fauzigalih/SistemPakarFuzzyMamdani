using System;

namespace SistemPakarFuzzyMamdani
{
    class Fuzzy
    {
        static Formula formula = new Formula();
        static Setting set = new Setting();

        protected static void RunFuzzy(double write, double practice)
        {
            LevelFuzzy(write, practice);
            ConjunctionFuzzy();
            DisjunctionFuzzy();
            DefuzzyficationFuzzy();
        }

        //Level
        public static double writeLowLevel;
        public static double writeMidLevel;
        public static double writeHighLevel;
        public static double practiceLowLevel;
        public static double practiceMidLevel;
        public static double practiceHighLevel;

        static void LevelFuzzy(double write, double practice)
        {
            writeLowLevel = Math.Round(formula.WriteLow(write), 2);
            writeMidLevel = Math.Round(formula.WriteMid(write), 2);
            writeHighLevel = Math.Round(formula.WriteHigh(write), 2);
            practiceLowLevel = Math.Round(formula.PracticeLow(practice), 2);
            practiceMidLevel = Math.Round(formula.PracticeMid(practice), 2);
            practiceHighLevel = Math.Round(formula.PracticeHigh(practice), 2);
        }

        //Conjunction
        public static double writeLowConjunction;
        public static double writeMidConjunction;
        public static double practiceLowConjunction;
        public static double practiceMidConjunction;

        static void ConjunctionFuzzy()
        {
            writeLowConjunction = writeLowLevel;
            writeMidConjunction = writeMidLevel;
            practiceLowConjunction = practiceLowLevel;
            practiceMidConjunction = practiceMidLevel;
        }

        //Disjunction
        public static double disjunction1 = formula.Disjunction1(writeLowConjunction, practiceLowConjunction);
        public static double disjunction2 = formula.Disjunction2(writeLowConjunction, practiceMidConjunction);
        public static double disjunction3 = formula.Disjunction3(writeMidConjunction, practiceLowConjunction);
        public static double disjunction4 = formula.Disjunction4(writeMidConjunction, practiceMidConjunction);

        static void DisjunctionFuzzy()
        {
            disjunction1 = formula.Disjunction1(writeLowConjunction, practiceLowConjunction);
            disjunction2 = formula.Disjunction2(writeLowConjunction, practiceMidConjunction);
            disjunction3 = formula.Disjunction3(writeMidConjunction, practiceLowConjunction);
            disjunction4 = formula.Disjunction4(writeMidConjunction, practiceMidConjunction);
        }

        //Defuzzyfication
        static double node1 = set.graduateLow;
        static double node2 = set.graduateLow + ((set.graduateHighMid - set.graduateLow) / 2);
        static double node3 = set.graduateHighMid;
        static double node4 = set.graduateHighMid + ((set.graduateLowMid - set.graduateHighMid) / 2);
        static double node5 = set.graduateLowMid;
        static double node6 = set.graduateLowMid + ((set.graduateHigh - set.graduateLowMid) / 2);
        static double node7 = set.graduateHigh;

        public static double graduateNot;
        public static double graduateYes;

        public static double defuzzyfication;
        public static string graduateFinal;

        static void DefuzzyficationFuzzy()
        {
            graduateNot = formula.GraduateNot(disjunction1, disjunction3);
            graduateYes = formula.GraduateYes(disjunction2, disjunction4); 
            double nodes = ((node1 + node2 + node3) * graduateNot) + ((node4 + node5 + node6 + node7) * graduateYes);
            double nodesAll = (graduateNot * 3) + (graduateYes * 4);
            defuzzyfication = Math.Round(nodes / nodesAll, 2);
            graduateFinal = formula.GraduateFinal(defuzzyfication, set.graduateLowMid);
        }
    }
}
