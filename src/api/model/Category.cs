using System;
namespace LinnworkTestTask.api.model
{
    public class Category
    {
        public String categoryId { get; set; }
        public String categoryName { get; set; }
        public int stock { get; set; }

        public Category()
        {
            
        }
        
        public Category(string name, int stock)
        {
            this.categoryName = name;
            this.stock = stock;
        }
        
        public Category(string name)
        {
            this.categoryName = name;
        }

        public String Name()
        {
            return categoryName;
        }

        protected bool Equals(Category other)
        {
            return categoryId == other.categoryId && categoryName == other.categoryName && stock == other.stock;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Category) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (categoryId != null ? categoryId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (categoryName != null ? categoryName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ stock;
                return hashCode;
            }
        }

    }
}