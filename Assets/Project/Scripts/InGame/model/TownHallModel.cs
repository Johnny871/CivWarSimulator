using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CivWar.Const;

namespace CivWar{
    public class TownHallModel
    {
        private TeamColor team;
        public TeamColor Team => team;

        public TownHallModel(TeamColor team)
        {
            this.team = team;
        }
    }
}
