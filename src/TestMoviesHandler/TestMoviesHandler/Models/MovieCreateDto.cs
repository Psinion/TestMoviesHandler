using TestMoviesHandler.Models.Base;
using TestMoviesHandler.Models.Enums;

namespace TestMoviesHandler.Models
{
    /// <summary>
    /// Data Transfer Object for movie creation.
    /// </summary>
    public class MovieCreateDto : BaseDto
    {
        public string Title { get; set; }

        public GenreType Genre { get; set; }

        public IList<int> ActorsId { get; set; }
    }
}
