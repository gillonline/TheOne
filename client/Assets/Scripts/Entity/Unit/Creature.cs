using System.Collections.Generic;
using System.Xml;

public class Creature : ActorObject
{
    public CreatureType creature;

    //生物的特性是由组件来确定的;
    public List<BasicComponent> componentList;

    public Creature(XmlNode node) : base(node)
    {
        
    }

    public override void OnUpdate(Stage stage)
    {
        if (componentList != null && componentList.Count > 0)
        {
            foreach (var item in componentList)
            {
                item.Update(stage);
            }
        }
    }
}
