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
