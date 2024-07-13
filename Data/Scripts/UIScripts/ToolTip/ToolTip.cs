using Godot;
using System;

public partial class ToolTip : Control
{
	public override void _Process(double delta)
	{
		ItemPopup();
	}

	public void ItemPopup()
	{
		//if (item != null)
		//{
		//    SetValue(item);
		//    GetNode<Control>("%ItemPopup").RectSize = Vector2.Zero;
		//}

		Vector2 mousePos = GetGlobalMousePosition();
		Position = mousePos;
		Vector2I correction;


		GD.Print(mousePos.X);

		if (mousePos.X >= GetViewportRect().Size.X / 2)
		{
			Position = new Vector2((mousePos.X - Size.X), Position.Y);
		}

		if (mousePos.Y >= GetViewportRect().Size.Y / 2)
		{
			Position = new Vector2(Position.X, (mousePos.Y - Size.Y));
		}


		//GetNode<Popup>("%ItemPopup").Popup_(new Rect2I(slot.Position + correction, new Vector2I(GetNode<Control>("%ItemPopup").RectSize)));
	}

	//public void HideItemPopup()
	//{
	//    GetNode<Control>("%ItemPopup").Hide();
	//}

	//public void SetValue(Item item)
	//{
	//    GetNode<Label>("%Name").Text = item.name;
	//    GetNode<Label>("%Level").Text = item.level.ToString();
	//    GetNode<Label>("%Rarity").Text = SetTextEffect(item.rarity);
	//    GetNode<Label>("%AttributeType").Text = item.attribute_type;
	//    GetNode<Label>("%AttributeValue").Text = item.attribute_value.ToString();
	//}
}
