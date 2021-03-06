﻿using BaseLibrary.Sql.Models.Interfaces;
using System;

namespace BaseLibrary.Sql.Models
{
    public abstract class SqlEntity<TKey> : ISqlEntity
    {
        public virtual TKey Id  { get; set; }
    }

    public abstract class SqlEntity : SqlEntity<Guid>
    {
        public override Guid Id 
        {
            get => base.Id == default ? Guid.NewGuid() : base.Id; 
            set => base.Id = value; 
        }
    }
}