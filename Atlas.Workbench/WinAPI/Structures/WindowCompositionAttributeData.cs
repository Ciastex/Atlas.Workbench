using Atlas.Workbench.WinAPI.Enums;
using System;
using System.Runtime.InteropServices;

namespace Atlas.Workbench.WinAPI.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowCompositionAttributeData
    {
        public WindowCompositionAttribute Attribute;
        public IntPtr DataPointer;
        public int SizeOfData;
    }
}
