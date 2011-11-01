using System;

namespace Yatc
{
    public class CircularReferenceException : Exception
    {
        public readonly Type SubjectType;
        public readonly Type RootType;

        public CircularReferenceException() {}

        public CircularReferenceException(Type subjectType, Type rootType)
        {
            SubjectType = subjectType;
            RootType = rootType;
        }
    }
}