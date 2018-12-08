using System.Collections.Generic;

public class Skill : BasicObject
{
    public List<SkillSequence> sequenceList;

    public override void OnUpdate(Stage stage)
    {
        foreach (var item in sequenceList)
        {
            item.Update(stage);
        }
    }
}
