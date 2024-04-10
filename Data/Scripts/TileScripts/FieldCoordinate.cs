using Godot;
using System;

public partial class FieldCoordinate : Node
{
	public static int xStartPoint = 17; //Стартовая координата по X
	public static int yStartPoint = 16; //Стартовая координата по Y

	public static int xFieldSize = 40; //Размер ширины игрового поля, начало отсчета с 0
	public static int yFieldSize = 30; //Размер высоты игрового поля, начало отсчета с 0

	//Максимальные координаты всех направлений игрового поля
	public static int maxTop = yStartPoint;
	public static int maxDown = yFieldSize;
	public static int maxLeft = xStartPoint;
	public static int maxRight = xFieldSize;
}
