namespace Biblio
{
    public interface IDataUsers
    {
        UserDB LoadUsers();
        void SaveUsers(UserDB DataBase);
    }
}
