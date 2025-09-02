using Lab5.Application.Contracts.Users;
using Moq;
using Xunit;

namespace Lab5.Tests;

public class UnitTests
{
    [Fact]
    public void TestWithdrawSuccess()
    {
        var mockCurrentUserService = new Mock<ICurrentUserService>();
        mockCurrentUserService.Setup(x => x.Deposit(It.IsAny<decimal>()));
        mockCurrentUserService.Setup(x => x.Withdraw(It.IsAny<decimal>()));
        mockCurrentUserService.Setup(x => x.CheckBalance())
            .Returns(new OperationResult.BalanceCheckSuccess(1));

        ICurrentUserService currentUserService = mockCurrentUserService.Object;

        currentUserService.Deposit(2);
        currentUserService.Withdraw(1);
        OperationResult balanceResult = currentUserService.CheckBalance();

        mockCurrentUserService.Verify(
            x => x.Deposit(2),
            Times.Once);
        mockCurrentUserService.Verify(
            x => x.Withdraw(1),
            Times.Once);
        Assert.Equal(new OperationResult.BalanceCheckSuccess(1), balanceResult);
    }

    [Fact]
    public void TestWithdrawFailed()
    {
        var mockCurrentUserService = new Mock<ICurrentUserService>();
        mockCurrentUserService.Setup(x => x.Withdraw(It.IsAny<decimal>()));
        mockCurrentUserService.Setup(x => x.Deposit(It.IsAny<decimal>()));
        mockCurrentUserService.Setup(x => x.Withdraw(It.IsAny<decimal>()))
            .Returns(new OperationResult.NotEnoughBalance());

        ICurrentUserService currentUserService = mockCurrentUserService.Object;
        OperationResult balanceResult = currentUserService.Withdraw(1);
        mockCurrentUserService.Verify(
            x => x.Withdraw(1),
            Times.Once);
        Assert.Equal(new OperationResult.NotEnoughBalance(), balanceResult);
    }

    [Fact]
    public void TestDepositSuccess1()
    {
        var mockCurrentUserService = new Mock<ICurrentUserService>();
        mockCurrentUserService.Setup(x => x.Deposit(It.IsAny<decimal>()));
        mockCurrentUserService.Setup(x => x.CheckBalance())
            .Returns(new OperationResult.BalanceCheckSuccess(1));

        ICurrentUserService currentUserService = mockCurrentUserService.Object;

        currentUserService.Deposit(1);
        OperationResult balanceResult = currentUserService.CheckBalance();

        mockCurrentUserService.Verify(
            x => x.Deposit(1),
            Times.Once);
        Assert.Equal(new OperationResult.BalanceCheckSuccess(1), balanceResult);
    }

    [Fact]
    public void TestDepositSuccess2()
    {
        var mockCurrentUserService = new Mock<ICurrentUserService>();
        mockCurrentUserService.Setup(x => x.Deposit(It.IsAny<decimal>()));
        mockCurrentUserService.Setup(x => x.CheckBalance())
            .Returns(new OperationResult.BalanceCheckSuccess(5));

        ICurrentUserService currentUserService = mockCurrentUserService.Object;

        currentUserService.Deposit(2);
        currentUserService.Deposit(3);
        OperationResult balanceResult = currentUserService.CheckBalance();

        mockCurrentUserService.Verify(
            x => x.Deposit(2),
            Times.Once);
        mockCurrentUserService.Verify(
            x => x.Deposit(3),
            Times.Once);
        Assert.Equal(new OperationResult.BalanceCheckSuccess(5), balanceResult);
    }

    [Fact]
    public void TestDepositSuccess3()
    {
        var mockCurrentUserService = new Mock<ICurrentUserService>();
        mockCurrentUserService.Setup(x => x.Deposit(It.IsAny<decimal>()));
        mockCurrentUserService.Setup(x => x.CheckBalance())
            .Returns(new OperationResult.BalanceCheckSuccess(2));

        ICurrentUserService currentUserService = mockCurrentUserService.Object;

        currentUserService.Deposit(2);
        OperationResult balanceResult = currentUserService.CheckBalance();

        mockCurrentUserService.Verify(
        x => x.Deposit(2),
        Times.Once);
        Assert.Equal(new OperationResult.BalanceCheckSuccess(2), balanceResult);
    }
}