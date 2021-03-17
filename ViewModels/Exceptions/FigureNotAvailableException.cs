using System;

namespace FiguresDotStore.ViewModels.Exceptions
{
    public class FigureNotAvailableException : Exception
    {
        public FigureNotAvailableException()
        {
        }

        public FigureNotAvailableException(string message)
            : base(message)
        {
        }

        public FigureNotAvailableException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
