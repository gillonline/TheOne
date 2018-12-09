using System.Collections.Generic;

/// <summary>
/// 技能是组件之一;
/// </summary>
public class Skill : BasicComponent
{
    public SkillState state = SkillState.Ready;
    public GFloat cooldown = 0;

    public List<SkillSequence> sequenceList;

    public Skill()
    {

    }

    public override void Update(Stage stage)
    {
        foreach (var item in sequenceList)
        {
            item.Update(stage);
        }
    }
}
