
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public struct CountData :IComponentData
{
    public int count;
}
[System.Serializable]
public struct RangeData:ISharedComponentData
{
    public int min, max;
}
public struct BallData: IComponentData
{
    public Position pos;
    public TransformMatrix tm;
}