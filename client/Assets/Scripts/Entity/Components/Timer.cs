using System.Collections.Generic;
using System.Xml;

namespace Entity.Components
{
    public class Timer : BasicComponent
    {
        public GFloat delay;
        public GFloat startTime;

        public List<Behavior> behaviorList;

        public Timer(XmlNode node) : base(node)
        {
            delay = node.GetFloat("delay");
        }

        public override void Update(global::Stage stage)
        {
            if (stage.now - startTime >= delay)
            {
                behaviorList.ForEach(item => item.Fire(stage));
                active = false;
            }
        }
    }
}
