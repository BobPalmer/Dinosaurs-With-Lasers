using DinosaursWithLasers.Model;

namespace DinosaursWithLasers.Repository
{
    public interface IRiderRepository
    {
        Rider GetRiderByName(string riderName);
        void SaveRiderInfo(Rider rider);
    }
}