using Godot;
using System;

public partial class Edge : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        EdgeCalculation();
    }


    public void EdgeCalculation()
    {
        //Вычисляет границы карты исходя из заданных значений и записывает их в список

        for (int i = FieldCoordinate.xStartPoint; i <= FieldCoordinate.xStartPoint + FieldCoordinate.xField; i++)
        {
            TileStorage.impassableCells.Add(new Vector2I(i, FieldCoordinate.yStartPoint - 1)); //Левая граница
            TileStorage.impassableCells.Add(new Vector2I(i, FieldCoordinate.yStartPoint + FieldCoordinate.yField + 1)); //Правая граница
        }
        for (int j = FieldCoordinate.yStartPoint; j <= FieldCoordinate.yStartPoint + FieldCoordinate.yField; j++)
        {
            TileStorage.impassableCells.Add(new Vector2I(FieldCoordinate.xStartPoint - 1, j)); //Верхняя граница
            TileStorage.impassableCells.Add(new Vector2I(FieldCoordinate.xStartPoint + FieldCoordinate.xField + 1, j)); //Нижняя граница
        }
    }
}
