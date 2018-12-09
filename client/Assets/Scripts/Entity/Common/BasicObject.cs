/// <summary>
/// 最基本的对象单元;
/// </summary>

public class BasicObject
{
    public string name;
    public int uuid;
    public bool active = false; //是否激活;

    public virtual void Update(Stage stage)
    {
        OnUpdate(stage);
    }

    public virtual void OnUpdate(Stage stage)
    {

    }
}