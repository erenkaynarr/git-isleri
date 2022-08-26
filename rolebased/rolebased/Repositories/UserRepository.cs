using rolebased.Models;

namespace rolebased.Repositories
{
    public class UserRepository
    {
        public static List<User> Users = new()
        {
            new() { Username = "dgpays_admin", EmailAddress = "dgpays.admin@email.com", Password = "MyPass_w0rd", GivenName = "Mudur", Surname = "DgpaysAdmin", Role = "Administrator" },
            new() { Username = "dgpays_second", EmailAddress = "dgpays.second@email.com", Password = "MyPass_w0rd", GivenName = "SatinAlimDepartmani", Surname = "DgpaysAdmin", Role = "SatinAlimDepartmani" },
            new() { Username = "dgpays_standard", EmailAddress = "dgpays.standard@email.com", Password = "MyPass_w0rd", GivenName = "Standart", Surname = "DgpaysStandart", Role = "Standard" },
        };
    }
}
