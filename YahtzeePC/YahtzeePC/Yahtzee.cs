using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YahtzeePC
{
    class Yahtzee
    {
        public Boolean[] selected = {false, false, false, false, false, false};
        public int[] dice = new int[5];
        public int turnCount = 0;
        public int totalScore = 0;
        public int rollsPerTurn = 3;
        public int totalTurns = 0;
        public Random gen = new Random();

        public void select(int n)
        {
            selected[n] = true;
        }
        public Boolean Roll()
        {
            if (turnCount < rollsPerTurn)
            {
                for (int i = 0; i < dice.Length; i++)
                {
                    if (!selected[i])
                    {
                        dice[i] = gen.Next(6) + 1;
                    }
                }
                turnCount++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public double getRandom(int max)
        {
            return gen.Next(max) + 1;
        }
        public void newTurn()
        {
            turnCount = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = 0;
            }
        }
        // TODO: What should I put in this damn method?
        public void endGame()
        {

        }

        
        // THe VARIOUS SCORING FORMS:
        public int numbers(int n)
        {
            int turnTotal = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                if (dice[i] == n)
                {
                    totalScore += n;
                    turnTotal += n;
                }
            }
            return turnTotal;
        }
        public int ofAKind(int n)
        {
            int duplicates = 1, highestRecurringN = 0, currentDuplicates = 1, turnTotal = 0;
            Array.Sort(dice);
            for (int j = 0; j < dice.Length - n + 1; j++)
            {
                for (int k = j; k < j + n - 1; k++)
                {
                    if (dice[k] != dice[k + 1] || dice[k] == 0)
                    {
                        currentDuplicates = 1;
                        break;
                    }
                    else
                    {
                        currentDuplicates++;
                        if (dice[k] >= highestRecurringN)
                        {
                            highestRecurringN = dice[k];
                        }
                    }
                }
                if (currentDuplicates > duplicates)
                {
                    duplicates = currentDuplicates;
                }
                currentDuplicates = 1;
            }
            if (duplicates >= n)
            {
                for (int i = 0; i < dice.Length; i++)
                {
                    turnTotal += dice[i];
                }
            }
            totalScore += turnTotal;
            return turnTotal;
        }
        public int straight(int n)
        {
            int currentLength = 1, highestEnd = 0, length = 1;
            List<int> MyDice = new List<int>();
            Array.Sort(dice);
            for (int i = 0; i < dice.Length; i++)
            {
                MyDice.Add(dice[i]);
            }
            RemoveDuplicates(MyDice).CopyTo(dice);
            for (int i = 0; i < dice.Length + 1 - n; i++)
            {
                for (int j = i; j < i + n - 1; j++)
                {
                    if (dice[j] != dice[j + 1] - 1)
                    {
                        currentLength = 1;
                        break;
                    }
                    else
                    {
                        currentLength++;
                        if (dice[j + 1] >= highestEnd)
                        {
                            highestEnd = dice[j + 1];
                        }
                    }
                }
                if (currentLength > length)
                {
                    length = currentLength;
                }
                currentLength = 1;
            }
            if (length >= n)
            {
                if (n == 4)
                {
                    totalScore += 30;
                    return 30;
                }
                else if (n == 5)
                {
                    totalScore += 40;
                    return 40;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        public int yahtzee()
        {
            Boolean isYahtzee = false;
            for (int i = 0; i < dice.Length - 1; i++)
            {
                if (dice[i] != dice[i + 1] || dice[i] == 0)
                {
                    isYahtzee = false;
                    break;
                }
                isYahtzee = true;
            }
            if (isYahtzee)
            {
                totalScore += 50;
                return 50;
            }
            else
            {
                return 0;
            }
        }
        public int chance()
        {
            int sum = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                sum += dice[i];
            }
            totalScore += sum;
            return sum;
        }
        public int fullHouse()
        {
            if (dice[0] != 0)
            {
                int[] nOfRepeats = new int[6];
                int zeroes = 0, highestN = 0;
                Array.Sort(dice);
                for (int i = 0; i < dice.Length; i++)
                {
                    for (int j = 0; j < nOfRepeats.Length; j++)
                    {
                        if (dice[i] == j + 1)
                        {
                            nOfRepeats[j]++;
                            break;
                        }
                    }
                }
                for (int i = 0; i < nOfRepeats.Length; i++)
                {
                    if (nOfRepeats[i] == 0)
                    {
                        zeroes++;
                    }
                    if (nOfRepeats[i] >= highestN)
                    {
                        highestN = nOfRepeats[i];
                    }
                }
                if (zeroes < 4)
                {
                    return 0;
                }
                else
                {
                    if (highestN == 4)
                    {
                        return 0;
                    }
                    else
                    {
                        totalScore += 25;
                        return 25;
                    }
                }
            }
            else
                return 0;
        }



        // HELPERS:
        public void printMyArray(String title, int[] a)
        {
            Console.WriteLine(title);
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }
        private List<int> RemoveDuplicates(List<int> MyDice)
        {
            List<int> TempDice = new List<int>(), MyTempDice = new List<int>();
            //copying MyDice to MyTempDIce
            for (int i = 0; i < MyDice.Count; i++)
            {
                MyTempDice.Add(MyDice[i]);
            }

            while (MyTempDice.Count > 0)
            {
                if (!TempDice.Contains(MyTempDice[0]))
                {
                    TempDice.Add(MyTempDice[0]);
                }
                MyTempDice.RemoveAt(0);
            }
            return TempDice;
        }
        
    }
}
