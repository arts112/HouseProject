using System;


namespace House.Core.Domain
{
    public class Houses
    {
        public Guid? Id { get; set; }
        public string Adress { get; set; }
        public double Size { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
