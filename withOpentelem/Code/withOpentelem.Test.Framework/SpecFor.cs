using NUnit.Framework;

namespace withOpentelem.Test.Framework
{
    [TestFixture]
    public abstract class SpecFor
    {
        [SetUp]
        public void SetUp()
        {
            Context();
            Because();
        }
        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }
        protected abstract void Context();
        protected abstract void Because();
        protected virtual void CleanUp()
        {
        }
    }

    [TestFixture]
    public abstract class SpecFor<T>
    {
        [SetUp]
        public void SetUp()
        {
            Context();
            Because();
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }

        [OneTimeSetUp]
        public void FixtureSetUp()
        {
            GlobalContext();
        }

        [OneTimeTearDown]
        public void FixtureTearDown()
        {
            GlobalCleanUp();
        }

        protected T subject;
        public abstract void Context();
        public abstract void Because();

        private void CleanUp()
        {
        }

        private void GlobalContext()
        {
        }

        private void GlobalCleanUp()
        {
        }
    }
}
