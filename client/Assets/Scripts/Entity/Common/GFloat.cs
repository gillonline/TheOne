using System;

public struct GFloat
{
    public float value;
    
    public static GFloat New(string val)
    {
        var f = 0f;
        if (float.TryParse(val, out f))
            return new GFloat() { value = f };
        else
        {
            GameLog.WarningFmt("could not parse float val:{0}", val);
            return new GFloat() { value = 0f };
        }
    }

    public static GFloat operator +(GFloat l, GFloat r)
    {
        return new GFloat() { value = l.value + r.value };
    }

    public static GFloat operator -(GFloat l, GFloat r)
    {
        return new GFloat() { value = l.value - r.value };
    }

    public static GFloat operator *(GFloat l, GFloat r)
    {
        return new GFloat() { value = l.value * r.value };
    }

    public static GFloat operator /(GFloat l, GFloat r)
    {
        return new GFloat() { value = l.value / r.value };
    }

    public static implicit operator GFloat(float v)
    {
        return new GFloat() { value = v };
    }

    public static implicit operator GFloat(int v)
    {
        return new GFloat() { value = v };
    }
}