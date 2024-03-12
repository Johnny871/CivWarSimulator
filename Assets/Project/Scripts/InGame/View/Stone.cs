using UnityEngine;

namespace CivWar{
    public class Stone : Resource
    {
        [SerializeField] private ResourcePacket initResourcePacket;

        private void Awake()
        {
            base.Initialize(initResourcePacket);
        }
    }
}