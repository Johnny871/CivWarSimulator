using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CivWar.Const;
using UnityEngine.AI;
using CivWar;

namespace CivWar{
    public class ProduceUnit : MonoBehaviour
    {
        private ProduceUnitModel model;
        private NavMeshAgent agent;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float searchDistance;
        private GameObject targetObj;
        public void Initialize(TeamColor team, Transform townHall)
        {
            if(model == null)
            {
                model = new ProduceUnitModel(moveSpeed, townHall);
            }
        }

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private Transform SearchNearResource()
        {
            Transform result = null;
            var targets = GameObject.FindGameObjectsWithTag("Resource");
            if(targets.Length == 1) return targets[0].transform;
            var minTargetDistance = searchDistance;
            foreach(var target in targets)
            {
                Resource resource = target.GetComponent<Resource>();
                if (resource.DuaringWorked) continue;
                var targetDistance = Vector3.Distance(transform.position, target.transform.position);
                if (!(targetDistance < minTargetDistance)) continue;
                minTargetDistance = targetDistance;
                result = target.transform;
            }
            return result?.transform;
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }    
    }
}
