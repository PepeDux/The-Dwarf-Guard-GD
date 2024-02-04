using Godot;
using System;
using System.Linq.Expressions;

public partial class AnimationController : Node
{
	AnimationTree animationTree;
	AnimationNodeStateMachinePlayback stateMachine;

	public void SetAnimation(string animation)
	{
		animationTree = GetParent().GetNode<AnimationTree>("AnimationTree");
		stateMachine = (AnimationNodeStateMachinePlayback)animationTree.Get("parameters/playback");

		try
		{
			stateMachine.Travel(animation);
		}       
		catch
		{
			GD.PrintErr($"Анимация '{animation}' нет доступна или несуществует для объекта: '{GetParent().Name}'!");
		}
	}
}
