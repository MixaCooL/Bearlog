using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using Bearlog.Web.Models;

namespace Bearlog.Web.Services
{

    public class DbService
    {
        #region User

        /// <summary>
        /// WARNING. Получить всех пользователей в системе
        /// </summary>
        /// <returns>Список всех пользоваталей</returns>
        public List<UserModel> GetUsers()
        {
            List<UserModel> users = new List<UserModel>();
            return users;
        }

        /// <summary>
        /// Получить данные пользователя
        /// </summary>
        /// <param name="userName">Логин в системе</param>
        /// <returns>Пользователь</returns>
        public UserModel GetUser(string userName)
        {
            return new UserModel();
        }

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="model">Модель пользователя</param>
        /// <returns>Флаг успешности операции</returns>
        public bool AddUser(RegisterModel model)
        {
            return false;
        }

        /// <summary>
        /// Проверить правильность пары логин и пароль
        /// </summary>
        /// <param name="userName">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Соответствуюет ли пара логин и пароль имеющимся в системе</returns>
        public bool ValidateUser(string userName, string password)
        {
            return false;
        }

        #endregion

        /// <summary>
        /// WARNING. Получить все книги в системе
        /// </summary>
        /// <returns>Список всех книг</returns>
        public List<BookModel> GetBooks()
        {
            List<BookModel> books = new List<BookModel>();
            return books;
        }

        public List<BookModel> GetUserBooks(Guid userId)
        {
            List<BookModel> books = new List<BookModel>();
            return books;
        }

        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="model">Книга</param>
        /// <param name="userId">Id пользователя, создавшего книгу</param>
        /// <param name="bookId">Id созданной книги</param>
        /// <returns>Флаг успешности операции</returns>
        public bool AddBook(BookModel model, Guid userId, out Guid bookId)
        {
            bookId = Guid.Empty;
            return false;
        }
        /// <summary>
        /// Добавить фрагмент перевода
        /// </summary>
        /// <param name="model">Фрагмент</param>
        /// <returns>Флаг успешности операции</returns>
        public bool AddPart(Part model)
        {
            return false;
        }
    }
}