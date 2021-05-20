using System;

namespace Library.Core.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreateRecordDate { get; set; }

        public DateTimeOffset LastUpdateRecordDate { get; set; }

        public int Version { get; set; }
    }
}