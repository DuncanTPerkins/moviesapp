using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MoviesApp.Models
{
    [DataContract]
    public class Actor
    {
        public Actor()
        {
            this.Movies = new List<Movie>();
            this.ActorTags = new List<ActorTag>();
        }
        [DataMember]
        public int ActorId { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public List<Movie> Movies { get; set; }
        [DataMember]
        public List<ActorTag> ActorTags { get; set; }
        [DataMember]
        public int Favorited { get; set; }
    }
}