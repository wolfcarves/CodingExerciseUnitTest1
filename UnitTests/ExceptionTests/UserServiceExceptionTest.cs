// using CodingExerciseUnitTest1;
// using NUnit.Framework;

// namespace UnitTesting.Tests;


// [TestFixture]
// public class UserServiceExceptionTest
// {
//     private IUserService _userService;

//     [SetUp]
//     public void Setup()
//     {
//         _userService = new UserService();
//     }

//     [Test]
//     public void AddUser_ShouldThrowArgumentException_WhenUserIsNotValid()
//     {
//         var name = "";

//         var ex = Assert.Throws<ArgumentException>(() =>
//            _userService.AddUser(name)
//         );

//         Assert.That(ex.Message, Is.EqualTo("User name cannot be empty."));
//     }


// }