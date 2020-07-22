using Microsoft.EntityFrameworkCore;
using RentalCar.Data.RentalBaseData.IRentalBaseData;
using RentalCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCar.Data.RentalBaseData
{
    public class RentalBaseDataRead : IRentalBaseDataRead
    {
        private readonly ApplicationDbContext _context;

        public RentalBaseDataRead(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RentalBase> GetAsync(int id)
        {
            return await _context.RentalBases.Include(x => x.Vehicles).FirstOrDefaultAsync(x => x.RentalBaseId == id);
        }

        public IEnumerable<RentalBase> GetAll()
        {
            return _context.RentalBases;
        }
    }
}
