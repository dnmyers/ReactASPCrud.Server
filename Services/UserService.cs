using ReactASPCrud.Models;

namespace ReactASPCrud.Services {
    public class UserService {
#pragma warning disable IDE0044 // Add readonly modifier
        private static List<User> users = new();
#pragma warning restore IDE0044 // Add readonly modifier
        private static int Count = 1;
        private static readonly string[] names = new string[] { "Jonathan", "Mary", "Susan", "Joe", "Paul", "Carl", "Amanda", "Neil", "Daniel", "Michelle", "Natalie", "Logan", "Theresa", "Brandon" };
        private static readonly string[] surnames = new string[] { "Smith", "O'Neil", "MacDonald", "Gay", "Bailee", "Saigan", "Strip", "Spenser", "Myers", "Hopper", "Prado" };
        private static readonly string[] extensions = new string[] { "@gmail.com", "@hotmail.com", "@outlook.com", "@icloud.com", "@yahoo.com", "@aol.com", "@protonmail.com" };

        // Create a list of 10 Users
        static UserService() {
            Random rnd = new();

            for(int i = 0; i < 10; i++) {
                string currName = names[rnd.Next(names.Length)];

                User user = new() {
                    Id = Count++,
                    Name = currName + " " + surnames[rnd.Next(surnames.Length)],
                    Email = currName.ToLower() + extensions[rnd.Next(extensions.Length)],
                    Document = (rnd.Next(0, 100000) * rnd.Next(0, 100000)).ToString().PadLeft(10, '0'),
                    Phone = "+1 888-452-1232"
                };

                users.Add(user);
            }
        }

        // Return a list of all Users
        public List<User> GetAll() {
            return users;
        }

        // Return a single User by id
        public User GetById(int id) {
            return users.FirstOrDefault(user => user.Id == id);
        }

        // Create a new User and return it
        public User Create(User user) {
            user.Id = Count++;
            users.Add(user);
            return user;
        }

        // Update an existing User
        public void Update(int id, User user) {
            User found = users.FirstOrDefault(n => n.Id == id);
            found.Name = user.Name;
            found.Email = user.Email;
            found.Document = user.Document;
            found.Phone = user.Phone;
        }

        // Delete a User
        public void Delete(int id) {
            users.RemoveAll(n => n.Id == id);
        }
    }
}
