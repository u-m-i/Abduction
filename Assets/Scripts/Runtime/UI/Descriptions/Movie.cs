using System;
using System.Collections.Generic;

namespace Abduction.UI
{

    [Serializable]
    /// <summary>
    /// Represents the movie description from this document => 
    /// https://docs.google.com/document/d/1wanmgVmTE4V4LucGjXYGc4CWlirjlIlfjAbZF19mwsY/edit?usp=sharing
    /// </summary>
    public class Movie 
    {
        public string Title;
        
        public string Director;

        public string Genres;

        public string Date;

        public string Metadata;

        public string Description;

        public List<string> ProjectionSites;
    }
}
