using System;
using System.Collections.Generic;
using System.Net;
using ChargifyNET;

namespace ExternalSystemIntegration
{
    public class ChargifyConnectUpTheWazooNotAnAdapter : IChargifyConnect
    {
        public IAdjustment CreateAdjustment(int SubscriptionID, decimal amount, string memo)
        {
            throw new NotImplementedException();
        }

        public IAdjustment CreateAdjustment(int SubscriptionID, decimal amount, string memo, AdjustmentMethod method)
        {
            throw new NotImplementedException();
        }

        public IAdjustment CreateAdjustment(int SubscriptionID, int amount_in_cents, string memo)
        {
            throw new NotImplementedException();
        }

        public IAdjustment CreateAdjustment(int SubscriptionID, int amount_in_cents, string memo, AdjustmentMethod method)
        {
            throw new NotImplementedException();
        }

        public IMigration PreviewMigrateSubscriptionProduct(int SubscriptionID, int ProductID, bool? IncludeTrial, bool? IncludeInitialCharge, bool? IncludeCoupons)
        {
            throw new NotImplementedException();
        }

        public IMigration PreviewMigrateSubscriptionProduct(int SubscriptionID, int ProductID)
        {
            throw new NotImplementedException();
        }

        public IMigration PreviewMigrateSubscriptionProduct(ISubscription Subscription, IProduct Product)
        {
            throw new NotImplementedException();
        }

        public IComponentAttributes SetComponent(int SubscriptionID, int ComponentID, bool SetEnabled)
        {
            throw new NotImplementedException();
        }

        public ISubscription AddCoupon(int SubscriptionID, string CouponCode)
        {
            throw new NotImplementedException();
        }

        public IUsage AddUsage(int SubscriptionID, int ComponentID, int Quantity, string Memo)
        {
            throw new NotImplementedException();
        }

        public IProduct CreateProduct(int ProductFamilyID, IProduct NewProduct)
        {
            throw new NotImplementedException();
        }

        public IProduct CreateProduct(int ProductFamilyID, string Name, string Handle, int PriceInCents, int Interval, IntervalUnit IntervalUnit, string AccountingCode, string Description)
        {
            throw new NotImplementedException();
        }

        public ICharge CreateCharge(int SubscriptionID, ICharge Charge)
        {
            throw new NotImplementedException();
        }

        public ICharge CreateCharge(int SubscriptionID, decimal amount, string memo, bool useNegativeBalance, bool delayCharge)
        {
            throw new NotImplementedException();
        }

        public ICoupon CreateCoupon(ICoupon Coupon, int ProductFamilyID)
        {
            throw new NotImplementedException();
        }

        public ICoupon UpdateCoupon(ICoupon Coupon)
        {
            throw new NotImplementedException();
        }

        public ICredit CreateCredit(int SubscriptionID, ICredit Credit)
        {
            throw new NotImplementedException();
        }

        public ICredit CreateCredit(int SubscriptionID, decimal amount, string memo)
        {
            throw new NotImplementedException();
        }

        public ICustomer CreateCustomer(ICustomer Customer)
        {
            throw new NotImplementedException();
        }

        public ICustomer CreateCustomer(string FirstName, string LastName, string EmailAddress, string Phone, string Organization, string SystemID)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscription(string ProductHandle, ICustomerAttributes CustomerAttributes)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscription(string ProductHandle, ICustomerAttributes CustomerAttributes, DateTime NextBillingAt, IPaymentProfileAttributes ExistingProfile)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscription(string ProductHandle, ICustomerAttributes CustomerAttributes, ICreditCardAttributes CreditCardAttributes)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscription(string ProductHandle, ICustomerAttributes CustomerAttributes, ICreditCardAttributes CreditCardAttributes, DateTime NextBillingAt)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscription(string ProductHandle, ICustomerAttributes CustomerAttributes, ICreditCardAttributes CreditCardAttributes, int ComponentID, int AllocatedQuantity)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscription(string ProductHandle, ICustomerAttributes CustomerAttributes, ICreditCardAttributes CreditCardAttributes, Dictionary<int, string> ComponentsWithQuantity)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscription(string ProductHandle, int ChargifyID)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscription(string ProductHandle, int ChargifyID, ICreditCardAttributes CreditCardAttributes)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscription(string ProductHandle, int ChargifyID, string CouponCode)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscription(string ProductHandle, string SystemID)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscription(string ProductHandle, string SystemID, ICreditCardAttributes CreditCardAttributes)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscriptionUsingCoupon(string ProductHandle, ICustomerAttributes CustomerAttributes, ICreditCardAttributes CreditCardAttributes, string CouponCode)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscriptionUsingCoupon(string ProductHandle, ICustomerAttributes CustomerAttributes, ICreditCardAttributes CreditCardAttributes, string CouponCode, int ComponentID, int AllocatedQuantity)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscriptionUsingCoupon(string ProductHandle, ICustomerAttributes CustomerAttributes, ICreditCardAttributes CreditCardAttributes, string CouponCode, Dictionary<int, string> ComponentsWithQuantity)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscriptionUsingCoupon(string ProductHandle, ICustomerAttributes CustomerAttributes, string CouponCode)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscriptionUsingCoupon(string ProductHandle, ICustomerAttributes CustomerAttributes, string CouponCode, DateTime NextBillingAt, IPaymentProfileAttributes ExistingProfile)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscriptionUsingCoupon(string ProductHandle, int ChargifyID, ICreditCardAttributes CreditCardAttributes, string CouponCode)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscriptionUsingCoupon(string ProductHandle, int ChargifyID, string CouponCode)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscriptionUsingCoupon(string ProductHandle, string SystemID, ICreditCardAttributes CreditCardAttributes, string CouponCode)
        {
            throw new NotImplementedException();
        }

