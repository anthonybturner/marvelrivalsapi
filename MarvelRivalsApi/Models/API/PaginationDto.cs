namespace MarvelRivalsApi
{
    public class PaginationDto
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public int TotalMatches { get; set; }
        public int TotalPages { get; set; }
        public bool HasMore { get; set; }

    }
}