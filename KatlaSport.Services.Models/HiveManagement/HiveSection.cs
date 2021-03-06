﻿using System;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a hive section.
    /// </summary>
    public class HiveSection : HiveSectionListItem
    {
        /// <summary>
        /// Gets or sets a timestamp when the hive section was updated last time.
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets Id of represented hive
        /// </summary>
        public int HiveId { get; set; }
    }
}
