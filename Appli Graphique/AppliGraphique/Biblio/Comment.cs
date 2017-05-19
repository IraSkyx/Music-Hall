namespace Biblio
{
    public class Comment
    {
        public string Username;
        public int Rate;
        public string Com;

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
