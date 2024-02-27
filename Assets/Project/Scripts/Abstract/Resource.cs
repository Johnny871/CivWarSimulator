using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CivWar{
    public abstract class Resource : MonoBehaviour
    {
        protected int resourceAmount;
        public int ResourceAmount => resourceAmount;
        protected int maxAmount;
        protected bool duaringWorked = false;
        public bool DuaringWorked => duaringWorked;

        protected void SetIsWorked(bool duaringWorked)
        {
            this.duaringWorked = duaringWorked;
        }

        protected void BecomeEmpty()
        {
            Destroy(this.gameObject);
        }

        public bool Add(int requireAmount)
        {
            if(resourceAmount + requireAmount > maxAmount) return false;
            resourceAmount += requireAmount;
            return true;
        }

        public bool Remove(int requireAmount)
        {
            if (resourceAmount < requireAmount) return false;
            resourceAmount -= requireAmount;
            return true;
        }
    }
}
