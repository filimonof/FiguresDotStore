using System;

namespace FiguresDotStore.ViewModels.Exceptions
{
    public class FigureValidationException : Exception
    {
        public FigureValidationException()
        {
        }

        public FigureValidationException(string message)
            : base(message)
        {
        }

        public FigureValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
