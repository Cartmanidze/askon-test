using askon_test_application.Profiles.Responses;
using askon_test_application.Users.Services.Interfaces;
using askon_test_domain.Users;
using askon_test_domain.Users.Repositories.ReadOnly.Interfaces;
using askon_test_domain.Users.Repositories.WriteOnly;
using MediatR;

namespace askon_test_application.Profiles.Requests;

/// <summary>
/// Запрос на редактирование профиля
/// </summary>
public class EditProfileRequest : IRequest<GetProfileResponse>
{
	/// <summary>
	/// Эл.почта
	/// </summary>
	public string? Email { get; set; }

	/// <summary>
	/// Телефонный номер
	/// </summary>
	public string? PhoneNumber { get; set; }

	/// <summary>
	/// Фамилия
	/// </summary>
	public string? LastName { get; set; }

	/// <summary>
	/// Имя
	/// </summary>
	public string? FirstName { get; set; }

	/// <summary>
	/// Отчество
	/// </summary>
	public string? MiddleName { get; set; }

	/// <summary>
	/// Путь к изображению профиля
	/// </summary>
	public string? Avatar { get; set; }

	/// <summary>
	/// Описание профиля
	/// </summary>
	public string? Description { get; set; }

	/// <summary>
	/// Псевдоним
	/// </summary>
	public string NickName { get; set; } = null!;

	/// <summary>
	/// Дата рождения
	/// </summary>
	public DateTime? BirthDate { get; set; }
}

/// <inheritdoc />
public class EditProfileRequestHandler : IRequestHandler<EditProfileRequest, GetProfileResponse>
{
	private readonly IEnemyChecker _enemyChecker;

	private readonly IMediator _mediator;

	private readonly IUserInfoReadOnlyRepository _userInfoReadOnlyRepository;

	private readonly IUserInfoWriteOnlyRepository _userInfoWriteOnlyRepository;

	/// <summary>
	/// .ctor
	/// </summary>
	public EditProfileRequestHandler(IUserInfoWriteOnlyRepository userInfoWriteOnlyRepository, IMediator mediator,
									IUserInfoReadOnlyRepository userInfoReadOnlyRepository, IEnemyChecker enemyChecker)
	{
		_userInfoWriteOnlyRepository = userInfoWriteOnlyRepository;
		_mediator = mediator;
		_userInfoReadOnlyRepository = userInfoReadOnlyRepository;
		_enemyChecker = enemyChecker;
	}

	/// <inheritdoc />
	public async Task<GetProfileResponse> Handle(EditProfileRequest request, CancellationToken cancellationToken)
	{
		var userInfo = await _userInfoReadOnlyRepository.GetAsync(request.NickName, cancellationToken);

		var updatedUserInfo = Update(request, userInfo!);

		await _userInfoWriteOnlyRepository.SaveAsync(updatedUserInfo, cancellationToken);

		var result = await _mediator.Send(new GetProfileRequest
		{
			NickName = request.NickName
		}, cancellationToken);

		return result;
	}

	private static UserInfo Update(EditProfileRequest request, UserInfo oldUserInfo)
	{
		if (request.Description != null)
		{
			oldUserInfo.Description = request.Description;
		}

		if (request.Avatar != null)
		{
			oldUserInfo.Avatar = request.Avatar;
		}

		if (request.FirstName != null)
		{
			oldUserInfo.User!.FirstName = request.FirstName;
		}

		if (request.MiddleName != null)
		{
			oldUserInfo.User!.MiddleName = request.MiddleName;
		}

		if (request.LastName != null)
		{
			oldUserInfo.User!.LastName = request.LastName;
		}

		if (request.Email != null)
		{
			oldUserInfo.User!.Email = request.Email;

			oldUserInfo.User!.NormalizedUserName = !string.IsNullOrWhiteSpace(request.Email)
				? request.Email.ToUpper()
				: null;
		}

		if (request.PhoneNumber != null)
		{
			oldUserInfo.User!.PhoneNumber = request.PhoneNumber;
		}

		if (request.BirthDate != null)
		{
			oldUserInfo.BirthDate = request.BirthDate;
		}

		return oldUserInfo;
	}
}