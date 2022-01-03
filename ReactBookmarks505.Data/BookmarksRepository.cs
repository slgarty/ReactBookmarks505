using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ReactBookmarks505.Data
{
    public class BookmarksRepository
    {
        private readonly string _connectionString;

        public BookmarksRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Bookmark bookmark)
        {
            using var context = new BookmarkManagerContext(_connectionString);
            context.Bookmarks.Add(bookmark);
            context.SaveChanges();
        }

        public List<Bookmark> GetForUser(int userId)
        {
            using var context = new BookmarkManagerContext(_connectionString);
            return context.Bookmarks.Where(b => b.UserId == userId).ToList();
        }

        public bool UserOwnsBookmark(int userId, int bookmarkId)
        {
            using var context = new BookmarkManagerContext(_connectionString);
            return context.Bookmarks.Any(b => b.UserId == userId && b.Id == bookmarkId);
        }

        public void UpdateBookmark(string title, int bookmarkId)
        {
            using var context = new BookmarkManagerContext(_connectionString);
            context.Database.ExecuteSqlInterpolated($"UPDATE Bookmarks SET Title = {title} WHERE Id = {bookmarkId}");
        }

        public void DeleteBookmark(int bookmarkId)
        {
            using var context = new BookmarkManagerContext(_connectionString);
            context.Database.ExecuteSqlInterpolated($"DELETE FROM Bookmarks WHERE Id = {bookmarkId}");
        }

        public List<TopBookmark> GetTopBookmarkUrls()
        {
            var query = @"SELECT TOP 5 Url, Count(*) AS 'Count' from Bookmarks
                        GROUP BY Url
                        ORDER BY Count(*) DESC";
            using var context = new BookmarkManagerContext(_connectionString);
            return context.TopBookmarks.FromSqlRaw(query).ToList();
        }
    }
}
