using System.Xml;
using System.Collections.Generic;

class TerrainBlockEditorManager : SingletonManager<TerrainBlockEditorManager>
{
    public class BlockResConfig
    {
        public int id;
        public string name;
        public string res;
        public string icon;
    }

    public List<BlockResConfig> blockList = new List<BlockResConfig>();

    public override void Init()
    {
        var path = FileService.Instance.BuildResourcePath("config\\editor\\block_type.xml");
        var content = FileService.Instance.ReadFileText(path);
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(content);
        var blocks = xmlDoc.DocumentElement.SelectNodes("block");
        var resPath = xmlDoc.DocumentElement.GetAttribute("path");
        foreach (XmlElement item in blocks)
        {
            blockList.Add(new BlockResConfig()
            {
                name = item.GetAttribute("name"),
                res = resPath + "/" + item.GetAttribute("name"),
                id = int.Parse(item.GetAttribute("id")),
            });
        }
    }

    public BlockResConfig FindBlockConfig(int id)
    {
        return blockList.Find(item => item.id == id);
    }

    public BlockConfig GenerateDefaultBlockConfig()
    {
        var item = new BlockConfig();
        item.resID = blockList[0].id;
        item.walkable = true;
        item.flyable = true;
        return item;
    }
}
