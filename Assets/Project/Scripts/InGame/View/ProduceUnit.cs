using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CivWar.Const;
using UnityEngine.AI;
using UniRx;

namespace CivWar{
    public class ProduceUnit : Unit
    {
        private NavMeshAgent agent;
        private ReactiveProperty<ProduceUnitState> state = new ReactiveProperty<ProduceUnitState>(ProduceUnitState.DoNothing);
        [SerializeField] private int initHealthPoint;
        [SerializeField] private float searchDistance;
        private GameObject targetObj;
        private Resource targetResource;
        private ResourceType currentCarryingResourceType = new ResourceType();
        private int currentCarryingResourceAmount;
        private TownHall townHall;
        private TeamColor teamColor;
        private bool isMove = false;

        public void Initialize(TownHall townHall, TeamColor teamColor)
        {
            base.Initialize(UnitType.Producer, initHealthPoint);
            this.townHall = townHall;
            this.teamColor = teamColor;
            var color = ConstFormatter.GetColor(teamColor);
            if(color != Color.white)
            {
                var render = GetComponent<Renderer>();
                render.material.color = color;
            }
            agent = GetComponent<NavMeshAgent>();
            state
            .Subscribe(state =>
            {
                CheckState(state);
            })
            .AddTo(this);
        }

        private void CheckState(ProduceUnitState state)
        {
            switch(state)
            {
                case ProduceUnitState.DoNothing:
                StartCoroutine(WaitRandomSecond(1.0f, 3.0f));
                    break;
                case ProduceUnitState.Searching:
                    if(SearchNearResource() == null)
                    {
                        state = ProduceUnitState.DoNothing;
                        break;
                    }
                    targetObj = SearchNearResource().gameObject;
                    targetResource = targetObj.GetComponent<Resource>();
                    targetResource.SetIsWorked(true);
                    agent.SetDestination(targetObj.transform.position);
                    isMove = true;
                    break;
                case ProduceUnitState.Gathering:
                    agent.Stop(true);
                    StartCoroutine(GatherResource(targetResource, townHall.p_produceUnitCommonStates.OnceExtractionCapacity));
                    break;
                case ProduceUnitState.Carrying:
                    targetResource.SetIsWorked(false);
                    targetObj = SearchNearWarehouse().gameObject;
                    agent.SetDestination(targetObj.transform.position);
                    agent.Resume();
                    isMove = true;
                    break;
            }
        }

        //近隣資源探索関数[Transform型]
        //第一引数：探索資源種類の指定[ResourceType型(Constのenum)]引数指定なしで全種類探索
        private Transform SearchNearResource(ResourceType targetResourceType = ResourceType.None)
        {
            Transform result = null;
            var targets = GameObject.FindGameObjectsWithTag("Resource");
            if(targets.Length == 0) return null;
            if(targets.Length == 1) return targets[0].transform;
            var minTargetDistance = searchDistance;
            foreach(var target in targets)
            {
                Resource resource = target.GetComponent<Resource>();
                if(resource.DuaringWorked) continue;
                if(targetResourceType != ResourceType.None && resource.p_ResourceType != targetResourceType) continue;
                var targetDistance = Vector3.Distance(transform.position, target.transform.position);
                if(!(targetDistance < minTargetDistance)) continue;
                minTargetDistance = targetDistance;
                result = target.transform;
            }
            return result.transform;
        }
        //近隣倉庫探索関数[Transform型]
        private Transform SearchNearWarehouse()
        {
            Transform result = null;
            var targets = GameObject.FindGameObjectsWithTag("Warehouse");
            if(targets.Length == 1) return targets[0].transform;
            var minTargetDistance = searchDistance;
            foreach(var target in targets)
            {
                if(target.GetComponent<Warehouse>().p_teamColor != teamColor) continue;
                var targetDistance = Vector3.Distance(transform.position, target.transform.position);
                if(!(targetDistance < minTargetDistance)) continue;
                minTargetDistance = targetDistance;
                result = target.transform;
            }
            return result?.transform;
        }
        
        //資源採集関数[コルーチン]
        //第一引数：採集対象オブジェクト[Resource型(資源オブジェクトのスーパークラス)]
        //第二引数：要求資源量[int型]
        private IEnumerator GatherResource(Resource targetResource, int requireAmount)
        {
            //ユニットの資源所持上限に達していない&
            //ターゲット内に資源が残っている&
            //ターゲットが存在している間繰り返す
            while
            (
                currentCarryingResourceAmount < townHall.p_produceUnitCommonStates.CarryingResourceCapacity &&
                targetResource.ResourceAmount > 0 &&
                targetObj != null
            )
            {
                yield return new WaitForSeconds(townHall.p_produceUnitCommonStates.GatheringInterval);
                if(requireAmount > targetResource.ResourceAmount) requireAmount = targetResource.ResourceAmount;
                targetResource.Remove(requireAmount);
                currentCarryingResourceAmount += requireAmount;
                currentCarryingResourceType = targetResource.p_ResourceType;
            }
            state.Value = ProduceUnitState.Carrying;
        }

        //所持資源収納関数[void型]
        private void StorageResource(Warehouse warehouse)
        {
            warehouse.AddResource(currentCarryingResourceType, currentCarryingResourceAmount);
            currentCarryingResourceAmount = 0;
            currentCarryingResourceType = ResourceType.None;
        }

        private IEnumerator WaitRandomSecond(float minSec, float maxSec)
        {
            yield return new WaitForSeconds(Random.Range(minSec, maxSec));
            state.Value = ProduceUnitState.Searching;
        }

        public override void Destroy()
        {
            if(state.Value == ProduceUnitState.Gathering || state.Value == ProduceUnitState.Searching)
            {
                targetResource.SetIsWorked(false);
            }
            Destroy(this.gameObject);
        }

        //接触判定
        //[資源]タグor[倉庫]タグの判別
        private void OnTriggerEnter(Collider col)
        { 
            if(col.gameObject != targetObj || !isMove) return;
            isMove = false;
            if(col.gameObject.tag == "Resource")
            {
                state.Value = ProduceUnitState.Gathering;
            }
            else if(col.gameObject.tag == "Warehouse")
            {
                StorageResource(col.GetComponent<Warehouse>());
                state.Value = ProduceUnitState.Searching;
            }
        }
    }
}
