using User = MoviesService.Contract.User;

namespace MoviesService.Service.Extensions
{
    public static class UserExtension
    {
        public static User ToUserContractObject(this Models.User userModelObject)
        {
            User userContractObject = new User();
            userContractObject.Id = userModelObject.Id;
            userContractObject.FullName = userModelObject.FullName;
            userContractObject.Email = userModelObject.Email;
            return userContractObject;
        }
    }
}