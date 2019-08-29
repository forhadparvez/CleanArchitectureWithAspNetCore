using System;

namespace App.Domain.Exceptions
{
    public class StudentAgeInvalidException : Exception
    {
        public StudentAgeInvalidException(string studentName, Exception ex)
            : base($"Student: \"{studentName}\" is invalid.", ex)
        {

        }
    }
}
