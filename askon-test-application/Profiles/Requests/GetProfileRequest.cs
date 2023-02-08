using askon_test_application.Profiles.Responses;
using askon_test_domain.Users.Repositories.ReadOnly.Interfaces;
using MediatR;

namespace askon_test_application.Profiles.Requests;

/// <summary>
/// Запрос на получение профиля
/// </summary>
public class GetProfileRequest : IRequest<GetProfileResponse>
{
	/// <summary>
	/// Ник
	/// </summary>
	public string NickName { get; set; } = null!;
}

/// <inheritdoc />
public class GetProfileRequestHandler : IRequestHandler<GetProfileRequest, GetProfileResponse>
{
	private readonly IUserInfoReadOnlyRepository _userInfoReadOnlyRepository;

	/// <summary>
	/// .ctor
	/// </summary>
	public GetProfileRequestHandler(IUserInfoReadOnlyRepository userInfoReadOnlyRepository) =>
		_userInfoReadOnlyRepository = userInfoReadOnlyRepository;

	/// <inheritdoc />
	public async Task<GetProfileResponse> Handle(GetProfileRequest request, CancellationToken cancellationToken)
	{
		var userInfo = await _userInfoReadOnlyRepository.GetAsync(request.NickName, cancellationToken);

		return new()
		{
			Email = userInfo.User!.Email,
			Avatar = userInfo.Avatar,
			PhoneNumber = userInfo.User.PhoneNumber,
			LastName = userInfo.User.LastName,
			FirstName = userInfo.User.FirstName,
			MiddleName = userInfo.User.MiddleName,
			Description = userInfo.Description,
			NickName = userInfo.NickName
		};
	}
}