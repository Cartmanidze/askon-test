using askon_test_application.Templates.Responses;
using askon_test_domain.Exceptions;
using askon_test_domain.Users.Repositories.ReadOnly.Interfaces;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HtmlToOpenXml;
using MediatR;

namespace askon_test_application.Templates.Requests;

/// <summary>
/// Запрос на получение шаблона в doc
/// </summary>
/// <param name="NickName"> Ник </param>
public record GetDocTemplateRequest(string NickName) : IRequest<GetDocTemplateResponse>;

/// <inheritdoc />
public class GetDocTemplateRequestHandler : IRequestHandler<GetDocTemplateRequest, GetDocTemplateResponse>
{
	private readonly IUserInfoReadOnlyRepository _userInfoReadOnlyRepository;

	/// <summary>
	/// .ctor
	/// </summary>
	public GetDocTemplateRequestHandler(IUserInfoReadOnlyRepository userInfoReadOnlyRepository) =>
		_userInfoReadOnlyRepository = userInfoReadOnlyRepository;

	/// <inheritdoc />
	public async Task<GetDocTemplateResponse> Handle(GetDocTemplateRequest request, CancellationToken cancellationToken)
	{
		var userInfo = await _userInfoReadOnlyRepository.GetAsync(request.NickName, cancellationToken);

		if (userInfo?.Template?.Html == null)
		{
			throw new TemplateNotFoundException(request.NickName);
		}

		await using var stream = new MemoryStream();

		using var package = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document);

		var mainPart = package.MainDocumentPart;

		if (mainPart == null)
		{
			mainPart = package.AddMainDocumentPart();

			new Document(new Body()).Save(mainPart);
		}

		var converter = new HtmlConverter(mainPart);

		converter.ParseHtml(userInfo.Template.Html);

		mainPart.Document.Save();

		return new($"{request.NickName}.docx", stream);
	}
}