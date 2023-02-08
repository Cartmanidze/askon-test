using askon_test_application.Profiles.Requests;
using askon_test_application.Profiles.Responses;
using askon_test_domain.Users.Repositories.ReadOnly.Interfaces;
using askon_test_domain.Users.Repositories.WriteOnly;
using MediatR;

namespace askon_test_application.Templates.Requests;

/// <summary>
/// Запрос на редактирование шаблона
/// </summary>
public class EditTemplateRequest : IRequest<GetProfileResponse>
{
	/// <summary>
	/// Ник
	/// </summary>
	public string NickName { get; set; } = null!;

	/// <summary>
	/// Шаблон html
	/// </summary>
	public string Html { get; set; } = null!;
}

/// <inheritdoc />
public class EditTemplateRequestHandler : IRequestHandler<EditTemplateRequest, GetProfileResponse>
{
	private readonly IMediator _mediator;

	private readonly IUserInfoReadOnlyRepository _userInfoReadOnlyRepository;

	private readonly IUserInfoWriteOnlyRepository _userInfoWriteOnlyRepository;

	/// <summary>
	/// .ctor
	/// </summary>
	public EditTemplateRequestHandler(IUserInfoReadOnlyRepository userInfoReadOnlyRepository,
									IUserInfoWriteOnlyRepository userInfoWriteOnlyRepository, IMediator mediator)
	{
		_userInfoReadOnlyRepository = userInfoReadOnlyRepository;
		_userInfoWriteOnlyRepository = userInfoWriteOnlyRepository;
		_mediator = mediator;
	}

	/// <inheritdoc />
	public async Task<GetProfileResponse> Handle(EditTemplateRequest request, CancellationToken cancellationToken)
	{
		var userInfo = await _userInfoReadOnlyRepository.GetAsync(request.NickName, cancellationToken);

		if (userInfo!.Template == null)
		{
			userInfo.Template = new()
			{
				UserInfoId = userInfo.Id,
				Html = request.Html
			};
		} else
		{
			userInfo.Template.Html = request.Html;
		}

		await _userInfoWriteOnlyRepository.SaveAsync(userInfo, cancellationToken);

		var result = await _mediator.Send(new GetProfileRequest
		{
			NickName = request.NickName
		}, cancellationToken);

		return result;
	}
}