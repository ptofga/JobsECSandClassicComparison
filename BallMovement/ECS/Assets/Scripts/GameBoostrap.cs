using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

namespace ECSPractise
{
    
    public class GameBoostrap
    {
        public static GameSetting gameSetting;
        public static EntityManager entityManager;

        public static Entity ballEntity;
        public static EntityArchetype ballArchetype;
        public static MeshInstanceRenderer BallLook;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void InitBeforeScene()
        {

            entityManager = World.Active.GetOrCreateManager<EntityManager>();

        }
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void InitAfterScene()
        {

            gameSetting = GameObject.Find("GameSettingObject").GetComponent<GameSetting>();

            ballArchetype = entityManager.CreateArchetype(typeof(Position), typeof(Rotation),typeof(BallData), typeof(TransformMatrix));
            ballEntity = entityManager.CreateEntity(ballArchetype);

            BallLook = GetLookFromPrototype("ballObject");


            World.Active.GetOrCreateManager<BallSpawnSystem>().SetBallNumberUI();
            World.Active.GetOrCreateManager<FPSSytem>().SetFPSUI();


        }
        public static MeshInstanceRenderer GetLookFromPrototype(string protoName)
        {
            var proto = GameObject.Find(protoName);
            if (proto == null)
                Debug.Log("do not get object");
            var result = proto.GetComponent<MeshInstanceRendererComponent>().Value;
            Object.Destroy(proto);
            return result;
        }
    }
}
