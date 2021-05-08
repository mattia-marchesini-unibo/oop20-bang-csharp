using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace libs.observe.Tests
{
    [TestClass()]
    public class TurnObservableTests
    {
        [TestMethod()]
        public void Set_Element_NotifiesObserverOnce()
        {
            bool isNotified = false;
            TurnObservable<int> intObs = new TurnObservable<int>();
            intObs.AddObserver(() => { isNotified = true; });
            intObs.Element = 1;
            Assert.IsTrue(isNotified);

            isNotified = false;
            intObs.Element = 0;
            Assert.IsFalse(isNotified);
        }
    }
}