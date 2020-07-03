using System;

namespace SistemPakarFuzzyMamdani
{
    class Fuzzy
    {
        static Formula formula = new Formula();
        static Fuzzy fuzzy = new Fuzzy();
        static double write = new Score().TestWrite;
        static double practice = new Score().TestPractice;
        static Setting set = new Setting();

        //Level
        public double writeLowLevel = Math.Round(formula.WriteLow(write), 2);
        public double writeMidLevel = Math.Round(formula.WriteMid(write), 2);
        public double writeHighLevel = Math.Round(formula.WriteHigh(write), 2);
        public double practiceLowLevel = Math.Round(formula.PracticeLow(practice), 2);
        public double practiceMidLevel = Math.Round(formula.PracticeMid(practice), 2);
        public double practiceHighLevel = Math.Round(formula.PracticeHigh(practice), 2);

        //Conjunction
        public double writeLowConjunction = fuzzy.writeLowLevel;
        public double writeMidConjunction = fuzzy.writeMidLevel;
        public double practiceLowConjunction = fuzzy.practiceLowLevel;
        public double practiceMidConjunction = fuzzy.practiceMidLevel;

        //Disjunction
        public double disjunction1 = formula.Disjunction1(fuzzy.writeLowConjunction, fuzzy.practiceLowConjunction);
        public double disjunction2 = formula.Disjunction2(fuzzy.writeLowConjunction, fuzzy.practiceMidConjunction);
        public double disjunction3 = formula.Disjunction3(fuzzy.writeMidConjunction, fuzzy.practiceLowConjunction);
        public double disjunction4 = formula.Disjunction4(fuzzy.writeMidConjunction, fuzzy.practiceMidConjunction);

        //Defuzzyfication
        static double node1 = set.graduateLow;
        static double node2 = set.graduateLow + ((set.graduateHighMid - set.graduateLow) / 2);
        static double node3 = set.graduateHighMid;
        static double node4 = set.graduateHighMid + ((set.graduateLowMid - set.graduateHighMid) / 2);
        static double node5 = set.graduateLowMid;
        static double node6 = set.graduateLowMid + ((set.graduateHigh - set.graduateLowMid) / 2);
        static double node7 = set.graduateHigh;

        public double graduateNot = formula.GraduateNot(fuzzy.disjunction1, fuzzy.disjunction3);
        public double graduateYes = formula.GraduateYes(fuzzy.disjunction2, fuzzy.disjunction4);

        static double nodes = ((node1 + node2 + node3) * fuzzy.graduateNot) + ((node4 + node5 + node6 + node7) * fuzzy.graduateYes);
        static double nodesAll = (fuzzy.graduateNot * 3) + (fuzzy.graduateYes * 4);

        public double defuzzyfication = nodes / nodesAll;
        public string graduateFinal = formula.GraduateFinal(fuzzy.defuzzyfication, set.graduateLowMid);
    }
}
