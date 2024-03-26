using Godot;
using System;
using System.Linq;
using System.Threading.Tasks;

public partial class TurnController : Node
{
    // Объявление приватных переменных для отслеживания текущего хода и активного персонажа
    private int currentTurn = 1;
    private int currentWalker = 0;

    public override void _Ready()
    {
        // Подписка на события завершения хода игрока и добавление текущего персонажа
        Events.playerTurnFinished += AddTurn;
        Events.playerTurnFinished += AddCurrentWalker;

        // Подписка на событие завершения хода врага и добавление текущего персонажа
        Events.finishedEnemyTurn += AddCurrentWalker;
    }

    private void AddTurn()
    {
        // Инкриментация текущего хода
        currentTurn++;
        // Сброс текущего персонажа, чтобы начать сначала
        currentWalker = 0;
    }

    private void AddCurrentWalker()
    {
        // Инкриментация текущего ходящего
        currentWalker++;

        // Запуск хода
        Turn();
    }

    private void Turn()
    {
        // Получение персонажа по текущему индексу
        Character charac = CharacterStorage.characters[currentWalker];

        if (charac is Enemy)
        {
            // Вывод индекса текущего персонажа
            //GD.Print(currentWalker);

            // Запуск хода врага
            ((Enemy)charac).Turn();
        }
    }
}
