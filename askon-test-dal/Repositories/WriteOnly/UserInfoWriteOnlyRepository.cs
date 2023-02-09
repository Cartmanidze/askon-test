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

		if (userInfo.Template != null)
		{
			if (userInfo.Template.Id == Guid.Empty)
			{
				await context.Templates.AddAsync(userInfo.Template, token);
			} else
			{
				context.Templates.Update(userInfo.Template);
			}
		}

		context.UserInfo.Update(userInfo);

		context.Users.Update(userInfo.User!);

		var result = await context.SaveChangesAsync(token);

		return result;
	}
}