using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Forum.Models;

namespace Forum.Data
{

    class DataMapper
    {

        private const string DATA_PATH = "../data/";
        private const string CONFIG_PATH = "config.ini";
        private const string DEFAULT_CONFIG = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";


        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }
        
        private static readonly Dictionary<string, string> config;
        

        private static void EnsureConfigFile(string configPath)
        {
            if (!File.Exists(configPath))
            {
                File.WriteAllText(configPath, DEFAULT_CONFIG);
            }
        }

        private static void EnsureFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private static Dictionary<string, string> LoadConfig(string configPath)
        {
            EnsureConfigFile(configPath);

            var lines = ReadLines(configPath);

            var result = lines
                .Select(l => l.Split('='))
                .ToDictionary(t => t[0], t => DATA_PATH + t[1]);

            return result;
        }

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);
            var lines = File.ReadAllLines(path);
            return lines;
        }

        private static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        public static List<Category> LoadCategories()
        {
            List<Category> categories = new List<Category>();
            string[] lines = ReadLines(config["categories"]);

            foreach (string line in lines)
            {
                var splitLine = line.Split(';');
                var id = int.Parse(splitLine[0]);
                var name = splitLine[1];
                var postIds = splitLine[2].Split(',',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                var category = new Category(id, name, postIds);
                categories.Add(category);
            }
            return categories;
        }

        public static void SaveCategories(List<Category> categories)
        {
            List<string> lines = new List<string>();
            
            foreach (Category category in categories)
            {
                const string categoryFormat = "{0};{1};{2}";
                string line = string.Format(categoryFormat, category.Id, category.Name,
                    string.Join(",",category.PostIds));

                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());
        }

        public static List<User> LoadUsers()
        {
            List<User> users = new List<User>();
            string[] lines = ReadLines(config["users"]);

            foreach (string line in lines)
            {
                var splitLine = line.Split(';');
                var id = int.Parse(splitLine[0]);
                var name = splitLine[1];
                var password = splitLine[2];
                var postIds = splitLine[3].Split(',',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                var user = new User(id, name, password, postIds);
                users.Add(user);
            }
            return users;
        }

        public static void SaveUsers(List<User> users)
        {
            List<string> lines = new List<string>();

            foreach (User user in users)
            {
                const string userFormat = "{0};{1};{2};{3}";
                string line = string.Format(userFormat, user.Id, user.Username, user.Password, string.Join(",", user.PostIds));

                lines.Add(line);
            }

            WriteLines(config["users"], lines.ToArray());
        }

        public static List<Post> LoadPosts()
        {
            List<Post> posts = new List<Post>();
            string[] lines = ReadLines(config["posts"]);

            foreach (string line in lines)
            {
                var splitLine = line.Split(';');
                var id = int.Parse(splitLine[0]);
                var title = splitLine[1];
                var content = splitLine[2];
                var categoryId = int.Parse(splitLine[3]);
                var authorId = int.Parse(splitLine[4]);
                var replyIds = splitLine[5].Split(',',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                var post = new Post(id,title,content,categoryId,authorId,replyIds);
                posts.Add(post);
            }
            return posts;
        }

        public static void SavePosts(List<Post> posts)
        {
            List<string> lines = new List<string>();
            
            foreach (Post post in posts)
            {
                const string postFormat = "{0};{1};{2};{3};{4};{5}";
                string line = string.Format(postFormat,post.Id, post.Title, post.Content, post.CategoryId, post.AuthorId,string.Join(",",post.ReplyIds));

                lines.Add(line);
            }

            WriteLines(config["posts"], lines.ToArray());
        }

        public static List<Reply> LoadReplies()
        {
            List<Reply> replies = new List<Reply>();
            string[] lines = ReadLines(config["replies"]);

            foreach (string line in lines)
            {
                var splitLine = line.Split(';');
                var id = int.Parse(splitLine[0]);
                var content = splitLine[1];
                var authorId = int.Parse(splitLine[2]);
                var postId = int.Parse(splitLine[3]);

                var reply = new Reply(id,content,authorId,postId);
                replies.Add(reply);
            }
            return replies;
        }

        public static void SaveReplies(List<Reply> replies)
        {
            List<string> lines = new List<string>();

            foreach (Reply reply in replies)
            {
                const string replyFormat = "{0};{1};{2};{3}";
                string line = string.Format(replyFormat, reply.Id, reply.Content, reply.AuthorId, reply.PostId);

                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }
    }
    
}
