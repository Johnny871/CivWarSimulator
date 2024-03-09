using System.Collections;
using System.Collections.Generic;
using CivWar;
using UnityEngine;

namespace CivWar{
    public class ResourceObjectsList{
        private List<GameObject> resourceObjs = new List<GameObject>();
        public List<GameObject> ResourceObjs => resourceObjs;

        public void Add(GameObject targetResourceObj)
        {
            var isResource = targetResourceObj.TryGetComponent(out Resource resource);
            if(!isResource) return;
            resourceObjs.Add(targetResourceObj);
        }
    }
}
