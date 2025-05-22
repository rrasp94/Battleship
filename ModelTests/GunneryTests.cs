using Model;

namespace ModelTests
{
    [TestClass]
    public class GunneryTests
    {
        [TestMethod]
        public void InitialShootingTacticsIsRandom()
        {
            var gunnery = new Gunnery(10, 10, new List<int> { 1, 2, 3 });
            Assert.AreEqual(ShootingTactics.Random, gunnery.ShootingTactics);
        }
        [TestMethod]
        public void ShootingTacticsRemainsRandomIfHitResultIsMissed()
        {
            var gunnery = new Gunnery(10, 10, new List<int> { 1, 2, 3 });
            gunnery.Next();
            gunnery.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Random, gunnery.ShootingTactics);
        }
        [TestMethod]
        public void ShootingTacticsChangesToSurroundingAfterFirstSquareIsHit()
        {
            var gunnery = new Gunnery(10, 10, new List<int> { 1, 2, 3 });
            gunnery.Next();
            gunnery.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Surrounding, gunnery.ShootingTactics);
        }
        [TestMethod]
        public void ShootingTacticsRemainsSurroundingIfNextSquareIsMissed()
        {
            var gunnery = new Gunnery(10, 10, new List<int> { 1, 2, 3 });
            gunnery.Next();
            gunnery.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Surrounding, gunnery.ShootingTactics);
            //gunnery.Next();
            gunnery.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Surrounding, gunnery.ShootingTactics);
        }
        [TestMethod]
        public void ShootingTacticsChangesFromSurroundingToInlineAfterSecondSquareIsHit()
        {
            var gunnery = new Gunnery(10, 10, new List<int> { 1, 2, 3 });
            gunnery.Next();
            gunnery.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Surrounding, gunnery.ShootingTactics);
            gunnery.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Inline, gunnery.ShootingTactics);
        }
        [TestMethod]
        public void ShootingTacticsRemainsInlineAfterThirdSquareIsHit()
        {
            var gunnery = new Gunnery(10, 10, new List<int> { 1, 2, 3 });
            gunnery.Next();
            gunnery.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Surrounding, gunnery.ShootingTactics);
            gunnery.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Inline, gunnery.ShootingTactics);
            gunnery.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Inline, gunnery.ShootingTactics);
        }
        [TestMethod]
        public void ShootingTacticsRemainsInlineAfterThirdSquareIsMissed()
        {
            var gunnery = new Gunnery(10, 10, new List<int> { 1, 2, 3 });
            gunnery.Next();
            gunnery.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Surrounding, gunnery.ShootingTactics);
            gunnery.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Inline, gunnery.ShootingTactics);
            gunnery.ProcessHitResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Inline, gunnery.ShootingTactics);
        }
        [TestMethod]
        public void ShootingTacticsChangesToRandomAfterShipIsSunken()
        {
            var gunnery = new Gunnery(10, 10, new List<int> { 1, 2, 3 });
            gunnery.Next();
            gunnery.ProcessHitResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Surrounding, gunnery.ShootingTactics);
            gunnery.ProcessHitResult(HitResult.Sunken);
            Assert.AreEqual(ShootingTactics.Random, gunnery.ShootingTactics);
        }
    }
}