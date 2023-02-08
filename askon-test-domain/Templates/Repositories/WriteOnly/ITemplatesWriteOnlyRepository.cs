namespace askon_test_domain.Templates.Repositories.WriteOnly;

/// <summary>
/// Репозиторий для чтения шаблонов
/// </summary>
public interface ITemplatesWriteOnlyRepository
{
	/// <summary>
	/// Сохранить
	/// </summary>
	/// <param name="template"> Шаблон </param>
	/// <param name="token"> Токен отмены </param>
	/// <returns> Шаблон </returns>
	Task<Template> SaveAsync(Template template, CancellationToken token);
}