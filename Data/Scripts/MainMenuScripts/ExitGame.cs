﻿using Godot;
using System;

public partial class ExitGame : TextureButton
{
    public override void _Ready()
    {
        // Событие на нажатие
        Pressed += ButtonPressed;
        // Событие на вход курсора на карту
        MouseEntered += Entered;
        // Событие на выход курсора на карту
        MouseExited += Exited;
    }

    private void ButtonPressed()
    {
        GetTree().Quit();
    }
    private void Entered()
    {
        // Задаем курсору вид "лапки"
        CursorStyleController.SetBeam();

        Position = new Vector2(Position.X, Position.Y - 2);
    }

    private void Exited()
    {
        // Задаем курсору вид "стрелки"
        CursorStyleController.SetArrow();

        Position = new Vector2(Position.X, Position.Y + 2);
    }
}
