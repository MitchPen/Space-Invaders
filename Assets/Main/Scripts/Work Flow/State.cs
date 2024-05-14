namespace Main.Scripts.Work_Flow
{
    public abstract class State: IState
    {
        protected StateData data;
        
        protected State(StateData data)=>  this.data = data;

        public virtual void Entire() { }
        public virtual void Exit() { }
    }

    public interface IState
    {
        public void Entire();
        public void Exit();
    }

    public class StateData
    {
        public IStateSwitcher Switcher;
    }
}
