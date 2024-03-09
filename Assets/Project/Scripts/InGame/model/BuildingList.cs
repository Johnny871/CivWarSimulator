using System.Collections;
using System.Collections.Generic;
using CivWar;
using UnityEngine;

namespace CivWar{
    public class BuildingList
    {
        private GameObject townhallObj;
        private List<GameObject> warehouseObjs = new List<GameObject>();

        public GameObject TownHallObj => townhallObj;
        public List<GameObject> WareHouseObjs => warehouseObjs;
        
        public void SetTownHall(GameObject townHallObj)
        {
            this.townhallObj = townHallObj;
        }

        public void AddWarehouse(GameObject warehouseObj)
        {
            warehouseObjs.Add(warehouseObj);
        }
    }
}
