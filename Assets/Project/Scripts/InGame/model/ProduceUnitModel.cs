using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace CivWar{
    public class ProduceUnitModel
    {
        private float moveSpeed;
        private Transform townHall;
        public float MoveSpeed => moveSpeed;
        public Transform TownHall => townHall;

        public ProduceUnitModel(float moveSpeed, Transform townHall)
        {
            this.moveSpeed = moveSpeed;
            this.townHall = townHall;
        }

        public void Initialize()
        {

        }
    }
}
