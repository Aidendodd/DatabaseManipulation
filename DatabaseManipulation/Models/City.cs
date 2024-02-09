using System.ComponentModel.DataAnnotations;

namespace a
{
    public class City
    {
        [Key ]
        public int Id { get; set; } = 0;
        public string CityName { get; set; } = "";
        public string State { get; set; } = "";
        public int Population { get; set; } = 0;
        public double lat { get; set; } = 0;
        public double lon { get; set; } = 0;

        public override string ToString()
        {
            return $"ID: {this.Id}, City: {this.CityName}, State: {this.State}, Pop: {this.Population}";
        }


    }
}