// Copyright 2008, 2009 - http://code.google.com/p/mfeditor/
//
// Author:   WanliYun 
// Email:    wanliyun2009@gmail.com
// QQ Group: 81979380
// Homepage: http://code.google.com/p/mfeditor/
//
//
// This file is part of MFEditor.
// MFEditor is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// MFEditor is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.

// You should have received a copy of the GNU Lesser General Public License
// along with MFEditor; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 


using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections.Specialized;

using OSGeo.MapServer;

using FusionMap.Geodatabase;
using FusionMap.DataSourcesFile;

namespace MFEditor.Utils
{
    public class Utility
    {
        ///<summary>
        ///get the temp.map path according to the input mapfile
        ///if the input path is "c:\\map\\work.map",the return 
        ///will be "c:\\map\\temp.map"
        ///tempmap is a copy of the current working mapfile
        ///<summary>
        ///<param name="filePath">the input path</param>
        ///<returns>the path of the temp.map</returns>
        public static string GetTempPath(string filePath)
        {
            if (filePath == "") 
                return Path.Combine(System.Windows.Forms.Application.StartupPath,"temp.map");

            string strDirectory = Path.GetDirectoryName(filePath);
            if(Directory.Exists(strDirectory))
                return Path.Combine(strDirectory, "temp.map");
            else
                return "";
        }

