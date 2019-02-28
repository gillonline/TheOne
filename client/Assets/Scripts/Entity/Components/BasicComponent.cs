using System.Xml;

public class BasicComponent : BasicObject
{
    public BasicObject host;

    public BasicComponent(XmlNode node) : base (node)
    {

    }
}
