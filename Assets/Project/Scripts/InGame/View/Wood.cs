using UnityEngine;

namespace CivWar{
    public class Wood : Resource
    {
        [SerializeField] private ResourcePacket initResourcePacket;

        private void Awake()
        {
            base.Initialize(initResourcePacket);
        }
    }
}