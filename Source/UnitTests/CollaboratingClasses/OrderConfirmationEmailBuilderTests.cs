using System;
using System.Collections.Generic;
using System.Net.Mail;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using UnitTests.CollaboratingClasses.Helpers;
using UnitTests.CollaboratingClasses.Implementation;

namespace UnitTests.CollaboratingClasses
{
    [TestFixture]
    public class OrderConfirmationEmailBuilderTests
    {
        private OrderConfirmationEmailBuilder orderConfirmationEmailBuilder;
        private TemplateEmailBuilder templateEmailBuilder;

        [SetUp]
        public void SetUp()
        {
            templateEmailBuilder = Substitute.For<TemplateEmailBuilder>();
            templateEmailBuilder.BuildEmail(null, null).ReturnsForAnyArgs(new MailMessage());
            orderConfirmationEmailBuilder = new OrderConfirmationEmailBuilder(templateEmailBuilder);
        }

        [Test]
        public void BuildEmail_EmailShouldHaveOrderCode()
        {
            // Arrange
            var order = BuildEntity.Order.AsDraft().Build();

            // Act
            orderConfirmationEmailBuilder.BuildOrderConfirmationEmail(order);

            // Assert
            templateEmailBuilder.Received().BuildEmail(Arg.Any<string>(), Arg.Is<Dictionary<string, string>>(
                x => x.ContainsValue(order.Code)));
        }
    }
}