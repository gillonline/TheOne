using UnityEngine;

abstract class GameScene
{
    public string name;

    public virtual void OnEnter(params object[] args)
    {

    }

    public virtual void OnLeave() { }
}