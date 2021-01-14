//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Windows.Forms;

namespace Sys.Config
{
    /// <summary>
    /// ConfigHelper
    /// �����û������ļ����ࡣ
    /// 
    /// �޸ļ�¼
    ///
    ///		2008.06.08 �汾��1.3  �����޸�Ϊ ConfigHelper��
    ///		2008.04.22 �汾��1.2  ��ָ�����ļ���ȡ�����
    ///		2007.07.31 �汾��1.1  �淶�� FielName ������
    ///		2007.04.14 �汾��1.0  ר�Ŷ�ȡע�����࣬������д��ʽ�Ľ���
    ///		
    ///	�汾��1.2
    /// 
    /// <author>
    ///		<name></name>
    ///		<date>2008.04.22</date>
    /// </author> 
    /// </summary>
    public class ConfigHelper
    {
        public static string LogOnTo = "Config";

        public static string FileName
        {
            get
            {
                return LogOnTo + ".xml";
            }
        }

        public static string SelectPath = "//appSettings/add";

        public static string ConfigFielName
        {
            get
            {
                return FileName;
                // return Application.StartupPath + "\\" + FielName;
            }
        }

        #region public static Dictionary<String, String> GetLogOnTo() ��ȡ�����ļ�ѡ��
        /// <summary>
        /// ��ȡ�����ļ�ѡ��
        /// </summary>
        /// <returns>�����ļ�����</returns>
        public static Dictionary<String, String> GetLogOnTo()
        {
            Dictionary<String, String> returnValue = new Dictionary<String, String>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(ConfigFielName);
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes(SelectPath);
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals("LogOnTo".ToUpper()))
                {
                    returnValue.Add(xmlNode.Attributes["value"].Value, xmlNode.Attributes["dispaly"].Value);
                }
            }
            return returnValue;
        }
        #endregion      

        #region public static string GetValue(string key) ��ȡ������
        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <param name="key">��</param>
        /// <returns>ֵ</returns>
        public static string GetValue(string key)
        {
            return GetValue(ConfigFielName, SelectPath, key);
        }
        #endregion

        #region public static string GetValue(string fileName, string key) ��ȡ������
        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <param name="fileName">�����ļ�</param>
        /// <param name="key">��</param>
        /// <returns>ֵ</returns>
        public static string GetValue(string fileName, string key)
        {
            return GetValue(fileName, SelectPath, key);
        }
        #endregion

        #region public static string GetValue(string fileName, string selectPath, string key) ����������
        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <param name="fileName">�����ļ�</param>
        /// <param name="selectPath">��ѯ����</param>
        /// <param name="key">��</param>
        /// <returns>ֵ</returns>
        public static string GetValue(string fileName, string selectPath, string key)
        {
            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.Load(fileName);

            return GetValue(xmlDocument, selectPath, key);
        }
        #endregion

        #region public static string GetValue(XmlDocument xmlDocument, string key) ��ȡ������
        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <param name="xmlDocument">�����ļ�</param>
        /// <param name="key">��</param>
        /// <returns>ֵ</returns>
        public static string GetValue(XmlDocument xmlDocument, string key)
        {
            return GetValue(xmlDocument, SelectPath, key);
        }
        #endregion

        #region public static string GetValue(XmlDocument xmlDocument, string selectPath, string key) ����������
        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <param name="xmlDocument">�����ļ�</param>
        /// <param name="selectPath">��ѯ����</param>
        /// <param name="key">��</param>
        /// <returns>ֵ</returns>
        public static string GetValue(XmlDocument xmlDocument, string selectPath, string key)
        {
            string returnValue = string.Empty;
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes(selectPath);

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals(key.ToUpper()))
                {
                    returnValue = xmlNode.Attributes["value"].Value;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static void GetConfig() ��ȡ�����ļ�
        /// <summary>
        /// ��ȡ�����ļ�
        /// </summary>
        public static void GetConfig()
        {
            GetConfig(ConfigFielName);
        }
        #endregion

        #region public static void GetConfig(string fileName) ��ָ�����ļ���ȡ������
        /// <summary>
        /// ��ָ�����ļ���ȡ������
        /// </summary>
        /// <param name="fileName">�����ļ�</param>
        public static void GetConfig(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);

            // �ͻ���Ϣ����

            //   BaseSystemInfo.Version = GetValue(xmlDocument, BaseConfiguration.VERSION);

            //BaseSystemInfo.DbHelperClass = GetValue(xmlDocument, BaseConfiguration.DBHELPER_CLASSNAME);
            //BaseSystemInfo.DbHelperAssmely = GetValue(xmlDocument, BaseConfiguration.DBHELPER_ASSMELY);

            //BaseSystemInfo.LogOnAssembly = GetValue(xmlDocument, BaseConfiguration.LOGON_ASSEMBLY);
            //BaseSystemInfo.LogOnForm = GetValue(xmlDocument, BaseConfiguration.LOGON_FORM);
            //BaseSystemInfo.MainForm = GetValue(xmlDocument, BaseConfiguration.MAIN_FORM);

            // �����ݿ�����
            BaseSystemInfo.BusinessDbConnectionString = GetValue(xmlDocument, BaseConfiguration.BUSINESS_DBCONNECTION);
            BaseSystemInfo.ServerDbConnectionString = GetValue(xmlDocument, BaseConfiguration.SERVER_DBCONNECTION);

            BaseSystemInfo.BusinessDbConnection = BaseSystemInfo.BusinessDbConnectionString;
            BaseSystemInfo.ServerDbConnection = BaseSystemInfo.ServerDbConnectionString;

            BaseSystemInfo.DataBaseType = GetValue(xmlDocument, BaseConfiguration.DATABASE_TYPE);


            //ϵͳ���
            BaseSystemInfo.CompanyID = GetValue(xmlDocument, BaseConfiguration.COMPANYID);
            BaseSystemInfo.CompanyCode = GetValue(xmlDocument, BaseConfiguration.COMPANYCODE);
            BaseSystemInfo.CompanyName = GetValue(xmlDocument, BaseConfiguration.COMPANYNAME);
            BaseSystemInfo.FactoryID = GetValue(xmlDocument, BaseConfiguration.FACTORYID);
            BaseSystemInfo.FactoryCode = GetValue(xmlDocument, BaseConfiguration.FACTORYCODE);
            BaseSystemInfo.FactoryName = GetValue(xmlDocument, BaseConfiguration.FACTORYNAME);
            BaseSystemInfo.ProductLineID = GetValue(xmlDocument, BaseConfiguration.PRODUCTLINEID);
            BaseSystemInfo.ProductLineCode = GetValue(xmlDocument, BaseConfiguration.PRODUCTLINECODE);
            BaseSystemInfo.ProductLineName = GetValue(xmlDocument, BaseConfiguration.PRODUCTLINENAME);

            //��¼�������顢���
            BaseSystemInfo.CurrentUserID = GetValue(xmlDocument, BaseConfiguration.CURRENTUSERID);
            BaseSystemInfo.CurrentUserCode = GetValue(xmlDocument, BaseConfiguration.CURRENTUSERCODE);
            BaseSystemInfo.CurrentUserName = GetValue(xmlDocument, BaseConfiguration.CURRENTUSERNAME);
            BaseSystemInfo.CurrentClassCode = GetValue(xmlDocument, BaseConfiguration.CURRENTCLASSCODE);
            BaseSystemInfo.CurrentClassName = GetValue(xmlDocument, BaseConfiguration.CURRENTCLASSNAME);
            BaseSystemInfo.CurrentShiftCode = GetValue(xmlDocument, BaseConfiguration.CURRENTSHIFTCODE);
            BaseSystemInfo.CurrentShiftName = GetValue(xmlDocument, BaseConfiguration.CURRENTSHIFTNAME);
            //ϵͳ����
            BaseSystemInfo.SystemType = int.Parse(GetValue(xmlDocument, BaseConfiguration.SYSTEMTYPE));


            //PLC���
            BaseSystemInfo.PLCType = GetValue(xmlDocument, BaseConfiguration.PLCTYPE);

            BaseSystemInfo.MasterPLCIP_First = GetValue(xmlDocument, BaseConfiguration.MASTERPLCIP_FIRST);
            BaseSystemInfo.MasterPLCIP_Sencond = GetValue(xmlDocument, BaseConfiguration.MASTERPLCIP_SENCOND);

            BaseSystemInfo.MasterPLCStation_First = GetValue(xmlDocument, BaseConfiguration.MASTERPLCSTATION_FIRST);
            BaseSystemInfo.MasterPLCStation_Sencond = GetValue(xmlDocument, BaseConfiguration.MASTERPLCSTATION_SENCOND);

            BaseSystemInfo.MasterPLCIP1 = GetValue(xmlDocument, BaseConfiguration.MASTERPLCIP1);
            BaseSystemInfo.MasterPLCIP2 = GetValue(xmlDocument, BaseConfiguration.MASTERPLCIP2);

            BaseSystemInfo.DownBlockNo = int.Parse(GetValue(xmlDocument, BaseConfiguration.DOWNBLOCKNO));
            BaseSystemInfo.DownAddressNo = int.Parse(GetValue(xmlDocument, BaseConfiguration.DOWNADDRESSNO));

            //����
            BaseSystemInfo.CurrentProcessCode = GetValue(xmlDocument, BaseConfiguration.CURRENTPROCESSCODE);
            BaseSystemInfo.CurrentProcessName = GetValue(xmlDocument, BaseConfiguration.CURRENTPROCESSNAME);

            //COM
            BaseSystemInfo.SerialPortName1 = GetValue(xmlDocument, BaseConfiguration.SERIALPORTNAME1);
            BaseSystemInfo.SerialPortName2 = GetValue(xmlDocument, BaseConfiguration.SERIALPORTNAME2);

            BaseSystemInfo.BarScanProIP = GetValue(xmlDocument, BaseConfiguration.BARSCANPROIP);
            BaseSystemInfo.BarScanProPort = GetValue(xmlDocument, BaseConfiguration.BARSCANPROPORT);

            BaseSystemInfo.AreaCode = GetValue(xmlDocument, BaseConfiguration.AREACODE);

            BaseSystemInfo.selectMaterialStr = GetValue(xmlDocument, BaseConfiguration.SELECTMATERIALSTR);

            BaseSystemInfo.RFIDIP = GetValue(xmlDocument, BaseConfiguration.RFIDIP);
            BaseSystemInfo.RFIDPort = GetValue(xmlDocument, BaseConfiguration.RFIDPORT);
            BaseSystemInfo.INRFIDIP = GetValue(xmlDocument, BaseConfiguration.INRFIDIP);
            BaseSystemInfo.INRFIDPort = GetValue(xmlDocument, BaseConfiguration.INRFIDPORT);
            BaseSystemInfo.OUTRFIDIP = GetValue(xmlDocument, BaseConfiguration.OUTRFIDIP);
            BaseSystemInfo.OUTRFIDPort = GetValue(xmlDocument, BaseConfiguration.OUTRFIDPORT);

            BaseSystemInfo.CurrentINStoreCode = GetValue(xmlDocument, BaseConfiguration.CURRENTINSTORECODE);
            BaseSystemInfo.RKAddress1 = int.Parse(GetValue(xmlDocument, BaseConfiguration.RKADDRESS1));
            BaseSystemInfo.RKAddress2 = int.Parse(GetValue(xmlDocument,BaseConfiguration.RKADDRESS2));
            BaseSystemInfo.RKLen = int.Parse(GetValue(xmlDocument, BaseConfiguration.RKLEN));
            BaseSystemInfo.BDAddress = int.Parse(GetValue(xmlDocument, BaseConfiguration.BDADDRESS));
            BaseSystemInfo.BDLen = int.Parse(GetValue(xmlDocument, BaseConfiguration.BDLEN));
            BaseSystemInfo.INRAddress = int.Parse(GetValue(xmlDocument, BaseConfiguration.INRADDRESS));
            BaseSystemInfo.INRLen = int.Parse(GetValue(xmlDocument, BaseConfiguration.INRLEN));
            BaseSystemInfo.Maddress = int.Parse(GetValue(xmlDocument, BaseConfiguration.MADDRESS));
            BaseSystemInfo.Mlen = int.Parse(GetValue(xmlDocument, BaseConfiguration.MLEN));
            BaseSystemInfo.Naddress = int.Parse(GetValue(xmlDocument, BaseConfiguration.NADDRESS));
            BaseSystemInfo.Nlen = int.Parse(GetValue(xmlDocument, BaseConfiguration.NLEN));
            BaseSystemInfo.KCaddress = int.Parse(GetValue(xmlDocument, BaseConfiguration.KCADDRESS));
            BaseSystemInfo.CKAddress = int.Parse(GetValue(xmlDocument, BaseConfiguration.CKADDRESS));
            BaseSystemInfo.CKLen = int.Parse(GetValue(xmlDocument, BaseConfiguration.CKLEN));
            BaseSystemInfo.RKWCAddress = int.Parse(GetValue(xmlDocument, BaseConfiguration.RKWCADDRESS));
            BaseSystemInfo.RKWCLen = int.Parse(GetValue(xmlDocument, BaseConfiguration.RKWCLEN));
            BaseSystemInfo.FWaddress = int.Parse(GetValue(xmlDocument, BaseConfiguration.FWADDRESS));
            BaseSystemInfo.FWlen = int.Parse(GetValue(xmlDocument, BaseConfiguration.FWLEN));

            BaseSystemInfo.YXJaddress = int.Parse(GetValue(xmlDocument, BaseConfiguration.YXJADDRESS));
            BaseSystemInfo.YXJlen = int.Parse(GetValue(xmlDocument, BaseConfiguration.YXJLEN));

            BaseSystemInfo.FPAddress = int.Parse(GetValue(xmlDocument, BaseConfiguration.FPADDRESS));
            BaseSystemInfo.MMAddress = int.Parse(GetValue(xmlDocument, BaseConfiguration.MMADDRESS));
            BaseSystemInfo.MCXFlag = int.Parse(GetValue(xmlDocument, BaseConfiguration.MCXFLAG));
            BaseSystemInfo.WLaddress = int.Parse(GetValue(xmlDocument, BaseConfiguration.WLADDRESS));
            BaseSystemInfo.WLlen = int.Parse(GetValue(xmlDocument, BaseConfiguration.WLLEN));
            //������


            for (int i = 0; i < 15; i++)
            {
                BaseSystemInfo.BarScanInfoList[i].BarIP = GetValue(xmlDocument, "BarScanIP" + (i + 1).ToString()); 
                BaseSystemInfo.BarScanInfoList[i].BarPort = GetValue(xmlDocument, "BarScanPort" + (i + 1).ToString()); 
            }

        }

        private static string GetValue(XmlDocument xmlDocument, object mCXFLAG)
        {
            throw new NotImplementedException();
        }
        #endregion

        public static bool SetValue(string key, string keyValue)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(ConfigFielName);

            bool ret = SetValue(xmlDocument, SelectPath, key, keyValue);

            xmlDocument.Save(ConfigFielName);
            return ret;
        }

        public static bool SetValue(XmlDocument xmlDocument, string key, string keyValue)
        {
            return SetValue(xmlDocument, SelectPath, key, keyValue);
        }

        public static bool SetValue(XmlDocument xmlDocument, string selectPath, string key, string keyValue)
        {
            bool returnValue = false;
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes(selectPath);
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals(key.ToUpper()))
                {
                    xmlNode.Attributes["value"].Value = keyValue;
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }

        #region public static void SaveConfig() ���������ļ�

        /// <summary>
        /// ���������ļ�
        /// </summary>
        public static void SaveConfig()
        {
            SaveConfig(ConfigFielName);
        }
        #endregion

        #region public static void SaveConfig(string fileName) ���浽ָ�����ļ�
        /// <summary>
        /// ���浽ָ�����ļ�
        /// </summary>
        /// <param name="fileName">�����ļ�</param>
        public static void SaveConfig(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);

            // �ͻ���Ϣ����

            //  SetValue(xmlDocument, BaseConfiguration.CURRENT_PASSWORD, BaseSystemInfo.CurrentPassword);

            ////  SetValue(xmlDocument, BaseConfiguration.VERSION, BaseSystemInfo.Version);

            //  SetValue(xmlDocument, BaseConfiguration.LOGON_ASSEMBLY, BaseSystemInfo.LogOnAssembly);
            //  SetValue(xmlDocument, BaseConfiguration.LOGON_FORM, BaseSystemInfo.LogOnForm);
            //  SetValue(xmlDocument, BaseConfiguration.MAIN_FORM, BaseSystemInfo.MainForm);

            SetValue(xmlDocument, BaseConfiguration.BUSINESS_DBCONNECTION, BaseSystemInfo.BusinessDbConnectionString);
            SetValue(xmlDocument, BaseConfiguration.SERVER_DBCONNECTION, BaseSystemInfo.ServerDbConnectionString);

            SetValue(xmlDocument, BaseConfiguration.DATABASE_TYPE, BaseSystemInfo.DataBaseType.ToString());


            //ϵͳ���
            SetValue(xmlDocument, BaseConfiguration.COMPANYID, BaseSystemInfo.CompanyID);
            SetValue(xmlDocument, BaseConfiguration.COMPANYCODE, BaseSystemInfo.CompanyCode);
            SetValue(xmlDocument, BaseConfiguration.COMPANYNAME, BaseSystemInfo.CompanyName);

            SetValue(xmlDocument, BaseConfiguration.FACTORYID, BaseSystemInfo.FactoryID);
            SetValue(xmlDocument, BaseConfiguration.FACTORYCODE, BaseSystemInfo.FactoryCode);
            SetValue(xmlDocument, BaseConfiguration.FACTORYNAME, BaseSystemInfo.FactoryName);

            SetValue(xmlDocument, BaseConfiguration.PRODUCTLINEID, BaseSystemInfo.ProductLineID);
            SetValue(xmlDocument, BaseConfiguration.PRODUCTLINECODE, BaseSystemInfo.ProductLineCode);
            SetValue(xmlDocument, BaseConfiguration.PRODUCTLINENAME, BaseSystemInfo.ProductLineName);

            //��¼�û�������κͰ���
            SetValue(xmlDocument, BaseConfiguration.CURRENTUSERID, BaseSystemInfo.CurrentUserID);
            SetValue(xmlDocument, BaseConfiguration.CURRENTUSERCODE, BaseSystemInfo.CurrentUserCode);
            SetValue(xmlDocument, BaseConfiguration.CURRENTUSERNAME, BaseSystemInfo.CurrentUserName);
            SetValue(xmlDocument, BaseConfiguration.CURRENTCLASSCODE, BaseSystemInfo.CurrentClassCode);
            SetValue(xmlDocument, BaseConfiguration.CURRENTCLASSNAME, BaseSystemInfo.CurrentClassName);
            SetValue(xmlDocument, BaseConfiguration.CURRENTSHIFTCODE, BaseSystemInfo.CurrentShiftCode);
            SetValue(xmlDocument, BaseConfiguration.CURRENTSHIFTNAME, BaseSystemInfo.CurrentShiftName);
            xmlDocument.Save(fileName);
        }

        public static void CheckNodeExists(string KeyName, string DefaultValue) //�鿴�Ƿ��������ֵ
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigFielName);

            XmlNodeList xmlNodeList = xmlDoc.SelectNodes(SelectPath);

            bool ExistsFlag = false;
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals(KeyName.ToUpper()))
                {
                    ExistsFlag = true;
                    break;
                }
            }

            if (!ExistsFlag)
            {
                XmlNode NodeList = xmlDoc.SelectSingleNode("configuration/appSettings");
                XmlElement member = xmlDoc.CreateElement("add");
                member.SetAttribute("key", KeyName);
                member.SetAttribute("value", DefaultValue);

                NodeList.AppendChild(member);
                xmlDoc.Save(ConfigFielName);
            }

        }


        #endregion
    }
}