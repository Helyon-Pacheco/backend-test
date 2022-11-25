using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BackendTest.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Edition { get; set; }
        public string Isbn { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }

    }
}