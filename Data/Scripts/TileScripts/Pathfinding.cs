using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Pathfinding : Node2D
{
	public List<Vector2I> pathToTarget = new List<Vector2I>(); //Путь к цели
	private List<Cell> checkedNodes = new List<Cell>(); //Проверенные ноды
	private List<Cell> freeNodes = new List<Cell>(); //Свободные ноды
	private List<Cell> waitingNodes = new List<Cell>(); //Ожидающие ноды

	public Player target; //Цель
	public bool finishTurn;


	private class Cell
	{
		public Vector2I Position; //Позиция ноды
		public Vector2I TargetPosition; //Позиция цели
		public Cell PreviousNode; //Ссылка на предыдущую ноду

		public float F; // F=G+H
		public float G; // расстояние от старта до ноды
		public float H; // расстояние от ноды до цели

		public Cell(float g, Vector2I nodePosition, Vector2I targetPosition, Cell previousNode)
		{
			Position = nodePosition;
			TargetPosition = targetPosition;
			PreviousNode = previousNode;

			G = g;
			H = Mathf.Abs(targetPosition.X - Position.X) + Mathf.Abs(targetPosition.Y - Position.Y);
			F = G + H;
		}
	}



	public override void _Ready()
	{
		finishTurn = true;
		target = GetParent<Enemy>().player;
	}



	public List<Vector2I> GetPath(Vector2I target)
	{
		checkedNodes.Clear(); //Проверенные ноды
		freeNodes.Clear(); //Свободные ноды
		waitingNodes.Clear(); //Ожидающие ноды

		Vector2I startPosition = GetParent<Enemy>().coordinate; //Стартовая координата врага
		Vector2I targetPosition = target; //Координата цели(Игрока)

		if (startPosition == targetPosition)
		{
			return pathToTarget;
		}

		Cell startNode = new Cell(0, startPosition, targetPosition, null); //Создаем новую ноду соответствующую стартовой позиции
		checkedNodes.Add(startNode); //Добавляем в список проверенных нод стартовую ноду
		waitingNodes.AddRange(GetNeighbourNodes(startNode)); //Вычисляем соседей стартовой ноды

		while (waitingNodes.Count > 0)
		{
			Cell nodeToCheck = waitingNodes.Where(x => x.F == waitingNodes.Min(y => y.F)).FirstOrDefault();

			//Если нода для проверки является целевой то возвращает значение для начала отсчета поиска пути
			if (nodeToCheck.Position == targetPosition)
			{
				return CalculatePathFromNode(nodeToCheck);
			}

			//Проверяем ноду на ловушку
			foreach (var trapCell in TileStorage.trapCells)
			{
				if (trapCell == nodeToCheck.Position)
				{
					nodeToCheck.G += 3;
				}
			}

			bool walkable = true;

			//Проверяем ноду на проходимость из списка непроходимых нод
			foreach (var impassableCell in TileStorage.impassableCells)	
			{
				if (impassableCell == nodeToCheck.Position)
				{
					walkable = false;
				}
			}

			//Если нода не проходима то...
			if (walkable == false)
			{
				waitingNodes.Remove(nodeToCheck); //Удаляет текущую проверяемую ноду из списка ожидающих проверку
				checkedNodes.Add(nodeToCheck); //Добавляет текущую проверяемую ноду в список проверенных нод
			}
			//Если нода проходима то...
			else if (walkable == true)
			{
				waitingNodes.Remove(nodeToCheck); //Удаляет текущую ноду из списка ожидающих проверку

				if (!checkedNodes.Where(x => x.Position == nodeToCheck.Position).Any())
				{
					checkedNodes.Add(nodeToCheck);
					waitingNodes.AddRange(GetNeighbourNodes(nodeToCheck));
				}
			}			
		}

		freeNodes = checkedNodes;

		return pathToTarget;
	}

	private List<Vector2I> CalculatePathFromNode(Cell node)
	{
		var pathToTarget = new List<Vector2I>();
		pathToTarget.Clear();

		Cell currentNode = node;

		while (currentNode.PreviousNode != null)
		{
			pathToTarget.Add(new Vector2I(currentNode.Position.X, currentNode.Position.Y));
			currentNode = currentNode.PreviousNode;
		}

		return pathToTarget;
	}

	private List<Cell> GetNeighbourNodes(Cell node)
	{
		var Neighbours = new List<Cell>();
		Neighbours.Clear();

		//Линейное перевдвижение
		if (GetParent<Enemy>().horizontalMove == true)
		{
			//Напрво
			Neighbours.Add(new Cell(node.G + 1, new Vector2I(
				 node.Position.X + 1, node.Position.Y),
				 node.TargetPosition,
				 node));
			//Налево
			Neighbours.Add(new Cell(node.G + 1, new Vector2I(
				 node.Position.X - 1, node.Position.Y),
				 node.TargetPosition,
				 node));
			//Вниз
			Neighbours.Add(new Cell(node.G + 1, new Vector2I(
				node.Position.X, node.Position.Y + 1),
				 node.TargetPosition,
				 node));
			//Вверх
			Neighbours.Add(new Cell(node.G + 1, new Vector2I(
				 node.Position.X, node.Position.Y - 1),
				 node.TargetPosition,
				 node));
		}

		//Диагональе передвижение
		if (GetParent<Enemy>().diagonalMove == true)
		{
			//Вверх-налево
			Neighbours.Add(new Cell(node.G + 1.4f, new Vector2I(
				 node.Position.X - 1, node.Position.Y + 1),
				 node.TargetPosition,
				 node));
			//Вверх-направо
			Neighbours.Add(new Cell(node.G + 1.4f, new Vector2I(
				 node.Position.X + 1, node.Position.Y + 1),
				 node.TargetPosition,
				 node));
			//Вниз-налево
			Neighbours.Add(new Cell(node.G + 1.4f, new Vector2I(
				 node.Position.X - 1, node.Position.Y - 1),
				 node.TargetPosition,
				 node));
			//Вниз-направо
			Neighbours.Add(new Cell(node.G + 1.4f, new Vector2I(
				 node.Position.X + 1, node.Position.Y - 1),
				 node.TargetPosition,
				 node));
		}

		return Neighbours;
	}
}
