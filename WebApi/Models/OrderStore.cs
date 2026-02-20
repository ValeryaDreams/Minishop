namespace WebApi.Models
{
        public class OrderStore
        {
                private readonly Dictionary<int, Order> _order = new();
                private int _id = 1;

                public Order CreateOrder()
                {
                        var order = new Order
                        {
                                Id = _id++,
                                Status = "Created"
                        };

                        _order[order.Id] = order;
                        return order;
                }

                public Order? GetOrder(int id)
                {
                        return _order.TryGetValue(id, out var order) ? order : null;
                }
        }
}