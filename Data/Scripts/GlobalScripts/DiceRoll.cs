﻿using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class DiceRoll
{
    static Random random = new Random();

    public static int Roll(int diceEdge, int roll = 1)
    {     
        // Сумма всех выпавших значений
        int total = 0;

        // Кидаем кубы (минимум 1 раз)
        for (int i = 0; i < roll; i++)
        {
            // Сумируем результаты
            total += random.Next(0, diceEdge + 1);
        }

        return total;
    }
}