        /// <summary>
        /// post a question dialog
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DialogResult PostQuestion(string message)
        {
            return MessageBox.Show(message,
                    "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        /// <summary>
        /// post a message dialog
        /// </summary>
        /// <param name="message"></param>
        public static void PostMessage(string message)
        {
            MessageBox.Show(message,"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// post a warning message dialog
        /// </summary>
        /// <param name="message"></param>
        public static void PostWarning(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// check the input string is a valid path
        /// </summary>
        /// <param name="strPath">the input path</param>
        /// <returns>true:is a path false:is not a path</returns>
        public static bool IsInvalidPath(string strPath)
        {
            
            if (File.Exists(strPath))
                return true;
            else if (Directory.Exists(strPath))
                return true;
            else
                return false;

            //if (strPath.IndexOfAny(Path.GetInvalidPathChars()) != -1) return true;

            //string strDirectoryName = Path.Combine(
            //    Path.GetPathRoot(strPath) == null ? "" : Path.GetPathRoot(strPath),
            //    Path.GetDirectoryName(strPath) == null ? "" : Path.GetDirectoryName(strPath));
            //if (strDirectoryName == "") return true;
            //if (strPath.Replace(strDirectoryName, "").IndexOfAny(Path.GetInvalidFileNameChars()) != -1) return true;

            //return false;
        }


        /**/
        /// <summary>
        /// 获取路径2相对于路径1的相对路径
        /// </summary>
        /// <param name="strPath">路径1</param>
        /// <param name="strSubPath">路径2</param>
        /// <returns>返回路径2相对于路径1的路径</returns>
        /// <example>
        /// string strPath = GetRelativePath(@"C:\WINDOWS\system32", @"C:\WINDOWS\system\*.*" );
        /// //strPath == @"..\system\*.*"
        /// </example>
        public static string GetRelativePath(string strPath, string strSubPath)
        {
            if (!strPath.EndsWith("\\")) strPath += "\\";    //如果不是以"\"结尾的加上"\"
            int intIndex = -1, intPos = strPath.IndexOf('\\');
            ///以"\"为分界比较从开始处到第一个"\"处对两个地址进行比较,如果相同则扩展到
            ///下一个"\"处;直到比较出不同或第一个地址的结尾.
            while (intPos >= 0)
            {
                intPos++;
                if (string.Compare(strPath, 0, strSubPath, 0, intPos, true) != 0) break;
                intIndex = intPos;
                intPos = strPath.IndexOf('\\', intPos);
            }

            ///如果从不是第一个"\"处开始有不同,则从最后一个发现有不同的"\"处开始将strSubPath
            ///的后面部分付值给自己,在strPath的同一个位置开始望后计算每有一个"\"则在strSubPath
            ///的前面加上一个"..\"(经过转义后就是"..\\").
            if (intIndex >= 0)
            {
                strSubPath = strSubPath.Substring(intIndex);
                intPos = strPath.IndexOf("\\", intIndex);
                while (intPos >= 0)
                {
                    strSubPath = "..\\" + strSubPath;
                    intPos = strPath.IndexOf("\\", intPos + 1);
                }
            }
            //否则直接返回strSubPath
            return strSubPath;
        }


        /// <summary>
        /// 计算绝对路径
        /// </summary>
        /// <param name="absoluteDir">绝对目录</param>
        /// <param name="relativeFile">相对文件</param>
        /// <returns></returns>
        /// <example>
        /// @"D:\Windows\regedit.exe" = GetAbsolutePath(@"D:\Windows\Web\Wallpaper\", @"..\..\regedit.exe" );
        /// </example>
        public static string GetAbsolutePath(string absoluteDir, string relativeFile)
        {
            bool isNotOver = true;
            int intStart = 0;
            relativeFile=relativeFile.Replace("/", "\\");
            while (isNotOver)
            {
                if (relativeFile.StartsWith(@"..\"))
                {
                    relativeFile = relativeFile.Remove(0, 3);
                    intStart++;
                }
                else
                {
                    isNotOver = false;
                }
            }

            if (intStart > 0)
            {
                if (absoluteDir.EndsWith("\\"))
                {
                    absoluteDir = absoluteDir.Remove(absoluteDir.Length - 1);
                }

                for (int i = 0; i < intStart; i++)
                {
                    int iLastIndex = absoluteDir.LastIndexOf("\\");
                    if(iLastIndex > 0)
                        absoluteDir = absoluteDir.Remove(iLastIndex);
                    else
                        return "";
                }
            }
            return Path.Combine(absoluteDir, relativeFile);
        }

        //下面这个方法效率是楼上的1/50。。。
        //public static string GetAbsolutePath(string dir, string path) 
        //{ 
        //string strDir = Directory.GetCurrentDirectory(); 
        //Directory.SetCurrentDirectory(dir); 
        //string strNew = Path.GetFullPath(path); 
        //Directory.SetCurrentDirectory(strDir); 
        //return strNew; 
        //} 

        /// <summary>
        /// get all fields' name of the layer
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static StringCollection GetFieldsOfLayer(layerObj layer)
        {
            StringCollection pStringCollection = new StringCollection();            

            string strDataPath = GetAbsolutePathOfData(layer);

            IWorkspaceFactory pWsf = new ShapefileWorkspaceFactory();
            IWorkspace pWs = pWsf.OpenFromFile(Path.GetDirectoryName(strDataPath), 0);
            if (pWs != null)
            {
                IFeatureWorkspace pFws = pWs as IFeatureWorkspace;

                string strDataName = Path.GetFileNameWithoutExtension(strDataPath);

                IFeatureClass pFeatureClass = pFws.OpenFeatureClass(strDataName);
                if (pFeatureClass != null)
                {
                    IFields pFields = pFeatureClass.Fields;
                    if(pFields != null)
                    {
                        int iCount = pFields.FiledCount;
                        for (int i = 0; i < iCount; i++)
                        {
                            pStringCollection.Add(pFields.GetField(i).Name);
                        }
                    }
                    
                }
            }            

            return pStringCollection;
        }       

        public static string GetAbsolutePathOfData(layerObj layer)
        {
            if (layer == null)
                return "";
            //if the shapepath exist,combine the shapepath and data
            if (Path.IsPathRooted(layer.data))
                return layer.data;
            else
            {
                //判断是否存在shapepath路径
                if (Path.IsPathRooted(layer.map.shapepath))
                    return Path.Combine(layer.map.shapepath, layer.data);
                else
                {
                    string strPath = Utility.GetAbsolutePath(layer.map.mappath, layer.map.shapepath);
                    if (Directory.Exists(strPath))
                        return Path.Combine(strPath, layer.data);
                    else
                        return layer.data;
                }
            }
        }


    }
}