        public ISubscription CreateSubscriptionUsingCoupon(string ProductHandle, string SystemID, string CouponCode)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(int ChargifyID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(string SystemID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSubscription(int SubscriptionID, string CancellationMessage)
        {
            throw new NotImplementedException();
        }

        public ISubscription EditSubscriptionProduct(ISubscription Subscription, IProduct Product)
        {
            throw new NotImplementedException();
        }

        public ISubscription EditSubscriptionProduct(ISubscription Subscription, string ProductHandle)
        {
            throw new NotImplementedException();
        }

        public ISubscription EditSubscriptionProduct(int SubscriptionID, IProduct Product)
        {
            throw new NotImplementedException();
        }

        public ISubscription EditSubscriptionProduct(int SubscriptionID, string ProductHandle)
        {
            throw new NotImplementedException();
        }

        public ISubscription UpdateBillingDateForSubscription(int SubscriptionID, DateTime NextBillingAt)
        {
            throw new NotImplementedException();
        }

        public ISubscription UpdateDelayedCancelForSubscription(int SubscriptionID, bool CancelAtEndOfPeriod, string CancellationMessage)
        {
            throw new NotImplementedException();
        }

        public ICoupon FindCoupon(int ProductFamilyID, string CouponCode)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, IComponent> GetComponentList(int SubscriptionID, int ComponentID)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, IComponentInfo> GetComponentsForProductFamily(int ChargifyID)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, IComponentInfo> GetComponentsForProductFamily(int ChargifyID, bool includeArchived)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, IComponentAttributes> GetComponentsForSubscription(int SubscriptionID)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, ICustomer> GetCustomerList()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, ICustomer> GetCustomerList(bool keyByChargifyID)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, ICustomer> GetCustomerList(int PageNumber)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, ICustomer> GetCustomerList(int PageNumber, bool keyByChargifyID)
        {
            throw new NotImplementedException();
        }

        public string GetPrettySubscriptionUpdateURL(string FirstName, string LastName, int SubscriptionID)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, IProduct> GetProductList()
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ISubscription> GetSubscriptionListForCustomer(int ChargifyID)
        {
            throw new NotImplementedException();
        }

        public string GetSubscriptionUpdateURL(int SubscriptionID)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionList()
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionList(List<TransactionType> kinds)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionList(List<TransactionType> kinds, int since_id, int max_id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionList(List<TransactionType> kinds, int since_id, int max_id, DateTime since_date, DateTime until_date)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionList(int page, int per_page)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionList(int page, int per_page, List<TransactionType> kinds)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionList(int page, int per_page, List<TransactionType> kinds, int since_id, int max_id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionList(int page, int per_page, List<TransactionType> kinds, int since_id, int max_id, DateTime since_date, DateTime until_date)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionsForSubscription(int SubscriptionID)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionsForSubscription(int SubscriptionID, List<TransactionType> kinds)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionsForSubscription(int SubscriptionID, List<TransactionType> kinds, int since_id, int max_id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionsForSubscription(int SubscriptionID, List<TransactionType> kinds, int since_id, int max_id, DateTime since_date, DateTime until_date)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionsForSubscription(int SubscriptionID, int page, int per_page)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionsForSubscription(int SubscriptionID, int page, int per_page, List<TransactionType> kinds)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionsForSubscription(int SubscriptionID, int page, int per_page, List<TransactionType> kinds, int since_id, int max_id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ITransaction> GetTransactionsForSubscription(int SubscriptionID, int page, int per_page, List<TransactionType> kinds, int since_id, int max_id, DateTime since_date, DateTime until_date)
        {
            throw new NotImplementedException();
        }

        public ICoupon LoadCoupon(int ProductFamilyID, int CouponID)
        {
            throw new NotImplementedException();
        }

        public ICustomer LoadCustomer(int ChargifyID)
        {
            throw new NotImplementedException();
        }

        public ICustomer LoadCustomer(string SystemID)
        {
            throw new NotImplementedException();
        }

        public IProduct LoadProduct(string Handle)
        {
            throw new NotImplementedException();
        }

        public IProduct LoadProduct(string ProductID, bool IsHandle)
        {
            throw new NotImplementedException();
        }

        public ISubscription LoadSubscription(int SubscriptionID)
        {
            throw new NotImplementedException();
        }

        public ITransaction LoadTransaction(int ID)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ISubscription> GetSubscriptionList()
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ISubscription> GetSubscriptionList(List<SubscriptionState> states)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, ISubscription> GetSubscriptionList(int page, int per_page)
        {
            throw new NotImplementedException();
        }

        public ISubscription MigrateSubscriptionProduct(ISubscription Subscription, IProduct Product, bool IncludeTrial, bool IncludeInitialCharge)
        {
            throw new NotImplementedException();
        }

        public ISubscription MigrateSubscriptionProduct(ISubscription Subscription, string ProductHandle, bool IncludeTrial, bool IncludeInitialCharge)
        {
            throw new NotImplementedException();
        }

        public ISubscription MigrateSubscriptionProduct(int SubscriptionID, IProduct Product, bool IncludeTrial, bool IncludeInitialCharge)
        {
            throw new NotImplementedException();
        }

        public ISubscription MigrateSubscriptionProduct(int SubscriptionID, string ProductHandle, bool IncludeTrial, bool IncludeInitialCharge)
        {
            throw new NotImplementedException();
        }

        public ISubscription ReactivateSubscription(int SubscriptionID)
        {
            throw new NotImplementedException();
        }

        public ISubscription ReactivateSubscription(int SubscriptionID, bool includeTrial)
        {
            throw new NotImplementedException();
        }

        public bool ResetSubscriptionBalance(int SubscriptionID)
        {
            throw new NotImplementedException();
        }

        public ICustomer UpdateCustomer(ICustomer Customer)
        {
            throw new NotImplementedException();
        }

        public ISubscription UpdateSubscriptionCreditCard(ISubscription Subscription, ICreditCardAttributes CreditCardAttributes)
        {
            throw new NotImplementedException();
        }

        public ISubscription UpdateSubscriptionCreditCard(ISubscription Subscription, string FullNumber, int? ExpirationMonth, int? ExpirationYear, string CVV, string BillingAddress, string BillingCity, string BillingState, string BillingZip, string BillingCountry)
        {
            throw new NotImplementedException();
        }

        public ISubscription UpdateSubscriptionCreditCard(int SubscriptionID, ICreditCardAttributes CreditCardAttributes)
        {
            throw new NotImplementedException();
        }

        public ISubscription UpdateSubscriptionCreditCard(int SubscriptionID, string FullNumber, int? ExpirationMonth, int? ExpirationYear, string CVV, string BillingAddress, string BillingCity, string BillingState, string BillingZip, string BillingCountry)
        {
            throw new NotImplementedException();
        }

        public ISubscription UpdateSubscriptionCreditCard(int SubscriptionID, string FirstName, string LastName, string FullNumber, int? ExpirationMonth, int? ExpirationYear, string CVV, string BillingAddress, string BillingCity, string BillingState, string BillingZip, string BillingCountry)
        {
            throw new NotImplementedException();
        }

        public ISubscription UpdateSubscription(ISubscription Subscription)
        {
            throw new NotImplementedException();
        }

        public ISubscription UpdatePaymentCollectionMethod(int SubscriptionID, PaymentCollectionMethod PaymentCollectionMethod)
        {
            throw new NotImplementedException();
        }

        public IComponentAttributes UpdateComponentAllocationForSubscription(int SubscriptionID, int ComponentID, int NewAllocatedQuantity)
        {
            throw new NotImplementedException();
        }

        public IComponentAttributes GetComponentInfoForSubscription(int SubscriptionID, int ComponentID)
        {
            throw new NotImplementedException();
        }

        public IRefund CreateRefund(int SubscriptionID, int PaymentID, decimal Amount, string Memo)
        {
            throw new NotImplementedException();
        }

        public IRefund CreateRefund(int SubscriptionID, int PaymentID, int AmountInCents, string Memo)
        {
            throw new NotImplementedException();
        }

        public IStatement LoadStatement(int StatementID)
        {
            throw new NotImplementedException();
        }

        public byte[] LoadStatementPDF(int StatementID)
        {
            throw new NotImplementedException();
        }

        public IList<int> GetStatementIDs(int SubscriptionID)
        {
            throw new NotImplementedException();
        }

        public IList<int> GetStatementIDs(int SubscriptionID, int page, int per_page)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, IStatement> GetStatementList(int SubscriptionID)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, IStatement> GetStatementList(int SubscriptionID, int page, int per_page)
        {
            throw new NotImplementedException();
        }

        public string apiKey
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool HasConnected
        {
            get { throw new NotImplementedException(); }
        }

        public HttpWebResponse LastResponse
        {
            get { throw new NotImplementedException(); }
        }

        public string Password
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string SharedKey
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string URL
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool UseJSON
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Action<HttpRequestMethod, string, string> LogRequest
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Action<HttpStatusCode, string, string> LogResponse
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}