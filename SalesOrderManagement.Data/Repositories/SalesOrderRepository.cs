using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Core.Domain;
using SalesOrderManagement.Data.DBContext;


namespace SalesOrderManagement.Data.Repositories
{
    public class SalesOrderRepository : ISalesOrderRepository, IDisposable
    {
        private readonly SalesOrderDbContext _context;
        private bool disposedValue;

        public SalesOrderRepository(SalesOrderDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetSalesOrdersAsync()
        {
            return await _context.Order.OrderBy(o=> o.CreatedOn).ToListAsync();
        }

        public async Task<Order> GetSalesOrderDetailsAsync(int id)
        {
            return await _context.Order
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(w => w.Windows)
                .ThenInclude(s => s.SubElements)
                .FirstOrDefaultAsync();
        }

        public async Task<Order> CreateSalesOrderAysnc(Order order)
        {
            var response = await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();

            return response.Entity;
        }


        public async Task<Order> UpdateSalesOrderAysnc(Order order, Order orderToModify)
        {
            UpdateEntityStatus(order, orderToModify);
            await _context.SaveChangesAsync();

            return order;
        }


        public async Task<Order> DeleteOrderAsync(Order order)
        {
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }

        private void UpdateEntityStatus(Order order, Order orderToModify)
        {
            _context.Entry(orderToModify).State = EntityState.Modified;
            
            var windowsToDelete = order.Windows.Where(w => !orderToModify.Windows.Any(w1 => w1.Id == w.Id)).ToList();
            windowsToDelete.ForEach(w => _context.Entry(w).State = EntityState.Deleted);

            orderToModify.Windows.ToList().ForEach(windowToModify => {
                
                _context.Entry(windowToModify).State = windowToModify.Id == 0 ? EntityState.Added : EntityState.Modified;
                windowToModify.SubElements.ToList().ForEach(s => _context.Entry(s).State = s.Id == 0 ? EntityState.Added : EntityState.Modified);

                var window = order.Windows.FirstOrDefault(w => w.Id == windowToModify.Id);
                if (window != null)
                {
                    var subElementsToDelete = window.SubElements.Where(s => !windowToModify.SubElements.Any(s1 => s1.Id == s.Id)).ToList();

                    subElementsToDelete.ForEach(s => _context.Entry(s).State = EntityState.Deleted);
                }
            });
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }



        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
