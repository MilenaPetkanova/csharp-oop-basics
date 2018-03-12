using System.Collections.Generic;

namespace Forum.Models
{
    public class User
    {
        public User(int id, string username, string password, ICollection<int> postsIds)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.PostIds = new List<int>(postsIds);
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<int> PostIds { get; set; }
    }
}
