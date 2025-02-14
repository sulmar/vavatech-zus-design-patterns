using System;
using Stateless;

namespace StatePattern
{
    
    // dotnet package Stateless
    
    public class LightSwitch
    {
        public LightSwitchState State => machine.State;

        private StateMachine<LightSwitchState, LightSwitchTrigger> machine;
        
        public string Graph => Stateless.Graph.MermaidGraph.Format(machine.GetInfo());

        public LightSwitch()
        {
            machine = new StateMachine<LightSwitchState, LightSwitchTrigger>(LightSwitchState.Off);
            
            machine.Configure(LightSwitchState.Off)
                .OnEntry(() => Console.WriteLine("wyłącz przekaźnik"))
                .Permit(LightSwitchTrigger.Push, LightSwitchState.On);
            
            machine.Configure(LightSwitchState.On)
                .OnEntry(() =>  Console.WriteLine("załącz przekaźnik"))
                .Permit(LightSwitchTrigger.Push, LightSwitchState.Off);
            
        }

        public void Push()
        {
            machine.Fire(LightSwitchTrigger.Push);
        }
    }

    public enum LightSwitchState
    {
        On,
        Off
    }

    public enum LightSwitchTrigger
    {
        Push
    }

}
