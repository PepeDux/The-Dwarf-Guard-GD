﻿using Godot;
using System;

public partial class Events : Node
{
    /// <summary>
    /// Событие на окончание хода игрока/
    /// </summary>
    public static Action playerTurnFinished;

    /// <summary>
    /// Событие на окончание хода других объектов на поле/
    /// </summary>
    public static Action otherTurnFinished;

    /// <summary>
    /// Событие на окончание уровня
    /// </summary>
    public static Action levelEnded;

    /// <summary>
    /// Событие на начало уровня
    /// </summary>
    public static Action levelStarted;

    /// <summary>
    /// Событие на окончание генерации тайлов
    /// </summary>
    public static Action levelGenerated;


}
