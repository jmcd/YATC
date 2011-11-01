using System;

namespace Yatc
{
    public class NotRegisteredException : Exception
    {
        public readonly Type SubjectType;

        public NotRegisteredException(Type subjectType)
        {
            SubjectType = subjectType;
        }
    }
}