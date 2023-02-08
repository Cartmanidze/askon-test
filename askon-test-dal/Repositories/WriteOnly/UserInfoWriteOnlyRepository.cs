using askon_test_dal.Context;
using askon_test_domain.Users;
using askon_test_domain.Users.Repositories.ReadOnly.Interfaces;
using askon_test_domain.Users.Repositories.WriteOnly;
using Microsoft.EntityFrameworkCore;

namespace askon_test_dal.Repositories.WriteOnly;

/// <inheritdoc />
public class UserInfoWriteOnlyRepository : IUserInfoWriteOnlyRepository
{
	private readonly IDbContextFactory<AskonContext> _contextFactory;

	private readonly IUserInfoReadOnlyRepository _userInfoReadOnlyRepository;

	/// <summary>
	/// .ctor
	/// </summary>
	public UserInfoWriteOnlyRepository(IDbContextFactory<AskonContext> contextFactory,
										IUserInfoReadOnlyRepository userInfoReadOnlyRepository)
	{
		_contextFactory = contextFactory;
		_userInfoReadOnlyRepository = userInfoReadOnlyRepository;
	}

	/// <inheritdoc />
	public async Task<int> SaveAsync(UserInfo userInfo, CancellationToken token)
	{
		var oldUserInfo = await _userInfoReadOnlyRepository.GetAsync(userInfo.NickName, token);

		await using var context = await _contextFactory.CreateDbContextAsync(token);

		var newUserInfo = Update(userInfo, oldUserInfo);

		context.UserInfo.Update(newUserInfo);

		context.Users.Update(newUserInfo.User!);

		var result = await context.SaveChangesAsync(token);

		return result;
	}

	private static UserInfo Update(UserInfo userInfo, UserInfo? oldUserInfo)
	{
		oldUserInfo!.Description = userInfo.Description;

		oldUserInfo.Avatar = userInfo.Avatar;

		oldUserInfo.NickName = userInfo.NickName;

		oldUserInfo.User!.FirstName = userInfo.User!.FirstName;

		oldUserInfo.User!.MiddleName = userInfo.User!.MiddleName;

		oldUserInfo.User!.LastName = userInfo.User!.LastName;

		oldUserInfo.User!.Email = userInfo.User!.Email;

		oldUserInfo.User!.PhoneNumber = userInfo.User!.PhoneNumber;

		oldUserInfo.User!.NormalizedUserName = !string.IsNullOrWhiteSpace(oldUserInfo.User?.Email)
			? oldUserInfo.User!.Email.ToUpper()
			: null;

		return oldUserInfo;
	}
}