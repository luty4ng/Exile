namespace QuickKit
{
    public abstract class CommandBase<T> : ICommand
    {
        protected readonly T target;
        protected CommandBase()
        {
            this.target = default(T);
        }
        protected CommandBase(T target)
        {
            this.target = target;
        }
        public abstract void Excute();
        public abstract void Revoke();
        public virtual void OnEnterExcute() { }
        public virtual void OnExitExcute() { }
        public virtual void OnEnterRevoke() { }
        public virtual void OnExitRevoke() { }
    }

    public abstract class CommandBase : ICommand
    {
        protected CommandBase()
        {

        }
        public abstract void Excute();
        public virtual void Revoke() { }
        public virtual void OnEnterExcute() { }
        public virtual void OnExitExcute() { }
        public virtual void OnEnterRevoke() { }
        public virtual void OnExitRevoke() { }
    }
}
