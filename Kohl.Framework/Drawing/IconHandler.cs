﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Reflection;
using System.IO;

namespace Kohl.Framework.Drawing
{
    struct SHFILEINFO
    {
        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };

    public enum IconSize : uint
    {
        Large = 0x0,  //32x32
        Small = 0x1 //16x16		
    }

    //the function that will extract the icons from a file
    public static class IconHandler
    {
        const uint SHGFI_ICON = 0x100;
        const uint SHGFI_USEFILEATTRIBUTES = 0x10;

        [DllImport("Shell32", CharSet = CharSet.Auto)]
        internal extern static int ExtractIconEx(
            [MarshalAs(UnmanagedType.LPTStr)]
            string lpszFile,                //size of the icon
            int nIconIndex,                 //index of the icon (in case we have more then 1 icon in the file
            IntPtr[] phIconLarge,           //32x32 icon
            IntPtr[] phIconSmall,           //16x16 icon
            int nIcons);                    //how many to get

        [DllImport("shell32.dll")]
        static extern IntPtr SHGetFileInfo(
            string pszPath,             //path
            uint dwFileAttributes,      //attributes
            ref SHFILEINFO psfi,        //struct pointer
            uint cbSizeFileInfo,        //size
            uint uFlags);	//flags

        //we need this function to release the unmanaged resource,
        //the unmanaged resource will be copies to a managed one and it will be returned.
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);

        //will return an array of icons 
        public static Icon[] IconsFromFile(string Filename, IconSize Size = IconSize.Large)
        {
            int IconCount = ExtractIconEx(Filename, -1, null, null, 0); //checks how many icons.
            IntPtr[] IconPtr = new IntPtr[IconCount];
            Icon TempIcon;

            //extracts the icons by the size that was selected.
            if (Size == IconSize.Small)
                ExtractIconEx(Filename, 0, null, IconPtr, IconCount);
            else
                ExtractIconEx(Filename, 0, IconPtr, null, IconCount);

            Icon[] IconList = new Icon[IconCount];

            //gets the icons in a list.
            for (int i = 0; i < IconCount; i++)
            {
                TempIcon = (Icon)Icon.FromHandle(IconPtr[i]);
                IconList[i] = GetManagedIcon(ref TempIcon);
            }

            return IconList;
        }

        //extract one selected by index icon from a file.
        public static Icon IconFromFile(string Filename, IconSize Size, int Index)
        {
            int IconCount = ExtractIconEx(Filename, -1, null, null, 0); //checks how many icons.
            if (IconCount <= 0 || Index >= IconCount) return null; // no icons were found.

            Icon TempIcon;
            IntPtr[] IconPtr = new IntPtr[1];

            //extracts the icon that we want in the selected size.
            if (Size == IconSize.Small)
                ExtractIconEx(Filename, Index, null, IconPtr, 1);
            else
                ExtractIconEx(Filename, Index, IconPtr, null, 1);

            TempIcon = Icon.FromHandle(IconPtr[0]);

            return GetManagedIcon(ref TempIcon);
        }
        
        public static Icon IconFromExtension(string Extension, IconSize Size)
        {
            try
            {
                Icon TempIcon;

                //add '.' if nessesry
                if (Extension[0] != '.') Extension = '.' + Extension;

                //temp struct for getting file shell info
                SHFILEINFO TempFileInfo = new SHFILEINFO();

                SHGetFileInfo(
                    Extension,
                    0,
                    ref TempFileInfo,
                    (uint)Marshal.SizeOf(TempFileInfo),
                    SHGFI_ICON | SHGFI_USEFILEATTRIBUTES | (uint)Size);

                TempIcon = (Icon)Icon.FromHandle(TempFileInfo.hIcon);
                return GetManagedIcon(ref TempIcon);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("error while trying to get icon for " + Extension + " :" + e.Message);
                return null;
            }
        }

        /*
         * this is the built in funcion provided by .Net framework for getting a file icon,
         * i thought it's worth mentioning.
         * 
        public static Icon IconFromExtension(string Filename)
        {
            return Icon.ExtractAssociatedIcon(Filename);
        }
        */
       
       public static string ImageToBase64(this Image image, System.Drawing.Imaging.ImageFormat format)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				// Convert Image to byte[]
				image.Save(ms, format);
				byte[] imageBytes = ms.ToArray();
				
				// Convert byte[] to Base64 String
				string base64String = Convert.ToBase64String(imageBytes);
				return base64String;
			}
		}
       
       public static Image Base64ToImage(this string base64String)
		{
			// Convert Base64 String to byte[]
			byte[] imageBytes = Convert.FromBase64String(base64String);
			MemoryStream ms = new MemoryStream(imageBytes, 0, 
			imageBytes.Length);
			
			// Convert byte[] to Image
			ms.Write(imageBytes, 0, imageBytes.Length);
			Image image = Image.FromStream(ms, true);
			return image;
		}

        public static Icon IconFromResource(string ResourceName)
        {
            Assembly TempAssembly = Assembly.GetCallingAssembly();

            return new Icon(TempAssembly.GetManifestResourceStream(ResourceName));
        }

        public static void SaveIconFromImage(Image SourceImage, string IconFilename, IconSize DestenationIconSize)
        {
            Size NewIconSize = DestenationIconSize == IconSize.Large ? new Size(32, 32) : new Size(16, 16);

            Bitmap RawImage = new Bitmap(SourceImage, NewIconSize);
            Icon TempIcon = Icon.FromHandle(RawImage.GetHicon());
            FileStream NewIconStream = new FileStream(IconFilename, FileMode.Create);

            TempIcon.Save(NewIconStream);

            NewIconStream.Close();
        }

        public static void SaveIcon(Icon SourceIcon, string IconFilename)
        {
            FileStream NewIconStream = new FileStream(IconFilename, FileMode.Create);

            SourceIcon.Save(NewIconStream);

            NewIconStream.Close();
        }

        public static Icon GetManagedIcon(ref Icon UnmanagedIcon)
        {
            Icon ManagedIcon = (Icon)UnmanagedIcon.Clone();

            DestroyIcon(UnmanagedIcon.Handle);

            return ManagedIcon;
        }
    }
}
