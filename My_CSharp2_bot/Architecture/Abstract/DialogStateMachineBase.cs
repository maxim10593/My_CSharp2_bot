namespace My_CSharp2_bot.Architecture.Abstract
{
    internal abstract class DialogStateMachineBase<TDialogStateMachineKey>
        where TDialogStateMachineKey : notnull
    {
        protected Dictionary<TDialogStateMachineKey, DialogStateBase<TDialogStateMachineKey>> stateMap = new();

        public DialogStateBase<TDialogStateMachineKey>? CurrentState { get; protected set; }

        public bool ContainsState(TDialogStateMachineKey key)
        {
            return this.stateMap.ContainsKey(key);
        }

        public void AddState(TDialogStateMachineKey key, DialogStateBase<TDialogStateMachineKey> newState)
        {
            this.stateMap.Add(key, newState);
        }

        public DialogStateBase<TDialogStateMachineKey> GetState(TDialogStateMachineKey key)
        {
            return this.stateMap[key];
        }

        public void RemoveState(TDialogStateMachineKey key)
        {
            this.stateMap.Remove(key);
        }
    }
}