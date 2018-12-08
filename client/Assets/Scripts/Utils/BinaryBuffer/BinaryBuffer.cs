//连续字节数组的简单序列化器;


public class BinaryBuffer
{
    public byte[] buffer;

    public uint writeCursor = 0;
    public uint readCursor = 0;

    public BinaryBuffer(int size)
    {
        buffer = new byte[size];
    }

    public BinaryBuffer(byte[] bytes)
    {
        buffer = bytes;
    }

    public void WriteByte(byte content)
    {
        buffer[writeCursor] = content;
        writeCursor++;
    }

    public byte ReadByte()
    {
        return buffer[readCursor++];
    }

    public void WriteBool(bool b)
    {
        buffer[writeCursor] = b ? (byte)0x1 : (byte)0x0;
        writeCursor++;
    }

    public bool ReadBool()
    {
        var ret = buffer[readCursor];
        readCursor++;
        return ret == 0x1;
    }

    public void WriteInt(int num)
    {
        buffer[writeCursor] = (byte)(num >> 24);
        buffer[writeCursor + 1] = (byte)(num >> 16);
        buffer[writeCursor + 2] = (byte)(num >> 8);
        buffer[writeCursor + 3] = (byte)num;
        writeCursor += 4;
    }

    public int ReadInt()
    {
        var index = readCursor;
        readCursor += 4;
        return buffer[index] << 24 | buffer[index + 1] << 16 | buffer[index + 2] << 8 | buffer[index + 3];
    }

    public void WriteString(string txt)
    {
        var bts = System.Text.Encoding.UTF8.GetBytes(txt);
        var len = bts.Length;
        if (len > 256)
            len = 256;
        buffer[writeCursor] = (byte)len;
        System.Array.Copy(bts, 0, buffer, writeCursor + 1, len);
        writeCursor += (uint)len + 1;
    }

    public string ReadString()
    {
        var len = (uint)buffer[readCursor];
        var bts = new byte[len];
        System.Array.Copy(buffer, readCursor + 1, bts, 0, len);
        readCursor += len + 1;
        return System.Text.Encoding.UTF8.GetString(bts);
    }

    public void Write<T>(T content) where T : IBinaryBufferSerializable
    {
        content.BinaryBufferSerialize(this);
    }

    public T Read<T>() where T : IBinaryBufferSerializable, new()
    {
        var con = new T();
        con.BinaryBufferUnserialize(this);
        return con;
    }

    public void WriteArray<T>(T[] arr) where T : IBinaryBufferSerializable
    {
        var len = arr.Length;
        WriteInt(len);
        for (int i = 0; i < len; i++)
        {
            arr[i].BinaryBufferSerialize(this);
        }
    }

    public T[] ReadArray<T>() where T : IBinaryBufferSerializable, new()
    {
        var len = ReadInt();
        var arr = new T[len];
        for (int i = 0; i < len; i++)
        {
            arr[i] = Read<T>();
        }

        return arr;
    }
}