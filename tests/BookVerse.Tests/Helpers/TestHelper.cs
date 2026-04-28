using BookVerse.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace BookVerse.Tests.Helpers;

public static class TestHelper
{
    public static Mock<UserManager<User>> MockUserManager()
    {
        var store = new Mock<IUserStore<User>>();
        return new Mock<UserManager<User>>(
            store.Object, null, null, null, null, null, null, null, null);
    }

    public static Mock<RoleManager<IdentityRole<Guid>>> MockRoleManager()
    {
        var store = new Mock<IRoleStore<IdentityRole<Guid>>>();
        return new Mock<RoleManager<IdentityRole<Guid>>>(
            store.Object, null, null, null, null);
    }
}