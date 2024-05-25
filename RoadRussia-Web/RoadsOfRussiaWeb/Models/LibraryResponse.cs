using RoadsOfRussiaWeb.Entities;

namespace RoadsOfRussiaWeb.Models
{
    public class LibraryResponse
    {
        public int Id { get; set; }

        public string DocumentSection { get; set; }

        public string Name { get; set; } = null!;

        public string PathToDocument { get; set; } = null!;

        public LibraryResponse(Library library)
        {
            Id = library.Id;
            DocumentSection = library.IdDocumentSectionNavigation.Title;
            Name = library.Name;
            PathToDocument = library.PathToDocument;
        }
    }
}
