using System.Xml;

public static class XmlExtension
{
    public static int GetInt(this XmlNode node, string attrName)
    {
        return GetInt((XmlElement)node, attrName);
    }

    public static int GetInt(this XmlElement node, string attrName)
    {
        var att = node.GetAttribute(attrName);
        return int.Parse(att);
    }

    public static GFloat GetFloat(this XmlNode node, string attrName)
    {
        return GetFloat((XmlElement)node, attrName);
    }

    public static GFloat GetFloat(this XmlElement node, string attrName)
    {
        var att = node.GetAttribute(attrName);
        return GFloat.Parse(att);
    }

    public static string GetString(this XmlNode node, string attrName)
    {
        return GetString((XmlElement)node, attrName);
    }

    public static string GetString(this XmlElement node, string attrName)
    {
        return node.GetAttribute(attrName);
    }

    public static bool GetBool(this XmlNode node , string attrName)
    {
        return GetBool((XmlElement)node, attrName);
    }

    public static bool GetBool(this XmlElement node, string attrName)
    {
        var att = node.GetAttribute(attrName);
        return bool.Parse(att);
    }
}