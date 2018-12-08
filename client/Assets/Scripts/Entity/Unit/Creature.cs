using System.Collections.Generic;

public class Creature : ActorObject
{
    public CreatureType creature;

    //生物的特性是由组件来确定的;
    public List<BasicComponent> componentList;

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
