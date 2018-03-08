﻿using System;
using System.Collections.Generic;

namespace Bearlog
{
    public class User
    {
        public virtual Guid Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string[] Roles { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual bool IsBanned { get; set; }
        public virtual bool IsActive { get; set; }
    }

    public class Translation
    {   
        public Guid Id { get; set; }
        public string[] Tags { get; set; }
        public Guid CreatorId { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public Guid FromLanguageId { get; set; }
        public Guid ToLanguageId { get; set; }
        public string CoverLink { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsFinished { get; set; }
    }

    public class Book : Translation
    {
        public string AuthorName { get; set; }
        public string AuthorOriginalName { get; set; }
        public int Year { get; set; }
        public List<Part> Parts { get; set; }
    }

    public class Part
    {
        public Guid Id { get; set; }
        public List<Fragment> Fragments { get; set; } // хранится как нумерованный список О_о
        public string Name;
        public string OriginalName { get; set; }

    }

    public class Fragment
    {
        public Guid Id { get; set; }
        public string OriginalText;
        public List<FragmentTranslation> Translations { get; set; }
    }

    public class FragmentTranslation
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public Guid FragmentId { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreateAt { get; set; }
        public List<Comments> Comments { get; set; }

    }

    public class Comments
    {

    }

    public class Language
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}