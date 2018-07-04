namespace Forum.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Forum.App.Contracts;
    using Forum.App.ViewModels;
    using Forum.Data;
    using Forum.DataModels;

    public class PostService : IPostService
    {
        private ForumData forumData;
        private IUserService userService;

        public PostService(ForumData forumData, IUserService userService)
        {
            this.forumData = forumData;
            this.userService = userService;
        }

        public int AddPost(int authorId, string postTitle, string postCategory, string postContent)
        {
            var category = this.EnsureCategory(postCategory);

            var postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;

            var author = this.userService.GetUserById(authorId);

            if(author == null)
            {
                throw new ArgumentException($"User with ID {authorId} not found!");
            }

            var post = new Post(postId, postTitle, postContent, category.Id, authorId, new List<int>() { });

            forumData.Posts.Add(post);
            author.Posts.Add(post.Id);
            category.Posts.Add(post.Id);
            forumData.SaveChanges();

            return post.Id;
        }

        private Category EnsureCategory(string postCategory)
        {
            var category = this.forumData.Categories
                .FirstOrDefault(x => x.Name == postCategory);

            if (category == null)
            {
                var categoryId = this.forumData.Categories.LastOrDefault()?.Id + 1 ?? 1;

                category = new Category(categoryId, postCategory, new List<int>() { });

                this.forumData.Categories.Add(category);
            }

            return category;
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            var post = this.forumData.Posts.Find(p => p.Id == postId);
            var author = this.userService.GetUserById(userId);

            var replyId = this.forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
            var reply = new Reply(replyId, replyContents, userId, postId);

            this.forumData.Replies.Add(reply);
            post.Replies.Add(replyId);

            this.forumData.SaveChanges();
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            var categoryName = this.forumData.Categories
                            .Select(x => new CategoryInfoViewModel(x.Id, x.Name, x.Posts.Count));

            if(categoryName == null)
            {
                throw new ArgumentException($"Category with id {categoryName} not found!");
            }

            return categoryName;
        }

        public string GetCategoryName(int categoryId)
        {
            var name =   this.forumData.Categories.FirstOrDefault(x => x.Id == categoryId)?.Name;

            if(name == null)
            {
                throw new ArgumentException($"Category withd id {categoryId} not found!");
            }

            return name;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            return this.forumData.Posts
                .Where(x=>x.CategoryId == categoryId)
                .Select(x => new PostInfoViewModel(x.Id, x.Title, x.Replies.Count));
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            var post = this.forumData.Posts.FirstOrDefault(x => x.Id == postId);

            if(post == null)
            {
                throw new ArgumentException($"Post with id {postId} not found!");
            }

            var postView = new PostViewModel(post.Title,
                this.userService.GetUserName(post.AuthorId), post.Content,
                this.GetPostReplies(postId));

            return postView;
        }

        private IEnumerable<IReplyViewModel> GetPostReplies(int postId)
        {
            var replies = this.forumData.Replies
                .Where(x => x.PostId == postId)
                .Select(r => new ReplyViewModel(r.Content, this.userService.GetUserName(r.AuthorId)));

            return replies;
        }
    }
}
