using System.Collections.Generic;
using DinosaursWithLasers.Model;

namespace DinosaursWithLasers.Repository
{
    public interface ICategoryRepository
    {
        void SaveCategory(Category cat);
        Category GetCategory(string catId);
    }
}