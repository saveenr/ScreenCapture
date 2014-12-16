using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace ScreenCaptureLib.Interop
{
    [System.Security.Permissions.SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
    public class IconHandle : SafeHandle
    {
        [SecurityCritical, SecurityTreatAsSafe]
        public IconHandle()
            : base(IntPtr.Zero, true)
        {
        }

        [SecurityCritical]
        protected override bool ReleaseHandle()
        {
            return User32.DestroyIcon(base.handle);
        }

        public override bool IsInvalid
        {
            [SecurityCritical, SecurityTreatAsSafe]
            get
            {
                return (base.handle == IntPtr.Zero);
            }
        }
    }
}