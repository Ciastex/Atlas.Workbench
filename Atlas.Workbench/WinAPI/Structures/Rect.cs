using System.Runtime.InteropServices;

namespace Atlas.Workbench.WinAPI.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}
