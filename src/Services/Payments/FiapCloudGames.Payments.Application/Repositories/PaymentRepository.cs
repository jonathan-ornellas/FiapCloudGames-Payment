using FiapCloudGames.Domain.Entities;
using FiapCloudGames.Payments.Application.Data;
using DomainPayment = FiapCloudGames.Domain.Entities.Payment;
using DataPayment = FiapCloudGames.Payments.Application.Models.Payment;

namespace FiapCloudGames.Payments.Application.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentsContext _context;

        public PaymentRepository(PaymentsContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DomainPayment payment, CancellationToken ct = default)
        {
            await _context.Payments.AddAsync(new DataPayment { UserId = Guid.Parse(payment.UserId.ToString()), GameId = Guid.Parse(payment.GameId.ToString()), Amount = payment.Amount.Value, PaymentMethod = payment.PaymentMethod, Status = payment.Status }, ct);
        }
    }
}
