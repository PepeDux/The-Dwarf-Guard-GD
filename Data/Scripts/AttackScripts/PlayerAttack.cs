using Godot;
using System;
using System.Linq;

public partial class PlayerAttack : AttackScript
{
    // Метод, который вызывается каждый кадр
    public override void _Process(double delta)
    {
        // Проверяем, была ли нажата правая кнопка мыши, у игрока достаточно очков действия, и он может выполнить действие
        if (Input.IsActionJustPressed("RightMouseClick") &&
            GetParent<Player>().ActionPoints > 0 &&
            GetParent<Player>().canPerformAction)
        {
            // Перебираем всех персонажей из хранилища персонажей
            foreach (var target in CharacterStorage.characters)
            {
                // Проверяем, совпадает ли координата мыши с координатой цели и является ли цель врагом
                if (MouseSelectTile.MouseCellPosition == target.Coordinate && target is Enemy)
                {
                    // Выполняем расчет атаки на цель
                    CalculationAttack(target);
                }
            }

            // Запрещаем игроку выполнять действия
            GetParent<Player>().canPerformAction = false;

            // Вызываем событие, сигнализирующее о завершении действия игрока
            Events.finishedPlayerAction?.Invoke();
        }
    }
}
