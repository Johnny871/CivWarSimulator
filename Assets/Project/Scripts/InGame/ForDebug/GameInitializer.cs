using System;
using System.Collections.Generic;
using System.Linq;
using CivWar.Const;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CivWar{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private List<GameObject> resourcePref = new List<GameObject>();
        [SerializeField] private int spawnCount;
        [SerializeField] private float
        resourceDistance,
        surroundTownHallDistance,
        townHallDistance;
        private List<Vector3> objectPositionList = new List<Vector3>();
        private List<Vector3> townHallPositionList = new List<Vector3>();
        private int spawnTryCount;
        private const int SPAWN_TRY_LIMIT = 10000;
        [SerializeField] GameObject townHallPref;
        [SerializeField, Range(1, 4)] private int townHallCount;

        private void Awake()
        {
            InstantiateTownHalls(townHallCount);
            Debug.LogFormat("生成に成功したタウンホールの数 : {0}", townHallPositionList.Count);
            InstantiateResourceObjects(spawnCount);
            Debug.LogFormat("生成に成功したオブジェクトの数 : {0}個", objectPositionList.Count);
        }
        
        private void InstantiateTownHalls(int townHallCount)
        {
            while(townHallCount > 0)
            {
                if(spawnTryCount >= SPAWN_TRY_LIMIT) break;
                spawnTryCount++;
                var targetPos = new Vector3(Random.Range(5, 295), 0 , Random.Range(5, 295));
                if(townHallPositionList.Where(pos => Vector3.Distance(targetPos, pos) < townHallDistance).Any())
                {
                    continue;
                }
                var townHallObj = Instantiate(townHallPref, targetPos, transform.rotation);
                townHallObj.GetComponent<TownHall>().Initialize((TeamColor)Enum.ToObject(typeof(TeamColor), townHallCount));
                townHallPositionList.Add(targetPos);
                townHallCount--;
            }
        }

        private void InstantiateResourceObjects(int spawnCount)
        {
            for(int i = 0; i < spawnCount; i++)
            {
                if(spawnTryCount >= SPAWN_TRY_LIMIT) break;
                spawnTryCount++;
                var targetPos = new Vector3(Random.Range(1, 299), 0 , Random.Range(1, 299));
                if(objectPositionList.Where(pos => Vector3.Distance(targetPos, pos) < resourceDistance).Any() || townHallPositionList.Where(pos => Vector3.Distance(targetPos, pos) < surroundTownHallDistance).Any())
                {
                    i--;
                    continue;
                }
                Instantiate(resourcePref[Random.Range(0,resourcePref.Count)], targetPos, transform.rotation);
                objectPositionList.Add(targetPos);
            }
        }
    }
}
