/// <summary>
/// 最基本的对象单元;
/// </summary>
using System.Xml;

public class BasicObject
{
    public string name;
    public int uuid;
    public bool active = false; //是否激活;

    public BasicObject(XmlNode node)
    {
        name = node.GetString("name");
        uuid = node.GetInt("uuid");
        active = node.GetBool("active");
    }

    public virtual void Update(Stage stage)
    {
        OnUpdate(stage);
    }

    public virtual void OnUpdate(Stage stage)
    {

    }
}