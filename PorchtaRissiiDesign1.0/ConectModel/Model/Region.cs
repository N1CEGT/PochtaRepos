﻿

using System.Collections.Generic;



namespace PorchaAPI
{
    public partial class Region
    {
        public Region()
        {
            Buildings = new HashSet<Building>();
            Users = new HashSet<User>();
        }

        public int RegionId { get; set; }
        public int? Countbuilding { get; set; }
        public int? Sqare { get; set; }
        public string Discript { get; set; }

        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
