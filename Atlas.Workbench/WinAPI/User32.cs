using Atlas.Workbench.WinAPI.Structures;
using System;
using System.Runtime.InteropServices;

namespace Atlas.Workbench.WinAPI
{
    public static class User32
    {
        [DllImport("user32.dll")]
        public static extern bool GetWindowCompositionAttribute(IntPtr windowHandle, ref WindowCompositionAttributeData data);

        [DllImport("user32.dll")]
        public static extern bool SetWindowCompositionAttribute(IntPtr windowHandle, ref WindowCompositionAttributeData data);
    }
}
