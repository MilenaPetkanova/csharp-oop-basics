﻿using Forum.Data;
using Forum.Models;
using System.Collections.Generic;
using System.Linq;
using static Forum.App.Controllers.SignUpController;

namespace Forum.App.Services
{
    public class UserService
    {
        public static bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            ForumData forumData = new ForumData();

            bool userExists = forumData.Users.Any(u => u.Username == username && u.Password == password);

            return userExists;
        }

        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validUsername || !validPassword)
            {
                return SignUpStatus.DetailsError;
            }

            ForumData forumData = new ForumData();

            bool userAlreadyExists = forumData.Users.Any(u => u.Username == username);

            if (!userAlreadyExists)
            {
                int userId = forumData.Users.LastOrDefault()?.Id + 1?? 1;
                var user = new User(userId, username, password, new List<int>());
                forumData.Users.Add(user);
                forumData.SaveChanges();

                return SignUpStatus.Success;
            }

            return SignUpStatus.UsernameTakenError;
        }
    }
}