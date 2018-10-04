using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StageManager : SingletonManager<StageManager>
{
    public List<StageConfig> stageList = new List<StageConfig>();

    public override void Init()
    {
        var allStageFiles = FileService.Instance.GetAllFiles("config\\stage");
        if (allStageFiles != null)
        {
            foreach (var filePath in allStageFiles)
            {
                var bytes = FileService.Instance.ReadFile(filePath);
                if (bytes != null)
                {
                    var stage = new StageConfig(new BinaryBuffer(bytes));
                    stageList.Add(stage);
                }
            }
        }
    }
}
