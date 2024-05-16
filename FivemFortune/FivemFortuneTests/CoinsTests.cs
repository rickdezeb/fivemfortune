using FivemFortune.Data;
using FivemFortune.Logic;
using FivemFortune.Logic.Interfaces;
using Microsoft.AspNetCore.Routing;

namespace FivemFortuneTests
{
    [TestClass]
    public class CoinsTests
    {

        [TestMethod]
        public void BuyCrate_SufficientCoins()

        {
            int price = 50;

            IUpdateData updateData = new UpdateDataTest();
            IGetData getData = new GetDataTest();

            Coins coinService = new Coins(getData, updateData);

            var result = coinService.BuyCrate(price);

            Assert.AreEqual("Crate bought successfully!", result.message);
            Assert.AreEqual("green", result.colorClass);
            Assert.AreEqual(50, getData.GetCoins());


        }

        [TestMethod]
        public void BuyCrate_InsufficientCoins()

        {
            int price = 70;

            IUpdateData updateData = new UpdateDataTest();
            IGetData getData = new GetDataTest();

            Coins coinService = new Coins(getData, updateData);

            var result = coinService.BuyCrate(price);

            Assert.AreEqual("You don't have enough coins!", result.message);
            Assert.AreEqual("red", result.colorClass);
            Assert.AreEqual(50, getData.GetCoins());
        }

    }

 
}