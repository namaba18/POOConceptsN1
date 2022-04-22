using Concert.Data.Entities;

namespace Concert.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckEntraceAsync();
            await CheckTicketAsync();
        }

        private async Task CheckTicketAsync()
        {
            if (! _context.Tickets.Any())
            {
                for (int i = 0; i < 5000; i++)
                {
                    _context.Tickets.Add(new Ticket
                    {
                        WasUsed = false,
                        Document = "123",
                        Name = "xxxxx",
                        Date = DateTime.Today,
                        Entrace = new Entrace { Description = "Norte" }

                    });
                }
                await _context.SaveChangesAsync();

            }
        }

        private async Task CheckEntraceAsync()
        {
            if (!_context.Entraces.Any())
            {
                _context.Entraces.Add(new Entrace { Description = "Norte" });
                _context.Entraces.Add(new Entrace { Description = "Sur" });
                _context.Entraces.Add(new Entrace { Description = "Oriental" });
                _context.Entraces.Add(new Entrace { Description = "Occidental" });
                await _context.SaveChangesAsync();
            }
        }
    }
}

