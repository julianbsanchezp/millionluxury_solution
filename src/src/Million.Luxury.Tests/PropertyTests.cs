using NUnit.Framework;
using Million.Luxury.Domain.Entities;

namespace Million.Luxury.Tests
{
    public class PropertyTests
    {
        [Test]
        public void CreateProperty_Succeeds()
        {
            var p = new Property("Test", "Desc", 1000m);
            Assert.IsNotNull(p);
            Assert.AreEqual("Test", p.Title);
        }
    }
}
