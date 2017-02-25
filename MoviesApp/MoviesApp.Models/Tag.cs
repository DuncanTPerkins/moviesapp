using System.Runtime.Serialization;

namespace MoviesApp.Models
{
    [DataContract]
    public abstract class Tag: ITag
    {
        [DataMember]
        public int TagId { get; set; }
        [DataMember]
        public string TagDescription { get; set; }
    }
}
