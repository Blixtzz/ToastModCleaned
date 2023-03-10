using Harmony;
using UnityEngine;

namespace ToastModCleaned.Controls
{
    public abstract class BaseModule
    {
        public virtual void OnUpdate()
        {
        }
        public virtual void OnPlayerJoin(VRC.Player player)
        {
        }
        public virtual void OnPlayerLeft(VRC.Player player)
        {
        }
        public virtual void Init()
        {
        }
    }
}