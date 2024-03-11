using UnityEngine;

namespace CivWar{
    public class Wheat : Resource
    {
        [SerializeField] private ResourcePacket initResourcePacket;

        private void Awake()
        {
            base.Initialize(initResourcePacket);
        }
    }
}