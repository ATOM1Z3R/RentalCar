using System.Threading.Tasks;

namespace RentalCar.Data
{
    public interface ISave
    {
        public Task SaveChangesAsync();
    }
}
