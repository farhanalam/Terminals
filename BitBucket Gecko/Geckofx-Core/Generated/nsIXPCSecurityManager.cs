// --------------------------------------------------------------------------------------------
// Version: MPL 1.1/GPL 2.0/LGPL 2.1
// 
// The contents of this file are subject to the Mozilla Public License Version
// 1.1 (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at
// http://www.mozilla.org/MPL/
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
// for the specific language governing rights and limitations under the
// License.
// 
// <remarks>
// Generated by IDLImporter from file nsIXPCSecurityManager.idl
// 
// You should use these interfaces when you access the COM objects defined in the mentioned
// IDL/IDH file.
// </remarks>
// --------------------------------------------------------------------------------------------
namespace Gecko
{
	using System;
	using System.Runtime.InteropServices;
	using System.Runtime.InteropServices.ComTypes;
	using System.Runtime.CompilerServices;
	
	
	/// <summary>
    ///-*- Mode: C; tab-width: 8; indent-tabs-mode: nil; c-basic-offset: 4 -*-
    ///
    /// This Source Code Form is subject to the terms of the Mozilla Public
    /// License, v. 2.0. If a copy of the MPL was not distributed with this
    /// file, You can obtain one at http://mozilla.org/MPL/2.0/. </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("d4d21714-116b-4851-a785-098c5dfea523")]
	public interface nsIXPCSecurityManager
	{
		
		/// <summary>
        /// For each of these hooks returning NS_OK means 'let the action continue'.
        /// Returning an error code means 'veto the action'. XPConnect will return
        /// false to the js engine if the action is vetoed. The implementor of this
        /// interface is responsible for setting a JS exception into the JSContext
        /// if that is appropriate.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void CanCreateWrapper(System.IntPtr aJSContext, ref System.Guid aIID, [MarshalAs(UnmanagedType.Interface)] nsISupports aObj, [MarshalAs(UnmanagedType.Interface)] nsIClassInfo aClassInfo);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void CanCreateInstance(System.IntPtr aJSContext, ref System.Guid aCID);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void CanGetService(System.IntPtr aJSContext, ref System.Guid aCID);
	}
}
