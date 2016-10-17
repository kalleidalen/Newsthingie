using DomainClasses;
using System.Collections.Generic;
using System.ServiceModel;

namespace NewsdeskWCFPaper
{
	[ServiceContract]
	public interface INewsdeskPaperService
	{
		[OperationContract]
		string SendEmailHasRegister(int id);

		[OperationContract]
		string SendEmailHasUnRegister(string mail);

		[OperationContract]
		List<CategoryToClient> GetAllCategories();

		[OperationContract]
		List<ArticleToClient> GetAllArticlesTopFive();

		[OperationContract]
		List<ArticleToClient> GetAllArticles();

		[OperationContract]
		List<ArticleToClient> GetAllArticlesInCategory(int categoryId);

		[OperationContract]
		int RegisterSubscriber(string email, List<int> categoryIds);

		[OperationContract]
		bool UnRegisterSubscriber(string email);
	}
}