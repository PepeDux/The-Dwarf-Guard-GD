using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class PathMaker : Node
{
	List<Button> NextPoints;
	Button StartPoint;

	[Export] PackedScene scene;
	float offsetDistance = 30.0f; // Расстояние смещения линии от центра

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Получаем узел "NextPoints" и выбираем все его дочерние элементы типа Button
		Node nextPointsNode = GetParent().GetNode("NextPoints");
		NextPoints = nextPointsNode.GetChildren().OfType<Button>().ToList();

		// Получаем первую кнопку из родительского узла "StartPoint"
		StartPoint = GetParent().GetNode("StartPoint").GetChildren().OfType<Button>().FirstOrDefault();

		if (StartPoint != null)
		{
			// Получаем центр начальной кнопки
			Vector2 startPointCenter = StartPoint.Position + (StartPoint.Size / 2);

			foreach (var point in NextPoints)
			{
				// Получаем центр каждой следующей кнопки
				Vector2 pointCenter = point.Position + (point.Size / 2);

				// Вычисляем вектор направления от первой кнопки ко второй
				Vector2 direction = (pointCenter - startPointCenter).Normalized();

				// Смещаем точки начала и конца линии на определенное расстояние
				Vector2 adjustedStartPoint = startPointCenter + direction * offsetDistance;
				Vector2 adjustedEndPoint = pointCenter - direction * offsetDistance;

				// Инстанциируем сцену и добавляем объект на сцену
				Line2D line = (Line2D)scene.Instantiate();
				line.AddPoint(adjustedStartPoint);
				line.AddPoint(adjustedEndPoint);

				// Используем CallDeferred для добавления объекта на сцену позже
				GetParent().CallDeferred("add_child", line);
			}
		}
	}
}
