using Godot;
using System;

public partial class AnimationController : Node
{
	// Метод для воспроизведения заданной анимации
	public void PlayAnimation(string animation)
	{
		// Получаем узел AnimationTree от родительского узла
		AnimationTree animationTree = GetParent().GetNode<AnimationTree>("AnimationTree");

		// Получаем воспроизведение состояния машины из параметров AnimationTree
		AnimationNodeStateMachinePlayback stateMachine = (AnimationNodeStateMachinePlayback)animationTree.Get("parameters/playback");

		try
		{
			// Пытаемся воспроизвести заданную анимацию
			stateMachine.Travel(animation);
		}
		catch
		{
			// Если анимация недоступна или не существует, выводим сообщение об ошибке
			GD.PrintErr($"Анимация '{animation}' недоступна или не существует для объекта: '{GetParent().Name}'!");
		}
	}
}
