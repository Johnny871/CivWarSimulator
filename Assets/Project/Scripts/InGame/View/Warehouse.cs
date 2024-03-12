using UnityEngine;
using CivWar.Const;

namespace CivWar{
    public class Warehouse : MonoBehaviour
    {
        private TownHall townHall;
        private TeamColor teamColor;
        public TeamColor p_teamColor => teamColor;
        public void Initialize(TownHall townHall, TeamColor teamColor)
        {
            this.townHall = townHall;
            this.teamColor = teamColor;
        }

        public void AddResource(ResourcePacket resourcePacket)
        {
            townHall.AddResource(resourcePacket);
        }
    }
}
