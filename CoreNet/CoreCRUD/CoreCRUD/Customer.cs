using System.ComponentModel.DataAnnotations;

namespace CoreCRUD
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, StringLength(10)]
        public string name { get; set; }
        
    }
}