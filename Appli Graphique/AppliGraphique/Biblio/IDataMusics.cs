namespace Biblio
{
    public interface IDataMusics
    {
        Playlist LoadMusics();
        void SaveMusics(Playlist AllMusics);
    }
}