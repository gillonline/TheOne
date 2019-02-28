using System.Collections.Generic;
using System.Xml;
using Entity.Stage;

public class Stage
{
    public Surface terrain;

    //     public Director director; //导演类, 控制关卡呈现;
    //     public StateMachine stateMachine;  //状态机, 关卡也有状态;
    //     public ProcedureMgr procedureMgr;  //序列, 每个单位都有需要播放的序列;
    //     public TimeMgr timeMgr;            //定时器, 延时的方法;
    public List<Trigger> triggerList = new List<Trigger>();  //触发器, 等待fire;

    //动态对象;

    //     public int frameIndex; //从0开始;
    //public List<Creature> creatureList = new List<Creature>();
    public GFloat now; //关卡当前时间;

    public Stage(XmlNode node)
    {
        terrain = new Surface(node.SelectSingleNode("terrain"));
        foreach (XmlNode item in node.SelectNodes("triggers/trigger"))
        {
            triggerList.Add(new Trigger(item));
        }
    }

    public void Load()
    {
        terrain.Load();
    }

    public void Update()
    {
        triggerList.ForEach(item => item.Update(this));
    }

    public void RenderUpdate()
    {

    }
}
