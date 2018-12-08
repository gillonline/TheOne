public class SurfaceConfig
{
    public int width;
    public int height;
    public BlockConfig[] blocks;

    public SurfaceConfig(int width, int height)
    {
        this.width = width;
        this.height = height;
        blocks = new BlockConfig[width * height];
        for (int i = 0; i < width * height; i++)
        {
            blocks[i] = TerrainBlockEditorManager.Instance.GenerateDefaultBlockConfig();
        }
    }
}
