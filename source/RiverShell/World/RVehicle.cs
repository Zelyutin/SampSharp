﻿using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;

namespace RiverShell.World
{
    public class RVehicle : Vehicle
    {
        public RVehicle(int id) : base(id)
        {
        }

        public override void OnStreamIn(PlayerVehicleEventArgs e)
        {
            var player = e.Player as RPlayer;

            if (this == GameMode.BlueTeam.Vehicle)
                e.Vehicle.SetParamsForPlayer(player, true, player.Team == GameMode.GreenTeam);
            else if (this == GameMode.GreenTeam.Vehicle)
                e.Vehicle.SetParamsForPlayer(player, true, player.Team == GameMode.BlueTeam);

            base.OnStreamIn(e);
        }
    }
}
