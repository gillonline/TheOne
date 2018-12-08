using UnityEngine;
using UnityEditor;

public interface IBinaryBufferSerializable
{
    void BinaryBufferSerialize(BinaryBuffer buffer);
    void BinaryBufferUnserialize(BinaryBuffer buffer);
}