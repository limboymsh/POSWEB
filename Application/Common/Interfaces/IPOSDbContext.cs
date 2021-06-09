
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{

    public interface IPOSDbContext
    {
        DbSet<BalanceLogStatus> BalanceLogStatus { get; set; }
        DbSet<Banks> Banks { get; set; }
        DbSet<CashBalance> CashBalance { get; set; }
        DbSet<CashBalanceType> CashBalanceType { get; set; }
        DbSet<City> City { get; set; }
        DbSet<Claim> Claim { get; set; }
        DbSet<ClaimDetail> ClaimDetail { get; set; }
        DbSet<Company> Company { get; set; }
        DbSet<Debt> Debt { get; set; }
        DbSet<DebtDetail> DebtDetail { get; set; }
        DbSet<Discount> Discount { get; set; }
        DbSet<District> District { get; set; }
        DbSet<Ewallet> Ewallet { get; set; }
        DbSet<Inventory> Inventory { get; set; }
        DbSet<InventoryAdjustment> InventoryAdjustment { get; set; }
        DbSet<InventoryCategory> InventoryCategory { get; set; }
        DbSet<InventoryOrder> InventoryOrder { get; set; }
        DbSet<InventoryOrderDetail> InventoryOrderDetail { get; set; }
        DbSet<InventoryOrderDiscount> InventoryOrderDiscount { get; set; }
        DbSet<InventoryOrderPromo> InventoryOrderPromo { get; set; }
        DbSet<InventorySource> InventorySource { get; set; }
        DbSet<InventorySourceDetail> InventorySourceDetail { get; set; }
        DbSet<InventoryTransaction> InventoryTransaction { get; set; }
        DbSet<InvoiceDesign> InvoiceDesign { get; set; }
        DbSet<InvoiceDesignDetails> InvoiceDesignDetails { get; set; }
        DbSet<InvoiceDesignFont> InvoiceDesignFont { get; set; }
        DbSet<Member> Member { get; set; }
        DbSet<MemberBalanceLog> MemberBalanceLog { get; set; }
        DbSet<MemberDetails> MemberDetails { get; set; }
        DbSet<MemberPointLog> MemberPointLog { get; set; }
        DbSet<MinimumChargeDetail> MinimumChargeDetail { get; set; }
        DbSet<MinimumCharges> MinimumCharges { get; set; }
        DbSet<Mutation> Mutation { get; set; }
        DbSet<MutationDetail> MutationDetail { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<OrderDeduction> OrderDeduction { get; set; }
        DbSet<OrderDetail> OrderDetail { get; set; }
        DbSet<OrderTable> OrderTable { get; set; }
        DbSet<OtherTransaction> OtherTransaction { get; set; }
        DbSet<OtherTransactionExtraCost> OtherTransactionExtraCost { get; set; }
        DbSet<OtherTransactionType> OtherTransactionType { get; set; }
        DbSet<Outlet> Outlet { get; set; }
        DbSet<OutletType> OutletType { get; set; }
        DbSet<PackageType> PackageType { get; set; }
        DbSet<PaymentMethod> PaymentMethod { get; set; }
        DbSet<PaymentMethodDetail> PaymentMethodDetail { get; set; }
        DbSet<PointLogStatus> PointLogStatus { get; set; }
        DbSet<Ppob> Ppob { get; set; }
        DbSet<Promo> Promo { get; set; }
        DbSet<PromoDetails> PromoDetails { get; set; }
        DbSet<PromoProductCategory> PromoProductCategory { get; set; }
        DbSet<Province> Province { get; set; }
        DbSet<Purchase> Purchase { get; set; }
        DbSet<PurchaseDiscount> PurchaseDiscount { get; set; }
        DbSet<PurchaseExtraCost> PurchaseExtraCost { get; set; }
        DbSet<Redeem> Redeem { get; set; }
        DbSet<RedeemType> RedeemType { get; set; }
        DbSet<Reservation> Reservation { get; set; }
        DbSet<ReservationDetail> ReservationDetail { get; set; }
        DbSet<ReservationTable> ReservationTable { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<RoleDetail> RoleDetail { get; set; }
        DbSet<RoleModule> RoleModule { get; set; }
        DbSet<Room> Room { get; set; }
        DbSet<SalesReturn> SalesReturn { get; set; }
        DbSet<SalesReturnCategory> SalesReturnCategory { get; set; }
        DbSet<SalesReturnDetail> SalesReturnDetail { get; set; }
        DbSet<Setting> Setting { get; set; }
        DbSet<SettingDetail> SettingDetail { get; set; }
        DbSet<SettingStatusId> SettingStatusId { get; set; }
        DbSet<SubDistrict> SubDistrict { get; set; }
        DbSet<SubRoom> SubRoom { get; set; }
        DbSet<SubRoomStatus> SubRoomStatus { get; set; }
        DbSet<Subscribe> Subscribe { get; set; }
        DbSet<SubscribeDeduction> SubscribeDeduction { get; set; }
        DbSet<SubscribeDeductionType> SubscribeDeductionType { get; set; }
        DbSet<SubscribeExtraCost> SubscribeExtraCost { get; set; }
        DbSet<SubscribersDetail> SubscribersDetail { get; set; }
        DbSet<Supplier> Supplier { get; set; }
        DbSet<Table> Table { get; set; }
        DbSet<TableDetail> TableDetail { get; set; }
        DbSet<Transaction> Transaction { get; set; }
        DbSet<TransactionDetail> TransactionDetail { get; set; }
        DbSet<TransactionDetailDiscount> TransactionDetailDiscount { get; set; }
        DbSet<TransactionDetailPromo> TransactionDetailPromo { get; set; }
        DbSet<TransactionExtraCost> TransactionExtraCost { get; set; }
        DbSet<User> User { get; set; }
        DbSet<UserToken> UserToken { get; set; }
        DbSet<UserOutlet> UserOutlet { get; set; }
        DbSet<UserRole> UserRole { get; set; }
        DbSet<Withdraw> Withdraw { get; set; }
        DbSet<Workers> Workers { get; set; }

        Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken = default);
        void CommitTransaction();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        void RollbackTransaction();
    }
}