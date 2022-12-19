namespace UniversityCompetition.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class Student : IStudent
    {
        public int Id { get; set; }

        public string FirstName => throw new System.NotImplementedException();

        public string LastName => throw new System.NotImplementedException();

        public IReadOnlyCollection<int> CoveredExams => throw new System.NotImplementedException();

        public IUniversity University => throw new System.NotImplementedException();

        public void CoverExam(ISubject subject)
        {
            throw new System.NotImplementedException();
        }

        public void JoinUniversity(IUniversity university)
        {
            throw new System.NotImplementedException();
        }
    }
}
