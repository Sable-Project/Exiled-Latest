// -----------------------------------------------------------------------
// <copyright file="PlayerHandlers.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.CustomRoles.Events
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.CustomRoles.API;
    using Exiled.CustomRoles.API.Features;
    using Exiled.Events.EventArgs.Player;

    /// <summary>
    /// Handles general events for players.
    /// </summary>
    public class PlayerHandlers
    {
        private static readonly HashSet<SpawnReason> ValidSpawnReasons = new()
        {
            SpawnReason.RoundStart,
            SpawnReason.Respawn,
            SpawnReason.LateJoin,
            SpawnReason.Revived,
            SpawnReason.Escaped,
            SpawnReason.ItemUsage,
        };

        private readonly CustomRoles plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerHandlers"/> class.
        /// </summary>
        /// <param name="plugin">The <see cref="CustomRoles"/> plugin instance.</param>
        public PlayerHandlers(CustomRoles plugin)
        {
            this.plugin = plugin;
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.WaitingForPlayers"/>
        internal void OnWaitingForPlayers()
        {
            Extensions.InternalPlayerToCustomRoles.Clear();
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.SpawningRagdoll"/>
        internal void OnSpawningRagdoll(SpawningRagdollEventArgs ev)
        {
            if (plugin.StopRagdollPlayers.Contains(ev.Player))
            {
                ev.IsAllowed = false;
                plugin.StopRagdollPlayers.Remove(ev.Player);
            }
        }
    }
}
