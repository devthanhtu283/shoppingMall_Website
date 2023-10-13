using ABCDMall_API.Models;

namespace ABCDMall_API.Services


{
    public interface TicketService
    {
        public dynamic Add(Ticket[] tickets);
        public dynamic GetItem(int id);
        public dynamic GetListByCustomerName(string customerName);
        public dynamic GetListByCustomerPhone(string customerPhone);

        public dynamic GetList();
    }
}
