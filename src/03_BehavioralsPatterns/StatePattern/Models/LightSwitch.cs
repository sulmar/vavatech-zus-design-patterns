using System;
using Stateless;

namespace StatePattern
{

    public interface ILightSwitch
    {
        LightSwitchState State { get; }
        void Push();
        string Graph { get; }
    }
    
    // dotnet package Stateless

    public class LightSwitchStateMachineFactory
    {
        public StateMachine<LightSwitchState, LightSwitchTrigger> Create()
        {
            var machine = new StateMachine<LightSwitchState, LightSwitchTrigger>(LightSwitchState.Off);
            
            machine.Configure(LightSwitchState.Off)
                .OnEntry(() => Console.WriteLine("wyłącz przekaźnik"))
                .Permit(LightSwitchTrigger.Push, LightSwitchState.On);
            
            machine.Configure(LightSwitchState.On)
                .OnEntry(() =>  Console.WriteLine("załącz przekaźnik"))
                .Permit(LightSwitchTrigger.Push, LightSwitchState.Off);
            
            return machine;
        }
    }

    // Wzorzec Proxy
    // Wariant klasowy (korzysta z dziedziczenia)
    public class LightSwitchProxy(StateMachine<LightSwitchState, LightSwitchTrigger> machine) : LightSwitch, ILightSwitch
    {
        public string Graph => Stateless.Graph.MermaidGraph.Format(machine.GetInfo());
        public override LightSwitchState State => machine.State;
        public override void Push() => machine.Fire(LightSwitchTrigger.Push);
        
    }
    
    public class LightSwitch : ILightSwitch
    {
        public virtual LightSwitchState State { get; set; }
        
        public virtual void Push()
        {
           // Legacy Code
        }

        public string Graph { get; }
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
