using ShoppingModelLibrary;
using ShoppingDALLibrary;
using ShoppingBLLibrary;

namespace BLTest
{
    public class Tests
    {
        ICustomerService _customerService;
        [SetUp]
        public void Setup()
        {
            _customerService = new CustomerService();
        }

        [Test]
        public void RegisterTest()
        {
            //Arrange

            //Action
            var result = _customerService.Register(new Customer { Email = "adfajfla@gmail.com", Password = "5612gdas", Phone = "9876545321", Age = 21 });
            //Assert
            Assert.IsNotNull(result);
        }
    }
}