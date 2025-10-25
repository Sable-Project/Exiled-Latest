// -----------------------------------------------------------------------
// <copyright file="DamagingDoorEventArgs.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.Player
{
    using Exiled.API.Features;
    using Exiled.API.Features.Doors;
    using Footprinting;
    using Interactables.Interobjects.DoorUtils;
    using Interfaces;

    /// <summary>
    /// Contains all information before damage is dealt to a <see cref="DoorVariant" />.
    /// </summary>
    public class DamagingDoorEventArgs : IDeniableEvent, IPlayerEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DamagingDoorEventArgs" /> class.
        /// </summary>
        /// <param name="door">
        /// <inheritdoc cref="DoorVariant" />
        /// </param>
        /// <param name="damage">The damage being dealt.</param>
        /// <param name="doorDamageType">
        /// <inheritdoc cref="DoorDamageType" />
        /// </param>
        /// <param name="footprint">
        /// <inheritdoc cref="Footprint" />
        /// </param>
        public DamagingDoorEventArgs(DoorVariant door, float damage, DoorDamageType doorDamageType, Footprint footprint)
        {
            Door = Door.Get(door);
            Damage = damage;
            DamageType = doorDamageType;
            Footprint = footprint;
            Player = Player.Get(footprint);

            // TODO: Remove when NW fix https://git.scpslgame.com/northwood-qa/scpsl-bug-reporting/-/issues/817
            IsAllowed = damage > 0;
        }

        /// <summary>
        /// Gets the <see cref="API.Features.Doors.Door" /> object that is damaged.
        /// </summary>
        public Door Door { get; }

        /// <summary>
        /// Gets or sets the damage dealt to the door.
        /// </summary>
        public float Damage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the door can be broken.
        /// </summary>
        public bool IsAllowed { get; set; }

        /// <summary>
        /// Gets the <see cref="DoorDamageType"/> dealt to the door.
        /// </summary>
        public DoorDamageType DamageType { get; }

        /// <inheritdoc/>
        public Player Player { get; }

        /// <summary>
        /// Gets the <see cref="Footprinting.Footprint"/> of the player that damaged the door.
        /// </summary>
        public Footprint Footprint { get; }
    }
}