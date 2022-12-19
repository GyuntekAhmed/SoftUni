namespace UniversityCompetition.Models
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Subject : ISubject
    {
        private int id;
        private string name;
        private double rate;

        public Subject(int subjectId, string subjectName, double subjectRate)
        {
            Id = subjectId;
            Name = subjectName;
            Rate = subjectRate;
        }

        public int Id
        {
            get { return id; }
            private set
            {
                id = value;
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                name = value;
            }
        }

        public double Rate
        {
            get { return rate; }
            private set
            {
                rate = value;
            }
        }
    }
}
