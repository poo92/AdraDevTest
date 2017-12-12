using System;
using BusinessLayer.Service.Interfaces;
using DataAccessLibrary.Repository;
using EntityClasses;
using System.Security.Cryptography;
using System.Text;
using DataAccessLibrary;


namespace BusinessLayer.Service
{
    public class UserService : IUserService
    {
        // create userRepo object
        private UserRepo _UserRepo;
        public UserService()
        {
            _UserRepo = new UserRepo(); // Initialize userRepo object
        }

        //get salt string to hash password method
        private static string getSalt()
        {
            var random = new RNGCryptoServiceProvider();
            int max_length = 32;             // Maximum length of salt            
            byte[] salt = new byte[max_length]; // Empty salt array            
            random.GetNonZeroBytes(salt);   // Build the random bytes            
            return Convert.ToBase64String(salt);    // Return the string encoded salt
        }

        // hash password method
        private string HashPassword(string password, string salt)
        {
            SHA256 mySHA256 = SHA256Managed.Create();
            string saltedPassword = password + salt;
            byte[] saltedPasswordBytes = Encoding.ASCII.GetBytes(saltedPassword);
            byte[] hashValue = mySHA256.ComputeHash(saltedPasswordBytes);

            return Convert.ToBase64String(hashValue);
        }

        // get user by username method
        private User GetUser(string username)
        {
            User userBAL = new User();

            user userDAL = _UserRepo.ViewUser(username);

            if (userDAL != null)
            {
                userBAL.username = userDAL.username;
                userBAL.password = userDAL.password;
                userBAL.userType = userDAL.userType;
                userBAL.fname = userDAL.fname;
                userBAL.lname = userDAL.lname;
                userBAL.salt = userDAL.salt;

            }

            return userBAL;
        }

        // Add user method
        public string AddUser(User userBAL)
        {
            string result = "";

            User userExists = GetUser(userBAL.username);

            if (userExists.username != null)
            {
                result = "This username is already in use. Please enter another username.";
            }
            else
            {
                user userDAL = new user();
                // hashing the password
                string salt = getSalt();
                string password = HashPassword(userBAL.password, salt);

                userDAL.username = userBAL.username;
                userDAL.password = password;
                userDAL.userType = userBAL.userType;
                userDAL.fname = userBAL.fname;
                userDAL.lname = userBAL.lname;
                userDAL.salt = salt;


                result = _UserRepo.AddUser(userDAL);
            }

            return result;
        }

        public User ViewUser(string username)
        {
            User userBAL = GetUser(username);

            if (userBAL != null)
            {
                userBAL.password = "";
                userBAL.salt = "";
                
            }

            return userBAL;
        }





        // Login method
        public int Login(string username, string password)
        {
            int userType = 0;
            string[] p = new string[2];


            User userExists = GetUser(username);

            if (userExists.username != null)
            {
                string dbPassword = userExists.password;
                string salt = userExists.salt;

                string hashedPassword = HashPassword(password, salt);

                p[0] = dbPassword;
                p[1] = hashedPassword;

                if (dbPassword == hashedPassword)
                {
                    userType = userExists.userType;
                }
            }

            return userType;
        }
    }


}

