using Godot;
using System;

public partial class FieldCoordinate : Node
{
    public static int xStartPoint = 20; //Стартовая координата по X
    public static int yStartPoint = 20; //Стартовая координата по Y

    public static int xField = 8; //Размер ширины игрового поля, начало отсчета с 0
    public static int yField = 8; //Размер высоты игрового поля, начало отсчета с 0

    //Максимальные координаты всех направлений игрового поля
    public static int maxTop = yStartPoint;
    public static int maxDown = yField;
    public static int maxLeft = xStartPoint;
    public static int maxRight = xField;
}
