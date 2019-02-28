using System.Xml;

namespace Entity.Components
{
    public class Behavior : BasicComponent
    {
        public Behavior(XmlNode node) : base(node)
        {
            var type = node.GetString("type");
        }

        public void Fire(global::Stage st)
        {

        }
    }
}
