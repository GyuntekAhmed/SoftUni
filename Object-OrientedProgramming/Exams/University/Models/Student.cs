namespace UniversityCompetition.Models
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using UniversityCompetition.Utilities.Messages;

    public class Student : IStudent
    {
        private string firstName;
        private string lastName;
        private List<int> coveredExams;
        private IUniversity university;

        public Student(int studentId, string firstName, string lastName)
        {
            Id = studentId;
            FirstName = firstName;
            LastName = lastName;
            coveredExams = new List<int>();
        }

        public int Id { get; set; }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        (string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                firstName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams => coveredExams;

        public IUniversity University => university;

        public void CoverExam(ISubject subject)
        {
            coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            
        }
    }
}
