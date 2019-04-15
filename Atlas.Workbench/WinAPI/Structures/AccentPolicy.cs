using Atlas.Workbench.WinAPI.Enums;
using System.Runtime.InteropServices;

namespace Atlas.Workbench.WinAPI.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AccentPolicy
    {
        public AccentState State;
        public int Flags;
        public int GradientColor;
        public int AnimationId;
    }
}
