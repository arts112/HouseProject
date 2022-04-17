﻿using System;


namespace House.Core.Dtos
{
    public class HouseDto
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public double Size { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
