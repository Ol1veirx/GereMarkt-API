using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GereMarkt.Core.Enums;

namespace GereMarkt.Core.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<Product> Products { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total {  get; set; }
    }
}
