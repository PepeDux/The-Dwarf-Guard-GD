using Godot;
using System;
using System.Linq;

public partial class ClearHolder : Node
{
	private Node enemiesHolder;
	private Node playerHolder;
	private Node staticObjectsHolder;
	private Node functioanalObjectsHolder;

	public override void _Ready()
	{
		enemiesHolder = GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode("EnemiesHolder");
		playerHolder = GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode("PlayerHolder");
		staticObjectsHolder = GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode("StaticObjectsHolder");
		functioanalObjectsHolder = GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode("FunctioanalObjectsHolder");
	}

	public void ClearAll()
	{
		//Очищаем всех врагов
		Clear(enemiesHolder);

		//Очищаем игрока
		Clear(playerHolder);

		//Очищаем статичные объекты
		Clear(staticObjectsHolder);

		//Очищаем функциональные объекты
		Clear(functioanalObjectsHolder);
	}

	private void Clear(Node holder)
	{
		if (holder.GetChildren().Count() != null)
		{
			foreach (Node child in holder.GetChildren())
			{
				child.Free();
			}
		}
	}
}
