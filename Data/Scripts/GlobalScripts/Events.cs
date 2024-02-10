using Godot;
using System;

public partial class Events : Node
{
	/// <summary/
	/// Событие на спавн игрока
	/// </summary>
	public static Action playerSpawned;

	/// <summary>
	/// Событие на окончание хода игрока
	/// </summary>
	public static Action playerTurnFinished;

	/// <summary>
	/// Событие на смерть игрока
	/// </summary>
	public static Action playerDied;

	/// <summary>
	/// Событие на конец хода объекта
	/// </summary>
	public static Action endedHisTurn;

	/// <summary>
	/// Событие на окончание хода других объектов на поле
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

	/// <summary>
	/// Событие на окончание выбора карты игроком
	/// </summary>
	public static Action endSelectCard;
}
