using System;
using System.Collections.Generic;
using Tibia.Objects;

namespace Tibia.Constants
{
    /// <summary>
    /// Contains tile ids.
    /// </summary>
    public static class Tiles
    {
        public static uint ClosedHole = 593;

        /// <summary>
        /// Water tiles given as ranges
        /// </summary>
        public static class Water
        {
            /// <summary>
            /// Range of the water tiles with fish in them
            /// </summary>
            public static uint FishStart = 4597;
            public static uint FishEnd = 4602;

            /// <summary>
            /// Range of the water tiles with no fish
            /// </summary>
            public static uint NoFishStart = 4609;
            public static uint NoFishEnd = 4614;

            /// <summary>
            /// Get a list of all water tiles
            /// </summary>
            /// <returns></returns>
            public static List<uint> GetFishIds()
            {
                List<uint> tileIds = new List<uint>();

                for (uint i = FishStart; i <= FishEnd; i++)
                {
                    tileIds.Add(i);
                }

                return tileIds;
            }
        }
    }
}
