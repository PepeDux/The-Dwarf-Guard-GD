using Godot;
using System;
using System.Linq;
using System.Threading.Tasks;

public partial class ToolTip : Control
{
	// Путь к сцене тултипа
	private const string scenePath = "res://Data/Scenes/UI/ToolTip/ToolTip.tscn";

	// Экземпляр тултипа
	private static ToolTip instance;

	// Элементы интерфейса
	private RichTextLabel richLabelTittle;
	private RichTextLabel richLabelText;

	// Таймер для задержки показа тултипа
	private static Timer tooltipTimer;
	private const float tooltipDelay = 2.0f; // Задержка в секундах

	// Метод, вызываемый при готовности объекта
	public override void _Ready()
	{
		// Инициализация экземпляра
		instance = this;

		// Получение ссылок на элементы интерфейса
		richLabelTittle = GetNode<RichTextLabel>("%LabelTittle");
		richLabelText = GetNode<RichTextLabel>("%LabelText");
	}

	// Метод для показа тултипа
	public static void ShowToolTip(Node node, string tittle, string text)
	{
		// Если экземпляра тултипа нет, создаем его
		if (instance == null)
		{
			// Загрузка сцены тултипа
			PackedScene uiElementScene = (PackedScene)ResourceLoader.Load(scenePath);

			// Инстанциируем сцену и создаем объект тултипа
			instance = (ToolTip)uiElementScene.Instantiate();

			// Добавляем тултип в дерево сцены
			node.GetTree().Root.GetChildren().FirstOrDefault().AddChild(instance);

			// Устанавливаем текст тултипа
			instance.richLabelTittle.Text = "[center]" + tittle;
			instance.richLabelText.Text = "[center]" + text;

			// Запускаем таймер
			instance.GetNode<Timer>("Timer").Stop();
			instance.GetNode<Timer>("Timer").Start();
		}
	}

	// Метод для скрытия тултипа
	public static void HideToolTip()
	{
		// Если экземпляр тултипа существует
		if (instance != null)
		{
			// Останавливаем таймер и скрываем тултип
			instance.GetNode<Timer>("Timer").Stop();
			instance.Visible = false;

			// Удаляем тултип и освобождаем память
			instance.QueueFree();
			instance = null;
		}
	}

	// Метод для обновления позиции тултипа относительно мыши
	private void UpdateToolTipPosition()
	{
		Vector2 mousePosition = GetGlobalMousePosition();
		Position = mousePosition;

		// Корректируем положение тултипа по горизонтали
		if (mousePosition.X >= GetViewportRect().Size.X / 2)
		{
			Position = new Vector2((mousePosition.X - Size.X), Position.Y);
		}

		// Корректируем положение тултипа по вертикали
		if (mousePosition.Y >= GetViewportRect().Size.Y / 2)
		{
			Position = new Vector2(Position.X, (mousePosition.Y - Size.Y));
		}
	}

	// Метод, вызываемый по таймеру для показа тултипа
	private void _on_timer_timeout()
	{
		// Обновляем позицию и делаем тултип видимым
		instance.UpdateToolTipPosition();
		instance.Visible = true;
	}
}
