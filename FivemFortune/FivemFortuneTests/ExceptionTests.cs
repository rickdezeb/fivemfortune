using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FivemFortune.Logic;
using FivemFortune.Logic.Interfaces;
using FivemFortune.Logic.Exceptions;

namespace FivemFortuneTests
{

    [TestClass]
    public class ExceptionTests
    {

        [TestMethod]
        public void NegativeCoinsToRemoveExceptionTest()

        {
            IUpdateData updateData = new UpdateDataTest();
            IGetData getData = new GetDataTest();

            Coins coinService = new Coins(getData, updateData);

            Assert.ThrowsException<NegativeCoinsToRemoveException>(() => coinService.UpdateCoins(-100));
        }

        [TestMethod]
        public void ToHighCoinsToRemoveExceptionTest()

        {
            IUpdateData updateData = new UpdateDataTest();
            IGetData getData = new GetDataTest();

            Coins coinService = new Coins(getData, updateData);

            Assert.ThrowsException<ToHighCoinsToRemoveException>(() => coinService.UpdateCoins(2000));
        }

        [TestMethod]
        public void UpdateCoins_DoesNotThrowException()
        {
            IUpdateData updateData = new UpdateDataTest();
            IGetData getData = new GetDataTest();

            Coins coinService = new Coins(getData, updateData);

            try
            {
                coinService.UpdateCoins(100);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

    }
}
