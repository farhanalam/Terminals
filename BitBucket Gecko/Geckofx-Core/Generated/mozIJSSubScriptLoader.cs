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
// Generated by IDLImporter from file mozIJSSubScriptLoader.idl
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
    ///-*- Mode: C++; tab-width: 4; indent-tabs-mode: nil; c-basic-offset: 4 -*-
    ///
    /// This Source Code Form is subject to the terms of the Mozilla Public
    /// License, v. 2.0. If a copy of the MPL was not distributed with this
    /// file, You can obtain one at http://mozilla.org/MPL/2.0/. </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("b21f1579-d994-4e99-a85d-a685140f3ec1")]
	public interface mozIJSSubScriptLoader
	{
		
		/// <summary>
        /// This method should only be called from JS!
        /// In JS, the signature looks like:
        /// rv loadSubScript (url [, obj] [, charset]);
        /// @param url the url of the sub-script, it MUST be either a file:,
        /// resource:, or chrome: url, and MUST be local.
        /// @param obj an optional object to evaluate the script onto, it
        /// defaults to the global object of the caller.
        /// @param charset optionally specifies the character encoding of
        /// the file. If absent, the file is interpreted
        /// as ASCII.
        /// @retval rv the value returned by the sub-script
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		Gecko.JsVal LoadSubScript([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase url, Gecko.JsVal obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase charset, System.IntPtr jsContext);
		
		/// <summary>
        /// This method should only be called from JS!
        /// In JS, the signature looks like:
        /// rv = loadSubScript (url, optionsObject)
        /// @param url the url of the sub-script, it MUST be either a file:,
        /// resource:, or chrome: url, and MUST be local.
        /// @param optionsObject an object with parameters. Valid parameters are:
        /// - charset: specifying the character encoding of the file (default: ASCII)
        /// - target:  an object to evaluate onto (default: global object of the caller)
        /// - ignoreCache: if set to true, will bypass the cache for reading the file.
        /// @retval rv the value returned by the sub-script
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		Gecko.JsVal LoadSubScriptWithOptions([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase url, Gecko.JsVal options, System.IntPtr jsContext);
	}
}