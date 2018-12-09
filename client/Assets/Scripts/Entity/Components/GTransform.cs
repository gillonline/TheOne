using System.Collections.Generic;

public class GTransform : BasicComponent
{
    public GVector3 position;

    //上层节点;
    public GTransform parent;
    //子节点, 层级概念;
    public List<GTransform> childList = new List<GTransform>();
}
