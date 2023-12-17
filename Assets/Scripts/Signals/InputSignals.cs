using Extentions;
using Keys;
using UnityEngine.Events;

namespace Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
       public UnityAction<RunnerHorizontalInputParams> onInputDragged = delegate { };
       public UnityAction<IdleInputParams> onIdleInputTaken = delegate { };
       public UnityAction<bool> onSidewaysEnable = delegate { };
    }
}


