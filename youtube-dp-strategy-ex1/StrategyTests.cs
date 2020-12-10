using System;
using Xunit;

namespace youtube_dp_strategy_ex1
{
    public class StrategyTests
    {
        [Fact]
        public void ShouldReturnSuperPower()
        {
            IHero spiderMan = new SpiderMan();
            Assert.Equal(new WeaveWeb().ExercisePower(), spiderMan.DoHeroStuff());
            IHero superMan = new SuperMan();
            Assert.Equal(new Fly().ExercisePower(), superMan.DoHeroStuff());
            IHero batMan = new BatMan();
            Assert.Equal(new Fight().ExercisePower(), batMan.DoHeroStuff());
        }

        [Fact]
        public void ShouldReturnChangedSuperPower()
        {
            //Consider using IOC container here?
            IHero spiderMan = new SpiderMan();
            Assert.Equal(new WeaveWeb().ExercisePower(), spiderMan.DoHeroStuff());
            spiderMan.ChangeSuperPower(new Fight());
            Assert.Equal(new Fight().ExercisePower(), spiderMan.DoHeroStuff());
            spiderMan.ChangeSuperPower(new Fly());
            Assert.Equal(new Fly().ExercisePower(), spiderMan.DoHeroStuff());
        }
    }
}
