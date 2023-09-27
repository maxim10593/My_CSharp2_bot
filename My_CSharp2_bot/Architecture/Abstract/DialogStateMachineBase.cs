namespace My_CSharp2_bot.Architecture.Abstract
{
    internal abstract class DialogStateMachineBase<TDialogStateMachineKey, TEntityId>
        where TDialogStateMachineKey : notnull
        where TEntityId : notnull
    {
        public DialogStateMachineBase(IDialogEnity<TEntityId, TDialogStateMachineKey> dialogEnity)
        {
            this.DialogEnity = dialogEnity;
        }

        public IDialogEnity<TEntityId, TDialogStateMachineKey> DialogEnity { get; }

        protected Dictionary<TDialogStateMachineKey, DialogStateBase<TDialogStateMachineKey, TEntityId>> stateMap = new();

        public DialogStateBase<TDialogStateMachineKey, TEntityId>? CurrentState { get; protected set; }

        public bool ContainsState(TDialogStateMachineKey key)
        {
            return this.stateMap.ContainsKey(key);
        }

        public void AddState(TDialogStateMachineKey key, DialogStateBase<TDialogStateMachineKey, TEntityId> newState)
        {
            this.stateMap.Add(key, newState);
        }

        public DialogStateBase<TDialogStateMachineKey, TEntityId> GetState(TDialogStateMachineKey key)
        {
            return this.stateMap[key];
        }

        public void RemoveState(TDialogStateMachineKey key)
        {
            this.stateMap.Remove(key);
        }
    }
}