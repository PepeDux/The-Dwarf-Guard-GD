using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class DiceRoll
{
    static Random random = new Random();

    public static int Roll(int diceEdges, int diceRolls = 1)
    {     
        // Сумма всех выпавших значений
        int total = 0;

        // Кидаем кубы (минимум 1 раз)
        for (int i = 0; i < diceRolls; i++)
        {
            // Сумируем результаты
            total += random.Next(1, diceEdges + 1);
        }

        return total;
    }
}