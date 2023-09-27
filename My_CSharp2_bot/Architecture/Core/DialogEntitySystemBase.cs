using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_CSharp2_bot.Architecture.Abstract
{
    internal abstract class DialogEntitySystemBase<TEntityId, TDialogStateMachineKey>
        where TEntityId : notnull
        where TDialogStateMachineKey : notnull
    {
        protected Dictionary<TEntityId, IDialogEnity<TEntityId, TDialogStateMachineKey>> entityMap = new();

        public void AddEntity(IDialogEnity<TEntityId, TDialogStateMachineKey> enity)
        {
            this.entityMap.Add(enity.Id, enity);
        }

        public bool ContainsEntity(TEntityId entityId)
        {
            return this.entityMap.ContainsKey(entityId);
        }

        public IDialogEnity<TEntityId, TDialogStateMachineKey> GetEnity(TEntityId entityId)
        {
            return this.entityMap[entityId];
        }

        public void RemoveEntity(TEntityId entityId)
        {
            this.entityMap.Remove(entityId);
        }
    }
}
