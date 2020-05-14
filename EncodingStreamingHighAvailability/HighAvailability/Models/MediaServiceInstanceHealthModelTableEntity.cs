﻿namespace HighAvailability.Models
{
    using Microsoft.Azure.Cosmos.Table;
    using System;

    public class MediaServiceInstanceHealthModelTableEntity : TableEntity
    {
        public static readonly string DefaultRowKeyValue = "0";

        public MediaServiceInstanceHealthModelTableEntity() : this(new MediaServiceInstanceHealthModel())
        {
        }

        public MediaServiceInstanceHealthModelTableEntity(MediaServiceInstanceHealthModel mediaServiceInstanceHealthModel)
        {
            this.PartitionKey = mediaServiceInstanceHealthModel.MediaServiceAccountName;
            this.RowKey = DefaultRowKeyValue;
            this.MediaServiceAccountName = mediaServiceInstanceHealthModel.MediaServiceAccountName;
            this.HealthState = (int)mediaServiceInstanceHealthModel.HealthState;
            this.LastUpdated = mediaServiceInstanceHealthModel.LastUpdated;
        }

        /// <summary>
        /// TBD need to decide if we want to duplicate PartitionKey field in table storage, for now, we are duplicating
        /// </summary>
        public string MediaServiceAccountName { get; set; }
        public int HealthState { get; set; }
        public DateTimeOffset LastUpdated { get; set; }

        public MediaServiceInstanceHealthModel GetMediaServiceInstanceHealthModel()
        {
            return new MediaServiceInstanceHealthModel
            {
                MediaServiceAccountName = this.MediaServiceAccountName,
                HealthState = (InstanceHealthState)this.HealthState,
                LastUpdated = this.LastUpdated
            };
        }
    }
}