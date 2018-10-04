
public class StageConfig : IBinaryBufferSerializable
{
    public string name;
    public int width;
    public int height;
    public string desc;

    public StageTerrain terrain;

    public StageConfig(string name, int width, int height)
    {
        this.name = name;
        this.width = width;
        this.height = height;
    }

    public StageConfig(BinaryBuffer buffer)
    {
        BinaryBufferUnserialize(buffer);
    }

    public void BinaryBufferSerialize(BinaryBuffer buffer)
    {

    }

    public void BinaryBufferUnserialize(BinaryBuffer buffer)
    {

    }
}
