using System;

namespace Abduction
{

    [Serializable]
    public record Movie
    {
        private string title;

        private sbyte year;

        private string sinopsys;

        private string director;

        ///<summary> The day of the movie projection event </summary>
        private DateTime presentationDate;
    }

}
