namespace My_CSharp2_bot.Architecture.Abstract
{
    internal abstract class DialogStateMachineBase<TEntityId, TDialogStateMachineKey>
        where TEntityId : notnull
        where TDialogStateMachineKey : notnull
    {
        public DialogStateMachineBase(IDialogEnity<TEntityId, TDialogStateMachineKey> dialogEnity)
        {
            this.DialogEnity = dialogEnity;
        }

        public IDialogEnity<TEntityId, TDialogStateMachineKey> DialogEnity { get; }

        protected Dictionary<TDialogStateMachineKey, DialogStateBase<TEntityId, TDialogStateMachineKey>> stateMap = new();

        public DialogStateBase<TEntityId, TDialogStateMachineKey>? CurrentState { get; protected set; }

        public bool ContainsState(TDialogStateMachineKey key)
        {
            return this.stateMap.ContainsKey(key);
        }

        public void AddState(TDialogStateMachineKey key, DialogStateBase<TEntityId, TDialogStateMachineKey> newState)
        {
            this.stateMap.Add(key, newState);
        }

        public DialogStateBase<TEntityId, TDialogStateMachineKey> GetState(TDialogStateMachineKey key)
        {
            return this.stateMap[key];
        }

        public void RemoveState(TDialogStateMachineKey key)
        {
            this.stateMap.Remove(key);
        }
    }
}