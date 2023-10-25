using Godot;
using System;
using System.Linq.Expressions;

public partial class AnimationController : Node
{
    AnimationTree animationTree;
    AnimationNodeStateMachinePlayback stateMachine;

    private void Set()
    {
        animationTree = GetParent().GetNode<AnimationTree>("AnimationTree");
        stateMachine = (AnimationNodeStateMachinePlayback)animationTree.Get("parameters/playback");
    }

    public void SetAnimation(string animation)
    {
        Set();

        try
        {
            stateMachine.Travel(animation);
        }       
        catch
        {
            GD.PrintErr($"Анимация '{animation}' не доступна или несуществует для объекта: '{GetParent().Name}'!");
        }
    }

   
}
