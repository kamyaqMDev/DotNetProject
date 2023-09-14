using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using UserMailingList;
using UserMailingList.Controllers;

namespace UserMailingListTest
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      var controller = new UserMailingListController();
      var user = new UserMailing { FirstName = "Elijah", LastName = "Shamir", Email = "Elijah.Shamir@example.com" };

      var res = controller.AddUser(user);
      var oor = res.ExecuteResultAsync;
      Assert.IsNotNull(oor);
     
    }
    [TestMethod]
    public void TestMethod2()
    {
      var controller = new UserMailingListController();
      var res = controller.GetUserMailingList("Shamir", false);
      var oor = res.ToList();
      Assert.IsNotNull(oor);

    }
  }
}
