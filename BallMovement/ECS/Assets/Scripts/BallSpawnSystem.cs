 
using ECSPractise;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawnSystem : ComponentSystem
{
    int BallNumber = 0;
    Text BallNumberText;
    public void SetBallNumberUI()
    {
        BallNumberText = GameObject.Find("BallNumber").GetComponent<Text>();
    }

    protected override void OnUpdate()
    {
        BallNumber++;
        if(BallNumber<GameBoostrap.gameSetting.BallNumber)
        {   
            Spawnball();
            BallNumberText.text = "Ball Number is " + (BallNumber+1);
        }
    }
    void Spawnball()
    {
        PostUpdateCommands.CreateEntity(GameBoostrap.ballArchetype);
        PostUpdateCommands.SetComponent(GetRandomPostion());
        PostUpdateCommands.AddSharedComponent(GameBoostrap.BallLook);
    }
    Position GetRandomPostion()
    {
        Position pos;
        float x = GameBoostrap.gameSetting.BallBound* (Random.value-0.5f);
        float z= GameBoostrap.gameSetting.BallBound * (Random.value - 0.5f);
        pos = new Position { Value=new Unity.Mathematics.float3(x,0,z)};
        return pos;
    }
    
}
