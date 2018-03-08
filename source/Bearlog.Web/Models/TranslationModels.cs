using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Security;

namespace Bearlog.Web.Models
{
    public class TranslationModel
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

    public class BookModel : TranslationModel
    {
        public string AuthorName { get; set; }
        public string AuthorOriginalName { get; set; }
        public int Year { get; set; }
        public List<Part> Parts { get; set; }
    }
}