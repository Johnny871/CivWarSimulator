using UnityEngine;

namespace CivWar{
    [System.Serializable]
    public class Stone : Resource
    {
        [SerializeField] private ResourcePacket initResourcePacket;

        private void Awake()
        {
            base.Initialize(initResourcePacket);
        }
    }
}