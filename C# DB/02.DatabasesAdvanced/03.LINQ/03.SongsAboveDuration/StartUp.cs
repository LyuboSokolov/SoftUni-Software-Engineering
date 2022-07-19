using Microsoft.EntityFrameworkCore;
using MusicHub.Data;
using MusicHub.Initializer;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MusicHub
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

           DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {

            var result = context
                .Albums
                .ToArray()
                .Where(x => x.ProducerId == producerId)
                .OrderByDescending(x => x.Price)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy",CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                    .ToArray()
                    .Select(s => new
                             {
                                 SongName = s.Name,
                                 Price = s.Price.ToString("f2"),
                                 Writer = s.Writer.Name
                             })
                .OrderByDescending(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ToArray(),
                    TotalAlbumPrice = a.Price.ToString("f2")

                })
                .ToArray();


            StringBuilder sb = new StringBuilder();
            foreach (var album in result)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");
                int i = 1;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{i++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price}");
                    sb.AppendLine($"---Writer: {song.Writer}");
                }
                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice}");

            }

            return sb.ToString().Trim();


        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .ToArray()
                   .Where(x => x.Duration.TotalSeconds > duration)
                   .Select(x => new
                   {
                       SongName = x.Name,
                       PerformerFullName = x.SongPerformers.ToArray()
                                                           .Select(sp=>$"{sp.Performer.FirstName} {sp.Performer.LastName}")
                                                           .FirstOrDefault(),
                      
                       WriterName = x.Writer.Name,
                       AlbumProducer = x.Album.Producer.Name,
                       Duration = x.Duration.ToString("c",CultureInfo.InvariantCulture)
                   })
                   .OrderBy(x => x.SongName)
                   .ThenBy(x => x.WriterName)
                   .ThenBy(x => x.PerformerFullName)
                   .ToArray();

            StringBuilder sb = new StringBuilder();
            int i = 1;
            foreach (var song in songs)
            {

                sb.AppendLine($"-Song #{i++}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.PerformerFullName}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().Trim();
        }
    }
}
