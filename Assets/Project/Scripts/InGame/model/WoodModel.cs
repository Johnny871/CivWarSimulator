using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CivWar{
    public class WoodModel
    {
        private int resourceAmount;
        public int ResourceAmount => resourceAmount;
        
        public WoodModel(int resourceAmount)
        {
            this.resourceAmount = resourceAmount;
        }
    }
}
