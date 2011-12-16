using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeMap.People
{
    public class Name
    {
        private Name()
        {
        }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }

    public class DateOfBirth
    {
        private DateTime _value;

        private DateOfBirth()
        {
        }

        public DateOfBirth(DateTime dateOfBirth)
        {
            _value = dateOfBirth;
        }

        public static implicit operator DateTime(DateOfBirth dob)
        {
            return dob._value;
        }

        public static implicit operator DateOfBirth(DateTime dateOfBirth)
        {
            return new DateOfBirth(dateOfBirth);
        }
    }
}
