﻿using System;
using System.Collections.Generic;

namespace ReactBookmarks505.Data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<Bookmark> Bookmarks { get; set; }
    }
}
