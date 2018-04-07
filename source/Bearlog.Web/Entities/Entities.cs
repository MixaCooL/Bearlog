using System;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;

namespace Bearlog
{
    public abstract class Translation
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public List<Guid> PartIds { get; set; }
    }

    /// <summary>
    /// Для книги - главы
    /// Для стихов - сонеты или типа того
    /// Для субтитров - серии
    /// Для визуала - страница
    /// Для ресурсов - раздел
    /// и т.д.
    /// </summary>
    public class Part
    {
        public Guid Id { get;set; }
        public List<Guid> FragmentIds { get; set; }
    }

    /// <summary>
    /// Кусок текста для перевода
    /// Абзац, предложение или что-то произвольное
    /// </summary>
    public class Fragment
    {
        public Guid Id { get; set; }
        public string OriginalText { get; set; }
        /// <summary>
        /// Один и тот же кусок может иметь несколько переводов
        /// Например, от нескольких переводчиков
        /// </summary>
        public List<Guid> FragmentTranslationIds { get; set; }
    }

    public class FragmentTranslation
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid TranslatorId { get; set; }
        /// <summary>
        /// За перевод могут проголосовать: хороший или плохой
        /// Так получится рейтинг
        /// </summary>
        public int Rating { get; set; }
        public List<Guid> CommentIds { get; set; }
    }

    public class Book : Translation
    {

    }

    public class Lyric : Translation
    {

    }

    public class Subtitle : Translation
    {

    }

    public class Visual : Translation
    {

    }

    public class Resource : Translation
    {

    }

    public class User
    {

    }
}