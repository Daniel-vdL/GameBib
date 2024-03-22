using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Models
{
    public class AppDetails
    {
        public string AppId { get; set; }
        public bool Success { get; set; }
        public AppData Data { get; set; }
    }

    public class AppData
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int SteamAppId { get; set; }
        public int RequiredAge { get; set; }
        public bool IsFree { get; set; }
        public string DetailedDescription { get; set; }
        public string AboutTheGame { get; set; }
        public string ShortDescription { get; set; }
        public string SupportedLanguages { get; set; }
        public string HeaderImage { get; set; }
        public string CapsuleImage { get; set; }
        public string CapsuleImageV5 { get; set; }
        public string Website { get; set; }
        public Dictionary<string, string> PcRequirements { get; set; }
        public Dictionary<string, string> Recommended { get; set; }
        public List<string> MacRequirements { get; set; }
        public List<string> LinuxRequirements { get; set; }
        public string LegalNotice { get; set; }
        public List<string> Developers { get; set; }
        public List<string> Publishers { get; set; }
        public List<object> PackageGroups { get; set; }
        public Dictionary<string, bool> Platforms { get; set; }
        public List<Category> Categories { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Screenshot> Screenshots { get; set; }
        public List<Movie> Movies { get; set; }
        public ReleaseDate ReleaseDate { get; set; }
        public SupportInfo SupportInfo { get; set; }
        public string Background { get; set; }
        public string BackgroundRaw { get; set; }
        public ContentDescriptors ContentDescriptors { get; set; }
        public object Ratings { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class Genre
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }

    public class Screenshot
    {
        public int Id { get; set; }
        public string PathThumbnail { get; set; }
        public string PathFull { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public Dictionary<string, string> Webm { get; set; }
        public Dictionary<string, string> Mp4 { get; set; }
        public bool Highlight { get; set; }
    }

    public class ReleaseDate
    {
        public bool ComingSoon { get; set; }
        public string Date { get; set; }
    }

    public class SupportInfo
    {
        public string Url { get; set; }
        public string Email { get; set; }
    }

    public class ContentDescriptors
    {
        public List<object> Ids { get; set; }
        public object Notes { get; set; }
    }

}
