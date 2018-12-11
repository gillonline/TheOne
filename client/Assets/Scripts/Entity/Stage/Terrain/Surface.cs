using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Entity.Stage
{
    public class Surface
    {
        public string name;
        public int width;
        public int height;

        public Transform root;
        List<Block> blockList = new List<Block>();

        //     public static StageTerrain Create(int width, int height)
        //     {
        //         var gameobj = new GameObject("terrain");
        //         gameobj.transform.position = Vector3.zero;
        //         var st = new StageTerrain
        //         {
        //             width = width,
        //             height = height,
        //             blockArray = new TerrainBlock[width * height],
        //             root = gameobj.transform
        //         };
        //         st.blockArray = new TerrainBlock[width * height];
        //         for (int i = 0; i < width * height; i++)
        //         {
        //             var 
        //             st.blockArray[i] = new TerrainBlock();
        //         }
        // 
        //         return st;
        //     }

        public Surface(XmlNode node)
        {
            var ele = (XmlElement)node;
            width = ele.GetInt("width");
            height = ele.GetInt("height");

            var blockNodes = node.SelectNodes("block");
            foreach (XmlNode item in blockNodes)
            {
                blockList.Add(new Block(item));
            }
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
                    var block = blockList[i * width + j];
                    var res = ResourceManager.Instance.LoadPrefabAsync(block.ResPath);
                    if (!resList.Contains(res))
                        resList.Add(res);
                    yield return res.loadCoroutine;
                    var blockObj = res.CreateInstance<GameObject>();
                    blockObj.transform.SetParent(root);
                    blockObj.transform.position = new Vector3(j - xcenter + 0.5f, 0f, i - zcenter + 0.5f);
                    block.SetGameObject(blockObj);
                }
            }
        }
        #endregion

        public Block Find(float wx, float wz)
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
            return blockList[index];
        }
    }
}