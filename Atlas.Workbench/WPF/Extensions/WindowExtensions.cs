using Atlas.Workbench.WinAPI;
using Atlas.Workbench.WinAPI.Enums;
using Atlas.Workbench.WinAPI.Structures;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Atlas.Workbench.WPF.Extensions
{
    public static class WindowExtensions
    {
        public static void EnableFrostGlassEffect(this Window window)
        {
            var helper = new WindowInteropHelper(window);
            var accent = new AccentPolicy { State = AccentState.EnableBlurBehind };
            var accentSize = Marshal.SizeOf(accent);

            var accentPtr = Marshal.AllocHGlobal(accentSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData
            {
                Attribute = WindowCompositionAttribute.AccentPolicy,
                SizeOfData = accentSize,
                DataPointer = accentPtr
            };

            User32.SetWindowCompositionAttribute(helper.Handle, ref data);
            Marshal.FreeHGlobal(accentPtr);
        }
    }
}
