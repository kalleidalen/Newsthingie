using DomainClasses;
using System.Collections.Generic;
using System.ServiceModel;

namespace WCFProject
{
	[ServiceContract]
	public interface INewsdeskService
	{
		[OperationContract]
		void SendNotDeliveredMail();

		[OperationContract]
		string SendEmailAccountCreated(int id);

		[OperationContract]
		string SendEmailToEditorNewAccountCreated();

		[OperationContract]
		List<CategoryToClient> GetAllCategories();

		[OperationContract]
		CategoryToClient AddCategory(string NewCategoryName);

		[OperationContract]
		CategoryToClient EditCategory(CategoryToClient category, string newName);

		[OperationContract]
		void DeleteCategory(int id);

		[OperationContract]
		List<AuthorToClient> GetAllAuthors(bool onlyNotApproved);

		[OperationContract]
		List<Article> GetAllArticlesForAnAuthor(Author author);

		[OperationContract]
		List<AuthorToClient> GetAllAuthorsForArticleToClient(int id);

		[OperationContract]
		int CreateAuthor(Author author);

		[OperationContract]
		Author EditAuthor(Author author);

		[OperationContract]
		void DeleteAuthor(int id);

		[OperationContract]
		AuthorToClient ValidateAuthorLogin(string email, string password);

		[OperationContract]
		void AuthorIsApproved(int id);

		[OperationContract]
		void SetAuthorToEditor(int id);

		[OperationContract]
		void SetAuthorNotToEditor(int id);

		[OperationContract]
		List<ArticleToClient> GetAllArticles(bool onlyNotApproved);

		[OperationContract]
		List<Category> GetAllCategoriesInArticle(Article article);

		[OperationContract]
		List<Author> GetAllAuthorsForArticle(Article article);

		[OperationContract]
		List<CategoryToClient> GetAllCategoriesForArticleToClient(int id);

		[OperationContract]
		Article CreateArticle(Article article);

		[OperationContract]
		Article GetArticle(int id);

		[OperationContract]
		void UpdateArticle(Article Article);

		[OperationContract]
		void DeleteArticle(int id);

		[OperationContract]
		void SetArticleIsApproved(int articleId);

		[OperationContract]
		void SetArticleIsNotApproved(int articleId);

		[OperationContract]
		void SetAcceptAuthor(int authorId);

		[OperationContract]
		void SetNotAcceptAuthor(int authorId);
	}
}