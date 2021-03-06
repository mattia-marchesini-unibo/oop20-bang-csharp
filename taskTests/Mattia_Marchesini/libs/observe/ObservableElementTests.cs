using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace libs.observe.Tests
{
    [TestClass()]
    public class ObservableElementTests
    {
        [TestMethod()]
        public void Initialize_Void_IsDefault()
        {
            ObservableElement<int> obsInt = new ObservableElement<int>();
            Assert.AreEqual(default(int), obsInt.Element);

            ObservableElement<string> obsString = new ObservableElement<string>();
            Assert.AreEqual(default(string), obsString.Element);
        }

        [TestMethod()]
        public void Initialize_Element_IsElemet()
        {
            ObservableElement<int> obsInt = new ObservableElement<int>(1);
            Assert.AreEqual(1, obsInt.Element);
        }

        [TestMethod()]
        public void Set_Element_IsElement()
        {
            ObservableElement<int> obsInt = new ObservableElement<int>();
            obsInt.Element = 1;
            Assert.AreEqual(1, obsInt.Element);
        }

        [TestMethod()]
        public void Add_Obsserver_NotifiesObserver()
        {
            bool isNotified = false;
            ObservableElement<int> obsInt = new ObservableElement<int>(1);
            obsInt.AddObserver(delegate
            {
                isNotified = true;
            });
            obsInt.NotifyObservers();
            Assert.IsTrue(isNotified);
        }

        [TestMethod()]
        public void Set_Element_NotifiesObservers()
        {
            bool isNotified1 = false;
            bool isNotified2 = false;

            ObservableElement<int> obsInt = new ObservableElement<int>();
            obsInt.AddObserver(delegate
            {
                isNotified1 = true;
            });
            obsInt.AddObserver(delegate
            {
                isNotified2 = true;
            });
            obsInt.Element = 1;
            Assert.IsTrue(isNotified1);
            Assert.IsTrue(isNotified2);
        }

        [TestMethod()]
        public void Remove_Observer_IsRemoved()
        {
            bool isNotified = false;

            ObservableElement<int> obsInt = new ObservableElement<int>();
            Observer ob = () => isNotified = true;

            obsInt.AddObserver(ob);
            obsInt.RemoveObserver(ob);

            obsInt.Element = 1;
            Assert.IsFalse(isNotified);
        }

        [TestMethod()]
        public void Remove_AllObservers_AreRemoved()
        {
            bool isNotified1 = false;
            bool isNotified2 = false;

            ObservableElement<int> obsInt = new ObservableElement<int>();
            Observer ob1 = () => isNotified1 = true;
            Observer ob2 = () => isNotified2 = true;

            obsInt.AddObserver(ob1);
            obsInt.AddObserver(ob2);
            obsInt.RemoveAllObservers();

            obsInt.Element = 1;
            Assert.IsFalse(isNotified1);
            Assert.IsFalse(isNotified2);
        }

        class VoidClass { }
        [TestMethod()]
        public void DoesNotSet_Element_IsEmpty()
        {
            ObservableElement<VoidClass> obsVoid = new ObservableElement<VoidClass>();
            Assert.IsTrue(obsVoid.IsEmpty());
        }

        [TestMethod()]
        public void SetNoNotifyTest()
        {
            ObservableElement<int> obsInt = new ObservableElement<int>();
            
            bool isNotified = false;
            Observer ob = () => isNotified = true;
            obsInt.AddObserver(ob);

            obsInt.SetNoNotify(1);
            Assert.IsFalse(isNotified);
        }
    }
}