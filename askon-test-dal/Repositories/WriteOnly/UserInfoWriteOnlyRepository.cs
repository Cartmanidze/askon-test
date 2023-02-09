using askon_test_dal.Context;
using askon_test_domain.Users;
using askon_test_domain.Users.Repositories.WriteOnly;
using Microsoft.EntityFrameworkCore;

namespace askon_test_dal.Repositories.WriteOnly;

/// <inheritdoc />
public class UserInfoWriteOnlyRepository : IUserInfoWriteOnlyRepository
{
	private readonly IDbContextFactory<AskonContext> _contextFactory;

	/// <summary>
	/// .ctor
	/// </summary>
	public UserInfoWriteOnlyRepository(IDbContextFactory<AskonContext> contextFactory) => _contextFactory = contextFactory;

	/// <inheritdoc />
	public async Task<int> SaveAsync(UserInfo userInfo, CancellationToken token)
	{
		await using var context = await _contextFactory.CreateDbContextAsync(token);

		context.UserInfo.Update(userInfo);

		context.Users.Update(userInfo.User!);

		if (userInfo.Template != null)
		{
			context.Templates.Update(userInfo.Template);
		}

		var result = await context.SaveChangesAsync(token);

		return result;
	}
}