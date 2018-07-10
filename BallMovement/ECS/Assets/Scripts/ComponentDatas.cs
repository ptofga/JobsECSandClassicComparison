
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


public struct BallData: IComponentData
{
    public Position pos;
    public TransformMatrix tm;
}