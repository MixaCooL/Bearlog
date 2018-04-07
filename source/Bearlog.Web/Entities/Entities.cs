using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.SqlServer.Server;

namespace Bearlog
{
    public abstract class Translation
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public string Tags { get; set; }

        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string AuthorName { get; set; }
        public string AuthorOriginalName { get; set; }

        public Guid FromLanguageId { get; set; }
        public Guid ToLanguageId { get; set; }
        public string CoverLink { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsPublicEditable { get; set; }
        public bool IsFinished { get; set; }

        public List<Part> Parts { get; set; }
    }

    /// <summary>
    /// Для книги - главы
    /// Для субтитров - серии
    /// Для визуала - страница
    /// Для ресурсов - раздел
    /// и т.д.
    /// </summary>
    public class Part
    {
        public string Name;
        public string OriginalName { get; set; }

        public List<Fragment> Fragments { get; set; }
    }

    /// <summary>
    /// Кусок текста для перевода
    /// Абзац, предложение или что-то произвольное
    /// </summary>
    public class Fragment
    {
        public string OriginalText { get; set; }
        /// <summary>
        /// Один и тот же кусок может иметь несколько переводов
        /// Например, от нескольких переводчиков
        /// </summary>
        public List<FragmentTranslation> FragmentTranslations { get; set; }
    }

    public class FragmentTranslation
    {
        public Guid TranslatorId { get; set; }
        public string Text { get; set; }
        /// <summary>
        /// За перевод могут проголосовать: хороший или плохой
        /// Так получится рейтинг
        /// </summary>
        public int Rating { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public Guid AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Rating { get; set; }
    }

    public class Language
    {
        public Guid Id { get; set; }
        public string NativeName { get; set; }
        public string GlobalName { get; set; }
    }

    /// <summary>
    /// Книга или нечто стихотворное. 
    /// Источник - голый текст
    /// </summary>
    public class Book : Translation
    {
        /// <summary>
        /// Ссылка на Genre
        /// </summary>
        public List<Guid> Genre { get; set; }
    }

    public class Subtitle : Translation
    {
        /// <summary>
        /// Ссылка на VideoType
        /// </summary>
        public Guid? SourceType { get; set; }
    }

    public class Visual : Translation
    {
        /// <summary>
        /// Ссылка на VisualType
        /// </summary>
        public Guid? Type { get; set; }
    }

    public class Resource : Translation
    {
        /// <summary>
        /// Ссылка на ResourceType
        /// </summary>
        public Guid? Type { get; set; }
    }

    public class SubtitleFragment : Fragment
    {
        public TimeSpan BeginOffset { get; set; }
        public TimeSpan EndOffset { get; set; }
    }

    public class ImageFragment : Fragment
    {
        public List<Coordinate> Coordinates { get; set; }
        /// <summary>
        /// Номер слоя. Чем больше, тем выше в иерархии
        /// </summary>
        public uint Z { get; set; }
    }

    public class Coordinate
    {
        public uint X { get; set; }
        public uint Y { get; set; }
    }

    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// Комикс, манга, иллюстрация и т.д.
    /// </summary>
    public class VisualType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// Ресурс игры, language-pack программы
    /// </summary>
    public class ResourceType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// Художественный фильм, мультфильм, мультсериал, интернет видео и т.д.
    /// </summary>
    public class VideoType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<Guid> RoleIds { get; set; }
        public string PasswordHash { get; set; }
        public bool IsBanned { get; set; }
        public bool IsActive { get; set; }

        public string PenName { get; set; }
        public List<Achievement> Achievements { get; set; }
        public int Rating { get; set; }
        public uint Score { get; set; }
        
    }

    /// <summary>
    /// - Начинающий переводчик
    /// может создавать только приватные переводы
    /// если сделает свой перевод оплачиваемым может кидать инвайты другим переводчикам
    /// может участвовать только в публичных открытых переводах
    /// не может подавать заявки на участие в публичных закрытых переводах
    /// за такими пристально следят модераторы
    /// 
    /// - Переводчик
    /// может отправлять заявку на участие в публичных закрытых переводах
    /// может отправлять инвайты для участия в своих переводах
    /// за ним все еще внимательно следят модераторы
    /// 
    /// - Проведенный переводчик
    /// может создавать публичные переводы
    /// может кидать жалобы на других переводчиков и переводы
    /// 
    /// - Профессионал
    /// может участвовать в оплачиваемых переводах
    /// может участвовать в публичных закрытых переводах без приглашения
    /// может редактировать оригинальный текст
    /// может подать заявку в модераторы
    /// 
    /// - Модератор
    /// может кинуть предупреждение пользователю
    /// может забанить пользователя на какой-то промежуток времени
    /// проверяет публичные переводы, чтобы не нарушали законодательство
    /// может перевести перевод в приватную зону, если с ним есть какие-то проблемы
    /// следит за вежливостью и адекватностью переводчиков
    /// 
    /// - Администратор
    /// может навечно забанить пользователя
    /// может удалить перевод
    /// может присваивать и снимать статус модератора
    /// видит список всех переводов на сайте (но об этом не надо никому знать)
    /// режим бога (что бы это ни значило)
    /// </summary>
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Achievement
    {
        public Guid Id { get; set; }
        public string ImageUri { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}