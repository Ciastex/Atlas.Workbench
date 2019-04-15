using System.Runtime.InteropServices;

namespace Atlas.Workbench.WinAPI.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int X;
        public int Y;
    }
}
