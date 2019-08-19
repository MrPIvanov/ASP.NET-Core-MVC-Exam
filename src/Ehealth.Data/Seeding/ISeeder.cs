using System.Threading.Tasks;

namespace Ehealth.Data.Seeding
{
    public interface ISeeder
    {
        Task Seed();
    }
}
