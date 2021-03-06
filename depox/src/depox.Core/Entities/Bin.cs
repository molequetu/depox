﻿using System.Collections.Generic;
using depox.SharedKernel;
using Newtonsoft.Json;

namespace depox.Core.Entities
{
    public class Bin : BaseEntity
    {

        public string Code { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<Item> Items { get; set; }

    }
}