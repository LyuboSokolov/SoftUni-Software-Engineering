namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), xmlRoot);

            ImportPlayDto[] playDtos = (ImportPlayDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();

            List<Play> dbPlays = new List<Play>();

            foreach (var playDto in playDtos)
            {
                if (!IsValid(playDtos))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                bool timeSpan = TimeSpan.TryParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture, out TimeSpan duration);

                if (!timeSpan)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                if (duration.TotalMinutes < 60)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }


                if (!Enum.TryParse(typeof(Genre), playDto.Genre, out object genre))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                if (string.IsNullOrWhiteSpace(playDto.Description))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                if (string.IsNullOrWhiteSpace(playDto.Title))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                if (string.IsNullOrWhiteSpace(playDto.Screenwriter))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Play dbPlay = new Play()
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = (Genre)genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };
                sb.AppendLine($"Successfully imported {dbPlay.Title} with genre {dbPlay.Genre} and a rating of {dbPlay.Rating}!");
                dbPlays.Add(dbPlay);
            }

            context.Plays.AddRange(dbPlays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), xmlRoot);

            ImportCastDto[] castsDtos = (ImportCastDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();

            List<Cast> dbCasts = new List<Cast>();

            foreach (var castDto in castsDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Cast dbCast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };
                string characher = dbCast.IsMainCharacter ? "main" : "lesser";
                sb.AppendLine($"Successfully imported actor {dbCast.FullName} as a {characher} character!");
                dbCasts.Add(dbCast);
            }
            context.Casts.AddRange(dbCasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {

            ImportTheatreDto[] importTheatreDtos = JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Theatre> dbTheatres = new List<Theatre>();

           
            foreach (var theatreDto in importTheatreDtos)
            {
                if (!IsValid(theatreDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                Theatre dbTheatre = new Theatre()
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director
                };

                List<Ticket> dbTickets = new List<Ticket>();

                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    Ticket dbTicket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };

                    dbTickets.Add(dbTicket);
                }
                dbTheatre.Tickets = dbTickets;
                dbTheatres.Add(dbTheatre);
                sb.AppendLine($"Successfully imported theatre {dbTheatre.Name} with #{dbTheatre.Tickets.Count} tickets!");
            }

            context.Theatres.AddRange(dbTheatres);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
