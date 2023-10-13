﻿using DOANWEBAPI.Models;

namespace DOANWEBAPI.Services


{
    public interface TicketService
    {
        public dynamic Add(Ticket[] tickets);
        public dynamic GetItem(int id);
        public dynamic GetListByCustomerName(string customerName);
        public dynamic GetListByCustomerPhone(string customerPhone);
    }
}
