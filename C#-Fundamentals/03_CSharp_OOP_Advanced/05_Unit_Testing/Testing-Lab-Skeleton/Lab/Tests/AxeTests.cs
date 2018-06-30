using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Tests
{
    public class AxeTests
    {
        private const int expetedAxeDurability = 10;
        private const int axeAttack = 10;

        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
             this.dummy = new Dummy(50,20);
        }

       [Test]
        public void Attack_LoseDurabilityAfterattack()
        {
            

            var axe = new Axe(axeAttack,expetedAxeDurability);
            //var dummy = new Dummy(50, 20);
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints,Is.EqualTo(4),"Axe durabilyty doesn't change after attack!");

        }

      // [Test]
        public void Attack_AttackWithBrokenAxe_ExceptionTrown()
        {
            var axe = new Axe(10,1);
           // var dummy = new Dummy(10, 15);

            axe.Attack(dummy);
            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
