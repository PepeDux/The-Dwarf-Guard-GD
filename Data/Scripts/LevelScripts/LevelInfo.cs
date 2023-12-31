﻿using Godot;
using System;

public partial class LevelInfo : Node
{
    //[Header("Юниты на уровне")]
    //Колличество юнитов которые нужно заспавнить при старте уровня
    [Export] public int melee; //Ближники 
    [Export] public int range; //Дальники
    [Export] public int captain; //Капитаны
    [Export] public int wizard; //Колдуны

    //[Header("Статичные объекты")]
    //Колличество статичных объектов которые нужно заспавнить при старте уровня
    [Export] public int wall; //Стены
    [Export] public int pit; //Ямы

    //[Header("Функциональные объекты")]
    [Export] public int trap; //Ловушки
    [Export] public int food; //Еда
    [Export] public int money; //Монеты
    [Export] public int crystal; //Кристаллы
}
