using NUnit.Framework;

namespace TodoApplication
{
    [TestFixture]
    class ListModel_PerformanceTest
    {
        [Test, Timeout(500)]
        [Description("Не нужно хранить все состояния модели")]
        public void AntiStupidTest()
        {
            var limit = 30000;
            var model = new ListModel<int>(limit);
            for (var i = 0; i < limit; ++i)
            {
                model.AddItem(0);
            }
            Assert.AreEqual(limit, model.Items.Count);
        }
    }
}
