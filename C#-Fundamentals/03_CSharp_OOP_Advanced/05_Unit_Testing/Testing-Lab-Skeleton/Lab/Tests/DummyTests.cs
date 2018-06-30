using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class DummyTests
    {
        private const int AxeAttack = 2;
        private const int AxeDurability = 2;
        private const int DummyHealth = 20;
        private const int DummyHp = 20;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth,DummyHp);
        }

        [Test]
        public void DummyShouldLoseHpWhenIsAttacked()
        {
            var dummy = new Dummy(50, 20);

            dummy.TakeAttack(10);
            Assert.That(dummy.Health, Is.EqualTo(40));
        }

        [Test]
        public void TakeAttack_LoseHp_TrowhException()
        {
            var dummy = new Dummy(50, 20);

            dummy.TakeAttack(60);
            Assert.That(() => dummy.TakeAttack(10), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyShouldGiveExperiance()
        {
            var dummy = new Dummy(0,50);

            dummy.GiveExperience();
            Assert.That(dummy.GiveExperience(),Is.EqualTo(50));
        }

        [Test]
        public void AliveDummyShouldntGiveExperiance()
        {
            var dummy = new Dummy(10,50);

            Assert.That(()=> dummy.GiveExperience(),Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
