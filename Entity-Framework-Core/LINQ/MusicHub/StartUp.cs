namespace MusicHub;

using System.Globalization;
using System.Text;
using System;

using Data;
using Initializer;

public class StartUp
{
    public static void Main()
    {
        var context =
            new MusicHubDbContext();

        DbInitializer.ResetDatabase(context);

        //var result = ExportAlbumsInfo(context, 9);
        var result = ExportSongsAboveDuration(context, 4);

        Console.WriteLine(result);
    }

    public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
    {
        var sb = new StringBuilder();

        var albumsInfo = context.Albums
            .Where(a => a.ProducerId.HasValue &&
                        a.ProducerId.Value == producerId)
            .ToArray()
            .OrderByDescending(a => a.Price)
            .Select(a => new
            {
                a.Name,
                ReleaseDate = a.ReleaseDate
                    .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                ProducerName = a.Producer!.Name,
                Songs = a.Songs
                    .Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price.ToString("f2"),
                        Writer = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.Writer)
                    .ToArray(),
                AlbumPrice = a.Price.ToString("f2")
            })
            .ToArray();

        foreach (var a in albumsInfo)
        {
            sb
                .AppendLine($"-AlbumName: {a.Name}")
                .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
                .AppendLine($"-ProducerName: {a.ProducerName}")
                .AppendLine($"-Songs:");

            int songNumber = 1;

            foreach (var song in a.Songs)
            {
                sb
                    .AppendLine($"---#{songNumber}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Price: {song.Price}")
                    .AppendLine($"---Writer: {song.Writer}");
                songNumber++;
            }

            sb.AppendLine($"-AlbumPrice: {a.AlbumPrice}");
        }

        return sb.ToString().TrimEnd();
    }

    public static string ExportSongsAboveDuration(MusicHubDbContext context, int durationSeconds)
    {
        var sb = new StringBuilder();

        var songsInfo = context.Songs
            .AsEnumerable()
            .Where(s => s.Duration.TotalSeconds > durationSeconds)
            .Select(s => new
            {
                s.Name,
                Performers = s.SongPerformers
                    .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                    .OrderBy(p => p)
                    .ToArray(),
                WriterName = s.Writer.Name,
                AlbumProducer = s.Album!.Producer!.Name,
                Duration = s.Duration.ToString("c")
            })
            .OrderBy(s => s.Name)
            .ThenBy(s => s.WriterName)
            .ToArray();

        int songNumber = 1;

        foreach (var song in songsInfo)
        {
            sb
                .AppendLine($"-Song #{songNumber}")
                .AppendLine($"---SongName: {song.Name}")
                .AppendLine($"---Writer: {song.WriterName}");

            foreach (var performer in song.Performers)
            {
                sb.AppendLine($"---Performer: {performer}");
            }

            sb
                .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                .AppendLine($"---Duration: {song.Duration}");

            songNumber++;
        }

        return sb.ToString().TrimEnd();
    }
}

