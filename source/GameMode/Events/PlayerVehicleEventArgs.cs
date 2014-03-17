﻿namespace GameMode.Events
{
    public class PlayerVehicleEventArgs : PlayerEventArgs
    {
        public PlayerVehicleEventArgs(int playerid, int vehicleid) : base(playerid)
        {
            VehicleId = vehicleid;
        }

        public int VehicleId { get; private set; }
    }
}