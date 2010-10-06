// Copyright 2008, 2010 - http://code.google.com/p/mfeditor/
//
// Author:   WanliYun 
// Email:    wanliyun2009@gmail.com
// QQ Group: 81979380
// Blog:     http://blog.csdn.net/wanliyun2009
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
using System.Xml;

namespace MFEditorUI
{
    class classBasic
    {
        //default data path
        private string m_strDefaultDataPath = @"D:\Work\mapfiletools\gmap\data";
        //default map path
        private string m_strDefaultMapPath = @"D:\Work\mapfiletools\gmap\htdocs";
        //public static MFEditorLib.MapPropertys m_pMapProperty = null;
        //返回设置缺省data目录
        public string DefaultDataPath
        {
            get
            {
                return m_strDefaultDataPath;
            }
            set
            {
                m_strDefaultDataPath = value;
            }
        }


        //返回设置缺省map目录
        public string DefaultMapPath
        {
            get
            {
                return m_strDefaultMapPath;
            }
            set
            {
                m_strDefaultMapPath = value;
            }
        }
       

        //读取以前保存的xml设置
        public void ReadSetXML()
        {
            string strCurPath = System.Windows.Forms.Application.StartupPath;
            string strSetPath = strCurPath + "\\SYSSET.xml";   

            if (System.IO.File.Exists(strSetPath))
            {
                XmlTextReader myReader = new XmlTextReader(strSetPath);


                while (myReader.Read())
                {
                    string strName = myReader.LocalName;

                    if (strName == "DefaultDataPath")
                        m_strDefaultDataPath = myReader.ReadString();

                    if (strName == "DefaultMapPath")
                        m_strDefaultMapPath = myReader.ReadString();    
                }

                myReader.Close();
            }
        }

        //保存当前的配置到xml文件中
        public void SaveSetXML()
        {
            string strCurPath = System.Windows.Forms.Application.StartupPath;
            string strSetPath = strCurPath + "\\SYSSET.xml";

            XmlTextWriter myWriter = new XmlTextWriter(strSetPath, null);
            myWriter.WriteStartDocument();
            myWriter.WriteStartElement("INFO");
            //myWriter.WriteComment("保存系统的配置信息");           
            //myWriter.WriteEndElement();
            myWriter.WriteElementString("DefaultDataPath", m_strDefaultDataPath);
            myWriter.WriteElementString("DefaultMapPath", m_strDefaultMapPath);     
            myWriter.WriteEndElement();
            myWriter.WriteEndDocument();
            myWriter.Close();


        }

    }
}
