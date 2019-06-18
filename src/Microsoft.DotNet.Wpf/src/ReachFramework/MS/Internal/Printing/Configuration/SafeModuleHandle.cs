// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

﻿/*++


 * Abstract:

    SafeHandle for HMODULE
 
--*/

namespace MS.Internal.Printing.Configuration
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    ///     Represents a module handle (HMODULE) used in API's like LoadLibrary
    /// </summary>
    /// <SecurityNote>
    ///     Critical: base class SafeHandleZeroOrMinusOneIsInvalid is critical
    /// </SecurityNote>
    internal class SafeModuleHandle : Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeModuleHandle()
            : base(true)
        {
        }

        /// <SecurityNote>
        ///     Critical: Calls native method to unload native module handle
        /// </SecurityNote>
        protected override bool ReleaseHandle()
        {
            return UnsafeNativeMethods.FreeLibrary(this.handle);
        }
    }
}
