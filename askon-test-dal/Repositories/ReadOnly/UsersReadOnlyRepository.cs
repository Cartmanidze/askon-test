using askon_test_dal.Context;
using askon_test_domain.Users;
using askon_test_domain.Users.Repositories.ReadOnly.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace askon_test_dal.Repositories.ReadOnly;

/// <inheritdoc />
public class UsersReadOnlyRepository : IUsersReadOnlyRepository
{
	private readonly IDbContextFactory<AskonContext> _contextFactory;

	/// <summary>
	/// .ctor
	/// </summary>
	public UsersReadOnlyRepository(IDbContextFactory<AskonContext> contextFactory) => _contextFactory = contextFactory;

	/// <inheritdoc />
	public async Task<User?> GetAsync(string login, CancellationToken token)
	{
		await using var context = await _contextFactory.CreateDbContextAsync(token);

		var user = await context.Users.AsNoTracking()
			.SingleOrDefaultAsync(x => x.UserName == login, token);

		return user;
	}
}