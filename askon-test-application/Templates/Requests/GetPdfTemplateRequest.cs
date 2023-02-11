using askon_test_application.Templates.Responses;
using askon_test_domain.Exceptions;
using askon_test_domain.Users.Repositories.ReadOnly.Interfaces;
using MediatR;
using NReco.PdfGenerator;

namespace askon_test_application.Templates.Requests;

/// <summary>
/// Запрос на получение шаблона в pdf
/// </summary>
/// <param name="NickName"> Ник </param>
public record GetPdfTemplateRequest(string NickName) : IRequest<GetPdfTemplateResponse>;

/// <inheritdoc />
public class GetPdfTemplateRequestHandler : IRequestHandler<GetPdfTemplateRequest, GetPdfTemplateResponse>
{
	private readonly IUserInfoReadOnlyRepository _userInfoReadOnlyRepository;

	/// <summary>
	/// .ctor
	/// </summary>
	public GetPdfTemplateRequestHandler(IUserInfoReadOnlyRepository userInfoReadOnlyRepository) =>
		_userInfoReadOnlyRepository = userInfoReadOnlyRepository;

	/// <inheritdoc />
	public async Task<GetPdfTemplateResponse> Handle(GetPdfTemplateRequest request, CancellationToken cancellationToken)
	{
		var userInfo = await _userInfoReadOnlyRepository.GetAsync(request.NickName, cancellationToken);

		if (userInfo?.Template?.Html == null)
		{
			throw new TemplateNotFoundException(request.NickName);
		}

		var htmlToPdf = new HtmlToPdfConverter();

		var pdfBytes = htmlToPdf.GeneratePdf(userInfo.Template.Html);

		var stream = new MemoryStream(pdfBytes);

		return new($"{request.NickName}.pdf", stream);
	}
}