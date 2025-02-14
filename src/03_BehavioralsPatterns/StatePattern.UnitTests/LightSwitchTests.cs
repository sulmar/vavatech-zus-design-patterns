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
            LightSwitchStateMachineFactory factory = new LightSwitchStateMachineFactory();

            // Act
            ILightSwitch lightSwitch = new LightSwitchProxy(factory.Create());

            // Assert
            Assert.AreEqual(LightSwitchState.Off, lightSwitch.State);

        }

        [TestMethod]
        public void Push_Once_ShouldStateIsOn()
        {
            // Arrange
            LightSwitchStateMachineFactory factory = new LightSwitchStateMachineFactory();
            ILightSwitch lightSwitch = new LightSwitchProxy(factory.Create());

            // Act
            lightSwitch.Push();

            // Assert
            Assert.AreEqual(LightSwitchState.On, lightSwitch.State);
        }

        [TestMethod]
        public void PushDown_Twice_ShouldStateIsOff()
        {

            // Arrange
            LightSwitchStateMachineFactory factory = new LightSwitchStateMachineFactory();
            ILightSwitch lightSwitch = new LightSwitchProxy(factory.Create());



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
            LightSwitchStateMachineFactory factory = new LightSwitchStateMachineFactory();
            ILightSwitch lightSwitch = new LightSwitchProxy(factory.Create());
            
            // Act
            var result =   lightSwitch.Graph;
            
            // Assert
            Assert.IsNotNull(result);
            
        }

}
}
