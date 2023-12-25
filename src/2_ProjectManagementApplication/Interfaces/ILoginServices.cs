
namespace ProjectManagementApplication.Interfaces
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 09/02/2023
    /// Interface: ILoginServices
    /// </summary>
    public interface ILoginServices
    {
        Task<bool> Login(string email, string password);
        void Logout();
    }
}
