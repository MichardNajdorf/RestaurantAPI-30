﻿using System.Collections.Generic;

namespace WebApplication4.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string hasDelivery { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Dish> Dishes { get; set; }



    }
}