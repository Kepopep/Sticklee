using TODO.Application.Exceptions;

namespace TODO.Domain.Entities;

public class RefreshToken
{
	public Guid Id { get; private set; }
	public Guid UserId { get; private set; }
	public string TokenHash { get; set; }

	public DateTime CreateAt { get; set; }
	public DateTime ExpireAt { get; set; }
	public DateTime? RevokeAt { get; set; }

	public bool IsExpired => DateTime.UtcNow > ExpireAt;
	public bool IsRevoked => RevokeAt != null;

	private RefreshToken() { } // EF

	public RefreshToken(Guid userId, string token, DateTime expireAt)
	{
		if (string.IsNullOrWhiteSpace(token))
		{
			throw new DomainException("No token provided");
		}

		Id = Guid.NewGuid();
		UserId = userId;
		TokenHash = token;

		CreateAt = DateTime.UtcNow;
		ExpireAt = expireAt;
	}
}
