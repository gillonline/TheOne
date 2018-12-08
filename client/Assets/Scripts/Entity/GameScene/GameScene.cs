abstract class GameScene
{
    public string name;

    public virtual void OnEnter(params object[] args)
    {

    }

    public virtual void OnLeave() { }

    public void Update()
    {
        OnUpdate();
    }

    public virtual void OnUpdate()
    {

    }

    public void RenderUpdate()
    {
        OnRenderUpdate();
    }

    public virtual void OnRenderUpdate()
    {

    }
}