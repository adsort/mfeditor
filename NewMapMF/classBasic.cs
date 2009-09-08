using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MFEditor
{
    class classBasic
    {
        private string m_strDefaultDir = @"D:\Platform_Data\JiaXing";
        public static MFEditorLib.MapPropertys m_pMapProperty = null;
        //返回设置缺省目录
        public string DefaultDir
        {
            get
            {
                return m_strDefaultDir;
            }
            set
            {              
                m_strDefaultDir = value;
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

                    if (strName == "LastDirPath")
                        m_strDefaultDir = myReader.ReadString();                    
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
            myWriter.WriteElementString("LastDirPath", m_strDefaultDir);            
            myWriter.WriteEndElement();
            myWriter.WriteEndDocument();
            myWriter.Close();


        }

    }
}
