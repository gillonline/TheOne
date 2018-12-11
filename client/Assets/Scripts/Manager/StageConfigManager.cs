using System.Collections.Generic;
using System.Xml;

public class StageConfigManager : SingletonManager<StageConfigManager>
{
    public List<StageConfig> stageList = new List<StageConfig>();

    public override void Init()
    {
        var allStageFiles = FileService.Instance.GetAllFiles("config/stage");
        if (allStageFiles != null)
        {
            foreach (var filePath in allStageFiles)
            {
                var bytes = FileService.Instance.ReadFileBytes(filePath);
                if (bytes != null)
                {
                    var stage = new StageConfig(new BinaryBuffer(bytes));
                    stageList.Add(stage);
                }
            }
        }
    }
}
