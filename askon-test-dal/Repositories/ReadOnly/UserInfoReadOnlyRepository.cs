using askon_test_dal.Context;
using askon_test_domain.Users;
using askon_test_domain.Users.Repositories.ReadOnly.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace askon_test_dal.Repositories.ReadOnly;

/// <inheritdoc />
public class UserInfoReadOnlyRepository : IUserInfoReadOnlyRepository
{
	private readonly IDbContextFactory<AskonContext> _contextFactory;

	/// <summary>
	/// .ctor
	/// </summary>
	public UserInfoReadOnlyRepository(IDbContextFactory<AskonContext> contextFactory) => _contextFactory = contextFactory;

	/// <inheritdoc />
	public async Task<UserInfo> GetAsync(Guid userId, CancellationToken token)
	{
		await using var context = await _contextFactory.CreateDbContextAsync(token);

		var userInfo = await context.UserInfo.AsNoTracking()
			.FirstAsync(x => x.UserId == userId, token);

		return userInfo;
	}

	/// <inheritdoc />
	public async Task<UserInfo> GetAsync(string nickName, CancellationToken token)
	{
		await using var context = await _contextFactory.CreateDbContextAsync(token);

		var userInfo = await context.UserInfo.AsNoTracking()
			.Include(x => x.User)
			.FirstAsync(x => x.NickName == nickName, token);

		return userInfo;
	}
}