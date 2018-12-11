using System.Collections.Generic;
using System.Xml;
using Entity.Stage;

public class Stage
{
    public Surface terrain;

    public Director director; //导演类, 控制关卡呈现;
    public StateMachine stateMachine;  //状态机, 关卡也有状态;
    public ProcedureMgr procedureMgr;  //序列, 每个单位都有需要播放的序列;
    public TimeMgr timeMgr;            //定时器, 延时的方法;
    public List<Trigger> triggerList;  //触发器, 等待fire;

    //动态对象;
    public GFloat startTime;
    public GFloat stageTime;
    public int frameIndex; //从0开始;
    public List<Creature> creatureList;

    public Stage(XmlNode node)
    {
        terrain = new Surface(node.SelectSingleNode("terrain"));
    }

    public void Load()
    {
        terrain.Load();
    }

    public void Update()
    {
        director.Update(this);
        stateMachine.Update(this);
        procedureMgr.Update(this);
        timeMgr.Update(this);
        foreach (var item in triggerList)
        {
            item.Update(this);
        }

        if (creatureList != null && creatureList.Count > 0)
        {
            foreach (var item in creatureList)
            {
                item.Update(this);
            }
        }
    }

    public void RenderUpdate()
    {

    }
}
