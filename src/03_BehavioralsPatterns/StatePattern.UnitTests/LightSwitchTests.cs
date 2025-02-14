using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace StatePattern.UnitTests
{

    [TestClass]
    public class LightSwitchTests
    {
        [TestMethod]
        public void Init_WhenCalled_ShouldStateIsOff()
        {
            // Arrange

            // Act
            LightSwitch lightSwitch = new LightSwitch();

            // Assert
            Assert.AreEqual(LightSwitchState.Off, lightSwitch.State);

        }

        [TestMethod]
        public void Push_Once_ShouldStateIsOn()
        {
            // Arrange
            LightSwitch lightSwitch = new LightSwitch();

            // Act
            lightSwitch.Push();

            // Assert
            Assert.AreEqual(LightSwitchState.On, lightSwitch.State);
        }

        [TestMethod]
        public void PushDown_Twice_ShouldStateIsOff()
        {

            // Arrange
            LightSwitch lightSwitch = new LightSwitch();



            // Act
            lightSwitch.Push();
            lightSwitch.Push();

            // Assert
            Assert.AreEqual(LightSwitchState.Off, lightSwitch.State);


        }

        [Fact]
        public void Graph_WhenCalled_ShouldReturnGraph()
        {
            // Arrange
            LightSwitch lightSwitch = new LightSwitch();
            
            // Act
            var result =   lightSwitch.Graph;
            
            // Assert
            Assert.IsNotNull(result);
            
        }

}
}
