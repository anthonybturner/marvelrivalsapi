namespace MarvelRivalsApi.Models.Entities
{
    public class Transformation
    {
        public int Id { get; set; }
        public string? TransformationsId { get; set; }
        public string? Name { get; set; }

        public string? Icon { get; set; }

        public string? Health { get; set; }

        public string? MovementSpeed { get; set; }


        // Foreign key to Hero
        public string? HeroId { get; set; }

    }
}
