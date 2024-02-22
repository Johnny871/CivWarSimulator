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
            if(model == null)
            {
                model = new WoodModel(resourceAmount);
            }
        }

        public void GiveResource()
        {
            
        }

        public void SetIsWorked(bool duaringWorked)
        {
            this.duaringWorked = duaringWorked;
        }

        private void BecomeEmpty()
        {
            Destroy(this.gameObject);
        }
    }
}
