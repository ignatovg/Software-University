using System.Collections.Generic;
using System.Linq;
using Forum.Data;
using Forum.Models;
using static Forum.App.Controllers.SignUpController;
namespace Forum.App.Services
{
   public static class UserService
    {
        public static bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            ForumData forumData = new ForumData();

            bool userExist = forumData.Users.Any(u => u.Username == username && u.Password == password);

            return userExist;
        }

        public static SingUpStatus TrySignUpUser(string username, string passoword)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(passoword) && passoword.Length > 3;

            if (!validPassword || !validUsername)
            {
                return SingUpStatus.DetailsError;
            }

            ForumData forumData = new ForumData();

            bool userAlreadyExist = forumData.Users.Any(u => u.Username == username);

            if (!userAlreadyExist)
            {
                int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
                User user = new User(userId, username, passoword, new List<int>());
                forumData.Users.Add(user);
                forumData.SaveChanges();

                return SingUpStatus.Success;
            }

            return SingUpStatus.UsernameTakenError;
        }

        internal static User GetUser(int userId)
        {
            ForumData forumData = new ForumData();

            User user = forumData.Users.Find(u => u.Id == userId);

            return user;
        }

        internal static User GetUser(string username,ForumData forumData)
        {
           // ForumData forumData = new ForumData();

            User user = forumData.Users.Find(u => u.Username == username);

            return user;
        }
        
    }
}
