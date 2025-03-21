using CodingExerciseUnitTest1;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Shouldly;

namespace UnitTesting.Tests;

public class Tests
{
    private IUserService _userService;

    [SetUp]
    public void Setup()
    {
        _userService = new UserService();
    }

    [Test]
    public void AddUser_ShouldReturnUser_WhenUserIsValid()
    {
        var name = "Rodel";
        var result = _userService.AddUser(name);

        result.Name.ShouldBe(name);
    }

    [Test]
    public void GetAllUser_ShouldReturnAllUser_WhenUsersAreAdded()
    {
        List<User> inputUsers = new List<User>
        {
            new User { Name = "Rodel" },
            new User { Name = "Charisse" }
        };

        foreach (var user in inputUsers)
            _userService.AddUser(user.Name);

        var result = _userService.GetAllUsers();

        result.Count.ShouldBe(inputUsers.Count);
        result.Select(user => user.Name).ShouldBe(inputUsers.Select(input => input.Name));
    }

    [TestCase(1)]
    public void GetUser_ShouldReturnUser_WhenUserIsAdded(int userId)
    {
        User user = new User { Name = "Rodel" };

        var result = _userService.AddUser(user.Name);

        result.Id.ShouldBe(userId);
        result.Name.ShouldBe(user.Name);
    }

    [TestCase(1, "Charisse")]
    public void UpdateUser_ShouldReturnUpdatedUser_WhenUserExists(int userId, string name)
    {
        var addedUserId = _userService.AddUser("Rodel").Id;
        var isUpdated = _userService.UpdateUser(addedUserId, name);
        var updatedUser = _userService.GetUserById(userId);

        isUpdated.ShouldBe(true);
        updatedUser.Id.ShouldBe(addedUserId);
        updatedUser.Name.ShouldBe(name);
    }

    [TestCase(1)]
    public void DeleteUser(int userId)
    {
        var createdUser = _userService.AddUser("Rodel");
        var isDeleted = _userService.DeleteUser(userId);

    }
}