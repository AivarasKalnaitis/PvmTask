using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVM_task.Models
{
    public enum OrderStatus
    {
        RECEIVED,
        SHIPPED,
        DELIVERED,
        CANCELED,
        REFUNDED
    }
}
