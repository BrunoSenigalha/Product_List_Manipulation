using Predicate_PersonalExercise.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate_PersonalExercise.Services
{
    internal class RemoveDuplicate : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            if (x == null || y == null)
                return false;
            
            return x.Name.Equals(y.Name) && x.Price.Equals(y.Price);
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return obj.Name.GetHashCode() + obj.Price.GetHashCode();
        }
    }
}
