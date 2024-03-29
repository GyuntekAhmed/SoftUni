﻿namespace Homies.Models.Event
{
    public class JoinedEventsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime Start { get; set; }

        public string Organiser { get; set; } = null!;

        public string Type { get; set; } = null!;

    }
}
