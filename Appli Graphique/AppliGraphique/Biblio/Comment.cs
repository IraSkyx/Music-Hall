using System.Runtime.Serialization;

namespace Biblio
{
    [DataContract]
    internal class Comment : IComment
    {
        [DataMember(Name = "Username", Order = 0)]
        public string Username { get; set; }
        [DataMember(Name = "Rate", Order = 1)]
        public int Rate { get; set; }
        [DataMember(Name = "Com", Order = 2)]
        public string Com { get; set; }

        public Comment(string Username, int Rate, string Com)
        {
            this.Username = Username;
            this.Rate = Rate;
            this.Com = Com;
        }

        public override string ToString() 
            => $"{Username}\n{Rate}\n{Com}\n";       
    }
}
