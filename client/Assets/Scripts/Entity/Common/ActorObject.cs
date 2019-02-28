using System.Xml;

public class ActorObject : BasicObject
{
    public GTransform transform;

    public ActorObject(XmlNode node) : base(node)
    {
        //transform = node.
    }
}
