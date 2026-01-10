using FiapCloudGames.Domain.Entities;

namespace FiapCloudGames.Payments.Application
{
    public interface IPaymentRepository
    {
        Task AddAsync(Payment payment, CancellationToken ct = default);
    }
}
