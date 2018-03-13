using Forum.App.Services;
using Forum.App.UserInterface.ViewModels;
using Forum.Data;
using Forum.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class PostService
{
    internal static Category GetCategory(int categoryId)
    {
        var forumData = new ForumData();
        var category = forumData.Categories.Find(c => c.Id == categoryId);

        return category;
    }

    internal static string[] GetAllGategoryNames()
    {
        var forumData = new ForumData();

        var allCategories = forumData.Categories.Select(c => c.Name).ToArray();

        return allCategories;
    }

    internal static IList<ReplyViewModel> GetPostReplies(int postId)
    {
        var forumData = new ForumData();

        Post post = forumData.Posts.Find(p => p.Id == postId);

        IList<ReplyViewModel> postReplies = new List<ReplyViewModel>();

        foreach (var replyId in post.ReplyIds)
        {
            var reply = forumData.Replies.Find(r => r.Id == replyId);
            postReplies.Add(new ReplyViewModel(reply));
        }

        return postReplies;
    }

    public static IEnumerable<Post> GetPostsByCategory(int categoryId)
    {
        var forumData = new ForumData();

        var postIds = forumData.Categories.First(c => c.Id == categoryId).PostIds;

        IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));

        return posts;
    }

    public static PostViewModel GetPostViewModel(int postId)
    {
        var forumData = new ForumData();

        var post = forumData.Posts.Find(p => p.Id == postId);

        var pvm = new PostViewModel(post);

        return pvm;
    }

    private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
    {
        var categoryName = postView.Category;
        var category = forumData.Categories.FirstOrDefault(c => c.Name == categoryName);
        if (category == null)
        {
            var categories = forumData.Categories;
            int categoryId = categories.Any() ? categories.Last().Id + 1 : 1;
            category = new Category(categoryId, categoryName, new List<int>());
            forumData.Categories.Add(category);
        }

        return category;
    }

    public static bool TrySavePost(PostViewModel postView)
    {
        bool emptyCategory = string.IsNullOrWhiteSpace(postView.Category);
        bool emptyTitle = string.IsNullOrWhiteSpace(postView.Title);
        bool emptyContent = !postView.Content.Any();

        if (emptyCategory || emptyContent || emptyTitle)
        {
            return false;
        }

        var dataForum = new ForumData();

        var category = EnsureCategory(postView, dataForum);

        var posts = dataForum.Posts;
        int postId = posts.Any() ? posts.Last().Id + 1 : 1;

        var author = UserService.GetUser(postView.Author);
        int authorId = author.Id;

        string content = string.Join("", postView.Content);

        var post = new Post(postId, postView.Title, content, category.Id, author.Id, new List<int>());
        dataForum.Posts.Add(post);
        author.PostIds.Add(post.Id);
        category.PostIds.Add(post.Id);
        dataForum.SaveChanges();

        postView.PostId = postId;

        return true;
    }
}