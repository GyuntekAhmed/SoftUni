using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Oldest_Family_Member
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfMembers = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < countOfMembers; i++)
            {
                string[] peoples = Console.ReadLine().Split();

                var person = new Person(peoples[0], int.Parse(peoples[1]));

                family.AddMember(person);
            }

            var oldestMember = family.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }

    public class Person
    {
        private string name;
        private int age;
        
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }

        public Person(int age)
        {
            this.Name = "No name";
            this.Age = age;
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }

    public class Family
    {
        private List<Person> memberList;
        public List<Person> MemberList 
        {
            get { return memberList; }
            set { memberList = value; }
        }

        public Family()
        {
            this.MemberList = new List<Person>();
        }

        public void AddMember(Person member)
        {

            this.MemberList.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.memberList.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
