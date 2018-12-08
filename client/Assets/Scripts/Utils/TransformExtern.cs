using UnityEngine;

static class TransformExtern
{
    public static Transform Clone(this Transform tra)
    {
        var clone = GameObject.Instantiate(tra.gameObject).transform;
        if (tra.parent != null)
        {
            clone.SetParent(tra.parent);
            clone.localPosition = Vector3.zero;
            clone.localRotation = Quaternion.identity;
            clone.localScale = Vector3.one;
        }

        return clone;
    }

    public static T Find<T>(this Transform tra, string path) where T : Component
    {
        var node = tra.Find(path);
        if (node != null)
        {
            return node.GetComponent<T>();
        }
        else
            return null;
    }

    public static T Find<T>(this Transform tra) where T : Component
    {
        return tra.GetComponent<T>();
    }
}
