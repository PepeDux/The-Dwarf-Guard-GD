using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class DiceRoll
{
    // Бросок куба
    public static int Roll(int diceEdges, int diceRolls = 1)
    {     
        // Сумма всех выпавших значений
        int total = 0;

        // Кидаем кубы (минимум 1 раз)
        for (int i = 0; i < diceRolls; i++)
        {
            // Сумируем результаты
            total += new Random().Next(1, diceEdges + 1);
        }

        return total;
    }

    // Бросок куба с преимуществом (бросается 2 куба, выбирается наивысшее значение)
    public static int RollAdvantage(int diceEdges, int diceRolls = 1)
    {
        return Math.Max(Roll(diceEdges, diceRolls), Roll(diceEdges, diceRolls));
    }

    // Бросок куба с помехой (бросается 2 куба, выбирается наименьшее значение)
    public static int RollDisadvantage(int diceEdges, int diceRolls = 1)
    {
        return Math.Min(Roll(diceEdges, diceRolls), Roll(diceEdges, diceRolls));
    }
}