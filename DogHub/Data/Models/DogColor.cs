namespace DogHub.Data.Models
{
    public class DogColor
    {
        public int ColorId { get; set; }

        public Color Color { get; set; }

        public int DogId { get; set; }

        public Dog Dog { get; set; }
    }
}
