using Godot;
using System;

public partial class Events : Node
{
    /// <summary>
    /// Событие, возникающее при спавне игрока.
    /// Это событие должно быть вызвано всякий раз, когда новый игрок появляется в игре.
    /// </summary>
    public static Action playerSpawned;

    /// <summary>
    /// Событие, возникающее при окончании хода игрока.
    /// Может использоваться для выполнения логики после завершения действий игрока на его ходу.
    /// </summary>
    public static Action playerTurnFinished;

    /// <summary>
    /// Событие, возникающее при окончании хода вражеского объекта.
    /// Используется для обработки событий после завершения хода врага или неигрового персонажа (NPC).
    /// </summary>
    public static Action finishedEnemyTurn;

    /// <summary>
    /// Событие, возникающее при окончании хода всех объектов, кроме игрока.
    /// Полезно для запуска логики, которая должна происходить после завершения всех вражеских или NPC ходов.
    /// </summary>
    public static Action finishedAllTurn;

    /// <summary>
    /// Событие, возникающее после завершения действия игрока.
    /// Подходит для случаев, когда нужно отреагировать на конец конкретного действия игрока, например, после атаки или передвижения.
    /// </summary>
    public static Action finishedPlayerAction;

    /// <summary>
    /// Событие, возникающее при смерти игрока.
    /// Может быть использовано для обработки игровой логики после того, как игрок умирает, например, для показа экрана поражения.
    /// </summary>
    public static Action playerDied;

    /// <summary>
    /// Событие, возникающее при завершении уровня.
    /// Используется для обработки завершения уровня, например, для загрузки следующего уровня или показа статистики.
    /// </summary>
    public static Action levelEnded;

    /// <summary>
    /// Событие, возникающее после завершения генерации уровня.
    /// Полезно для случаев, когда нужно запустить какую-то логику после того, как все тайлы уровня были сгенерированы.
    /// </summary>
    public static Action levelGenerated;

    /// <summary>
    /// Событие, возникающее после выбора карты игроком.
    /// Может использоваться для обработки дальнейших действий после того, как игрок выбрал карту в игре.
    /// </summary>
    public static Action endSelectCard;

    /// <summary>
    /// Событие, возникающее при передвижении персонажа.
    /// Принимает в качестве параметра объект типа Character, который содержит информацию о перемещаемом персонаже.
    /// Используется для обновления состояния игры или интерфейса после перемещения персонажа.
    /// </summary>
    public static Action<Character> characterMoved;

    /// <summary>
    /// Событие, возникающее при перетасовке или замене карт (реролл).
    /// Полезно для запуска логики, которая должна происходить после изменения набора карт у игрока.
    /// </summary>
    public static Action rerolledCards;

    /// <summary>
    /// Событие, возникающее при сбросе карт.
    /// Может быть использовано для обработки логики, связанной со сбросом карт из руки игрока.
    /// </summary>
    public static Action droppedCards;
}