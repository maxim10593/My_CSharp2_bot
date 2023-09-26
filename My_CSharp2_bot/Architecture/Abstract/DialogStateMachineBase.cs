namespace My_CSharp2_bot.Architecture.Abstract
{
    internal abstract class DialogStateMachineBase<TDialogStateMachineKey, TDialogStateBase>
        where TDialogStateMachineKey : notnull
        where TDialogStateBase : DialogStateBase
    {
        protected Dictionary<TDialogStateMachineKey, TDialogStateBase> stateMap = new();

        public TDialogStateBase? CurrentState { get; protected set; }

        public bool ContainsState(TDialogStateMachineKey key)
        {
            return this.stateMap.ContainsKey(key);
        }

        public void AddState(TDialogStateMachineKey key,TDialogStateBase newState)
        {
            this.stateMap.Add(key, newState);
        }

        public TDialogStateBase GetState(TDialogStateMachineKey key)
        {
            return this.stateMap[key];
        }

        public void RemoveState(TDialogStateMachineKey key)
        {
            this.stateMap.Remove(key);
        }
    }
}