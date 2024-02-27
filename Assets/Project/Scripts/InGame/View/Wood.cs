using System.Collections;
using System.Collections.Generic;
using CivWar;
using UnityEngine;

namespace CivWar{
    public class Wood : Resource
    {
        private WoodModel model;

        public void Initialize(int resourceAmount)
        {
            this.resourceAmount = resourceAmount;
        }
    }
}
