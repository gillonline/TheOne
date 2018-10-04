using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTerrain
{
    public string name;
    public int width;
    public int height;

    public Transform root;
    TerrainBlock[] blockArray;

    public static StageTerrain Create(int width, int height)
    {
        var gameobj = new GameObject("terrain");
        gameobj.transform.position = Vector3.zero;
        var st = new StageTerrain
        {
            width = width,
            height = height,
            blockArray = new TerrainBlock[width * height],
            root = gameobj.transform
        };
        for (int i = 0; i < width * height; i++)
        {
            st.blockArray[i] = new TerrainBlock();
        }

        return st;
    }

    #region 资源
    private List<ResourceInstance> resList = new List<ResourceInstance>();
    public void Load()
    {
        CoroutineHelper.Instance.Begin(StartLoad);
    }

    /// <summary>
    /// 从左下角开始向上加载;
    /// </summary>
    /// <returns></returns>
    IEnumerator StartLoad()
    {
        var xcenter = width / 2f;
        var zcenter = height / 2f;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //var block = blockArray[i * j];
                var res = ResourceManager.Instance.LoadPrefabAsync("stage/cell");
                if (!resList.Contains(res))
                    resList.Add(res);
                yield return res.loadCoroutine;
                var blockObj = res.CreateInstance<GameObject>();
                blockObj.transform.SetParent(root);
                blockObj.transform.position = new Vector3(j - xcenter + 0.5f, 0f, i - zcenter + 0.5f);
                //Debug.LogFormat("create:{0}", Time.frameCount);
                blockArray[i * width + j].SetGameObject(blockObj);
            }
        }
    }
    #endregion

    public TerrainBlock Find(float wx, float wz)
    {
        var xcenter = width / 2f;
        var zcenter = height / 2f;
        var xoffset = (int)Mathf.Abs(Mathf.Ceil(wx + xcenter)) - 1;
        var yoffset = (int)Mathf.Abs(Mathf.Ceil(wz + zcenter)) - 1;

        if (yoffset < 0) yoffset = 0;
        if (yoffset >= height) yoffset = height - 1;
        if (xoffset < 0) xoffset = 0;
        if (xoffset >= width) xoffset = width - 1;

        var index = xoffset + yoffset * width;
        return blockArray[index];
    }
}