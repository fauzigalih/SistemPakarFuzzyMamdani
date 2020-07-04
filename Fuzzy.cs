using System;

namespace SistemPakarFuzzyMamdani
{
    class Fuzzy
    {
        static Formula formula = new Formula();
        static double write = 88;
        //static double write = new Score().TestWrite;
        static double practice = 77;
        //static double practice = new Score().TestPractice;
        static Setting set = new Setting();


        //Level
        public static double writeLowLevel = Math.Round(formula.WriteLow(write), 2);
        public static double writeMidLevel = Math.Round(formula.WriteMid(write), 2);
        public static double writeHighLevel = Math.Round(formula.WriteHigh(write), 2);
        public static double practiceLowLevel = Math.Round(formula.PracticeLow(practice), 2);
        public static double practiceMidLevel = Math.Round(formula.PracticeMid(practice), 2);
        public static double practiceHighLevel = Math.Round(formula.PracticeHigh(practice), 2);

        //Conjunction
        public static double writeLowConjunction = writeLowLevel;
        public static double writeMidConjunction = writeMidLevel;
        public static double practiceLowConjunction = practiceLowLevel;
        public static double practiceMidConjunction = practiceMidLevel;

        //Disjunction
        public static double disjunction1 = formula.Disjunction1(writeLowConjunction, practiceLowConjunction);
        public static double disjunction2 = formula.Disjunction2(writeLowConjunction, practiceMidConjunction);
        public static double disjunction3 = formula.Disjunction3(writeMidConjunction, practiceLowConjunction);
        public static double disjunction4 = formula.Disjunction4(writeMidConjunction, practiceMidConjunction);

        //Defuzzyfication
        static double node1 = set.graduateLow;
        static double node2 = set.graduateLow + ((set.graduateHighMid - set.graduateLow) / 2);
        static double node3 = set.graduateHighMid;
        static double node4 = set.graduateHighMid + ((set.graduateLowMid - set.graduateHighMid) / 2);
        static double node5 = set.graduateLowMid;
        static double node6 = set.graduateLowMid + ((set.graduateHigh - set.graduateLowMid) / 2);
        static double node7 = set.graduateHigh;

        public static double graduateNot = formula.GraduateNot(disjunction1, disjunction3);
        public static double graduateYes = formula.GraduateYes(disjunction2, disjunction4);

        static double nodes = ((node1 + node2 + node3) * graduateNot) + ((node4 + node5 + node6 + node7) * graduateYes);
        static double nodesAll = (graduateNot * 3) + (graduateYes * 4);

        public static double defuzzyfication = nodes / nodesAll;
        public static string graduateFinal = formula.GraduateFinal(defuzzyfication, set.graduateLowMid);
    }
}
