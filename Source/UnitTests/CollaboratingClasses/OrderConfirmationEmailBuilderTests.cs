using System;
using System.Collections.Generic;
using System.Net.Mail;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using UnitTests.CollaboratingClasses.Fakes;
using UnitTests.CollaboratingClasses.Helpers;
using UnitTests.CollaboratingClasses.Implementation;

namespace UnitTests.CollaboratingClasses
{
//    [TestFixture]
//    public class OrderConfirmationEmailBuilderTests
//    {
//        private OrderConfirmationCustomerNotifier orderConfirmationCustomerNotifier;
//        private TemplateEmailBuilder templateEmailBuilder;
//
//        [SetUp]
//        public void SetUp()
//        {
//            templateEmailBuilder = Substitute.For<TemplateEmailBuilder>();
//            templateEmailBuilder.BuildEmail(null, null).ReturnsForAnyArgs(new MailMessage());
//            orderConfirmationCustomerNotifier = new OrderConfirmationCustomerNotifier(templateEmailBuilder, new MailSenderFake());
//        }
//
//        [Test]
//        public void BuildEmail_EmailShouldHaveOrderCode()
//        {
            // Arrange
//            var order = BuildEntity.Order.AsDraft().Build();
//
            // Act
//            orderConfirmationCustomerNotifier.SendOrderConfirmedNotification(order);
//
            // Assert
//            templateEmailBuilder.Received().BuildEmail(Arg.Any<string>(), Arg.Is<Dictionary<string, string>>(
//                x => x.ContainsValue(order.Code)));
//        }
//    }
}