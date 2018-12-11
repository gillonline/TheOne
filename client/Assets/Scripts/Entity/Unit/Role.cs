using System.Collections.Generic;
using System.Xml;

public class Role : Creature
{
    public GFloat hp;
    public GFloat mp;

    public GFloat damage;

    public Role(XmlNode node) :
    base(node)
    {

    }
}
