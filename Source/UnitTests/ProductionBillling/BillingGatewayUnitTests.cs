//using ChargifyNET;
//using FluentAssertions;
//using LTI.Services.Billing;
//using LTI.Services.Billing.Events;
//using LTI.Services.Billing.Implementation;
//using NSubstitute;
//using NUnit.Framework;
//
//namespace LTI.UnitTests.Services.Billing.Implementation
//{
    // most tests in live tests (BillingGatewayTests)
//    [TestFixture]
//    public class BillingGatewayUnitTests
//    {
//        private const string InvalidCustomerId = "weafwe";
//
//        private BillingGateway billingGateway;
//        private IChargifyConnect chargifyConnect;
//
//        [SetUp]
//        public void SetUp()
//        {
//            chargifyConnect = Substitute.For<IChargifyConnect>();
//            billingGateway = new BillingGateway(chargifyConnect);
//
//            chargifyConnect.LoadCustomer(InvalidCustomerId).Returns((ICustomer)null);
//        }
//
//        [Test]
//        public void GetSubscription_CustomerIdNotFound_ShouldErrorAppropriately()
//        {
            // Act & Assert
//            Assert.That(() => billingGateway.GetCurrentSubscription(InvalidCustomerId), Throws.ArgumentException);
//        }
//
//        [Test]
//        public void ParseBillingEvent_CancelSubscriptionStateChangeEvent_ShouldReturnIgnoredEvent()
//        {
            // Arrange
//            const string eventName = ChargifyPayloadParser.ChargifyEventNames.SubscriptionStateChange;
//            const string payload = "payload[subscription][id]=1205979&payload[subscription][state]=canceled&[subscription][customer][reference]=123423";
//
            // Act
//            var result = billingGateway.ParseBillingEvent(eventName, payload);
//
            // Assert
//            result.Should().BeOfType<IgnoredBillingEvent>();
//        }
//
//        [Test]
//        public void ParseBillingEvent_SubscriptionUnpaidBillingEvent_ShouldReturnSubscriptionUnpaidBillingEvent()
//        {
            // Arrange
//            const string eventName = ChargifyPayloadParser.ChargifyEventNames.SubscriptionStateChange;
//            const string payload = "payload[subscription][id]=1205979&payload[subscription][state]=unpaid&[subscription][customer][reference]=123423";
//
            // Act
//            var result = billingGateway.ParseBillingEvent(eventName, payload);
//
            // Assert
//            result.Should().BeOfType<SubscriptionUnpaidBillingEvent>();
//
//            var @event = result.As<SubscriptionUnpaidBillingEvent>();
//            @event.OrganisationID.Should().Be(123423);
//            @event.SubscriptionID.Should().Be(1205979);
//        }
//    }
//}