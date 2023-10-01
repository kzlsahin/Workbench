// See https://aka.ms/new-console-template for more information
using EntityExercise.DB;
using System.Globalization;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Welcome to Post Editor!");

using var db = new BloggingContext();

while (true)
{
    Console.WriteLine("___________________________");
    int[] options = new int[] { 0, 1, 2 ,3,4,5};
    Console.WriteLine("0 - Exit");
    Console.WriteLine("1 - Add Blog");
    Console.WriteLine("2 - Add Post");
    Console.WriteLine("3 - Edit Post");
    Console.WriteLine("4 - See Post");
    Console.WriteLine("5 - Write Db");
    int opt = RequestOption("What would you like to do", options);
    switch (opt)
    {
        case 0:
            Environment.Exit(0);
            break;
        case 1:
            AddNewBlog(db);
            break;
        case 2:
            AddPost(db);
            break;
        case 3:
            EditPost(db);
            break;
        case 4:
            SeePost(db);
            break;
        case 5:
            WriteDb(db);
            break;
    }
    Console.WriteLine();
}

static void WriteDb(BloggingContext db)
{
    Console.WriteLine("Posts Table");
    foreach(var post in db.Posts)
    {
        Console.WriteLine(JsonSerializer.Serialize(post));
    }
    Console.WriteLine("Blogs Table");
    foreach (var blog in db.Blogs)
    {
        Console.WriteLine(JsonSerializer.Serialize(blog));
    }
    Console.WriteLine("Authors Table");
    foreach (var author in db.blogAuthors)
    {
        Console.WriteLine(JsonSerializer.Serialize(author));
    }
}
static void EditPost(BloggingContext db)
{
    Post? post = SelectPost(db);
    if (post == null)
    {
        Console.WriteLine("Ant blog is not selected");
        return;
    }
    int[] options = new int[] {0,1,2};
    Console.WriteLine("0 - Exit");
    Console.WriteLine("1 - Edit Title");
    Console.WriteLine("2 - Edit Content");
    int opt = RequestOption("What would you like to do", options);
    switch (opt)
    {
        case 0:
            return;
            break;
        case 1:
            Console.WriteLine("Please, enter blog title:");
            string? title = Console.ReadLine();
            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Post content is empty. Canceled the process.");
                return;
            }
            post.Title = title;
            break;
        case 2:
            Console.WriteLine("Please, enter blog content:");
            string? content = Console.ReadLine();
            if (string.IsNullOrEmpty(content))
            {
                Console.WriteLine("Post content is empty. Canceled the process.");
                return;
            }
            post.Content = content;
            break;
    }
}
static void SeePost(BloggingContext db)
{
    Post? post = SelectPost(db);
    if (post == null)
    {
        Console.WriteLine("Ant blog is not selected");
        return;
    }
    Console.WriteLine();
    Console.WriteLine("Title: " + post.Title);
    Console.WriteLine("Content: " + post.Content);
    Console.WriteLine("Author: " + post.Author ?? "null");

    Console.WriteLine("Press any key to continue...");
    Console.ReadLine();
}


static void AddNewBlog(BloggingContext db)
{
    Console.WriteLine("to add a new blog, please enter url:");
    string url = Console.ReadLine() ?? "";
    db.Add(new Blog { Url = url });
    db.SaveChanges();
}

static void AddPost(BloggingContext db)
{
    Blog? blog = SelectBlog(db);
    if(blog == null)
    {
        Console.WriteLine("Blog is not selected");
        return;
    }
    Console.WriteLine("Please, enter blog content:");
    string? content = Console.ReadLine();
    if (string.IsNullOrEmpty(content))
    {
        Console.WriteLine("Post content is empty. Canceled the process.");
        return;
    }
    Console.WriteLine("Please, enter blog title:");
    string? title = Console.ReadLine();
    if (string.IsNullOrEmpty(title))
    {
        Console.WriteLine("Post content is empty. Canceled the process.");
        return;
    }
    blog.Posts.Add(new Post { Content = content, Title=title });
    db.SaveChanges();
}

static Blog? SelectBlog(BloggingContext db)
{
    Console.WriteLine("Listing Blogs");
    List<Blog> blogs = db.Blogs.ToList();
    if (blogs.Count > 0)
    {
        int[] options = new int[blogs.Count];
        int i = 1;
        foreach (Blog blog in blogs)
        {
            options[i - 1] = i;
            Console.WriteLine($"{i} - {blog.Url}");
            i++;
        }
        int opt = RequestOption("Please select one of the blogs", options);
        return blogs[opt - 1];
    }
    else
    {
        Console.WriteLine("There is no blog available");
        return null;
    }
}

static Post? SelectPost(BloggingContext db)
{
    db.Posts.ToList();
    Blog? blog = SelectBlog(db);
    if (blog == null)
    {
        Console.WriteLine("Blog is not selected");
        return null;
    }
    var posts = blog.Posts;
    if (posts.Count > 0)
    {
        int[] options = new int[posts.Count];
        int i = 1;
        foreach (Post post in posts)
        {
            options[i - 1] = i;
            Console.WriteLine($"{i} - {post.Title}");
            i++;
        }
        int opt = RequestOption("Please select one of the posts", options);
        return blog.Posts[opt - 1];
    }
    else
    {
        Console.WriteLine("There is no post available");
        return null;
    }
}

static int RequestOption(string messege, int[] cases)
{
    Console.WriteLine(messege);
    int userInput;

    while (!int.TryParse(Console.ReadLine(), out userInput) || !cases.Contains(userInput))
    {
        Console.Write("lütfen");
        foreach (int i in cases) Console.Write(", " + i + " ");
        Console.WriteLine("seçeneklerinden birini giriniz ");
    }
    return userInput;
}

static void RequestEntry(string messege, out double userInput)
{
    Console.WriteLine(messege);
    Console.WriteLine("sayısal bir değer giriniz");

    while (!Double.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, null, out userInput))
    {
        Console.WriteLine("Girdiniz sayısal bir değer değil. sayısal bir değer giriniz (!! ondalık ayraç olarak nokta kulanın !!)");
    }
}

static bool RequestYesNo(string messege, char yes, char no)
{
    Console.WriteLine(messege + $"({yes}/{no})");

    char ans = Console.ReadKey().KeyChar;

    while (ans != yes && ans != no)
    {
        Console.WriteLine($"Girdiniz yorumlanamadı. Lütfen {yes}/{no} ile cevap veriniz.");
        ans = Console.ReadKey().KeyChar;
    }

    if (ans == yes) return true;
    return false;
}