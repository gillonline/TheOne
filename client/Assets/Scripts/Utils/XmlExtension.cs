using System.Xml;

public static class XmlExtension
{
    public static int GetInt(this XmlElement node, string attrName)
    {
        var att = node.GetAttribute(attrName);
        return int.Parse(att);
    }

    public static bool GetBool(this XmlElement node, string attrName)
    {
        var att = node.GetAttribute(attrName);
        return bool.Parse(att);
    }
}