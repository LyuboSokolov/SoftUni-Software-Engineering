namespace Theatre.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                .Include(x => x.Tickets)
                .ToArray()
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Sum(t => t.Price),
                    Tickets = x.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                  .Select(t => new
                  {
                      Price = t.Price,
                      RowNumber = t.RowNumber
                  })
                  .OrderByDescending(t => t.Price)
                  .ToArray()
                })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name)
                .ToArray();




            var result = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return result;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                               .Where(x => x.Rating <= rating)
                               .OrderBy(x => x.Title)
                               .ThenByDescending(x => x.Genre)
                               .Select(x => new
                               {
                                   x.Title,
                                   x.Duration,
                                   x.Rating,
                                   x.Genre,
                                   Actors = x.Casts.Where(a => a.IsMainCharacter == true)
                                 .OrderByDescending(a => a.FullName)
                                 .Select(a => new
                                 {
                                     a.FullName,
                                     MainCharacter = a.Play.Title
                                 })
                               })
                                .ToArray();

            List<ExportPlayDto> exportDtos = new List<ExportPlayDto>();

            foreach (var play in plays)
            {
                string dbRating = play.Rating.ToString();

                if (double.Parse(dbRating) == 0)
                {
                    dbRating = "Premier";
                }

                ExportPlayDto exportPlayDto = new ExportPlayDto()
                {
                    Title = play.Title,
                    Duration = play.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = dbRating,
                    Genre = play.Genre.ToString(),

                };
                List<ExportPlayCastDto> castDtos = new List<ExportPlayCastDto>();

                foreach (var castDto in play.Actors)
                {

                    ExportPlayCastDto exportPlayCast = new ExportPlayCastDto()
                    {
                        FullName = castDto.FullName,
                        MainCharacter = $"Plays main character in '{castDto.MainCharacter}'."
                    };
                    castDtos.Add(exportPlayCast);
                }

                exportPlayDto.Actors = castDtos.ToArray();
                exportDtos.Add(exportPlayDto);
            }

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPlayDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), exportDtos.ToArray(), namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
