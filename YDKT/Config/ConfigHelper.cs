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

            // �����ݿ�����
            BaseSystemInfo.BusinessDbConnectionString = GetValue(xmlDocument, BaseConfiguration.BUSINESS_DBCONNECTION);
            BaseSystemInfo.ServerDbConnectionString = GetValue(xmlDocument, BaseConfiguration.SERVER_DBCONNECTION);

            BaseSystemInfo.BusinessDbConnection = BaseSystemInfo.BusinessDbConnectionString;
            BaseSystemInfo.ServerDbConnection = BaseSystemInfo.ServerDbConnectionString;

            BaseSystemInfo.DataBaseType = GetValue(xmlDocument, BaseConfiguration.DATABASE_TYPE);

            // �����������
            BaseSystemInfo.AutoUpdateIP = GetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATEIP);
            BaseSystemInfo.AutoUpdatePort = GetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATEPORT);
            BaseSystemInfo.AutoUpdateDir = GetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATEDIR);
            BaseSystemInfo.AutoExecuteName = GetValue(xmlDocument, BaseConfiguration.APP_AUTOEXECUTENAME);
            BaseSystemInfo.UpdateInterval = int.Parse(GetValue(xmlDocument, BaseConfiguration.APP_UPDATEINTERVAL));
            BaseSystemInfo.AutoUpdateFinish = (String.Compare(GetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATEFINISH), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            BaseSystemInfo.AutoUpdateSuccess = (String.Compare(GetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATESUCCESS), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            BaseSystemInfo.App_Version = GetValue(xmlDocument, BaseConfiguration.APP_VERSION);
            //��֤���
            BaseSystemInfo.RunLogin = (String.Compare(GetValue(xmlDocument, BaseConfiguration.RUN_LOGIN), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            BaseSystemInfo.RunLogout = (String.Compare(GetValue(xmlDocument, BaseConfiguration.RUN_LOGOUT), "TRUE", true, CultureInfo.CurrentCulture) == 0);

            //ϵͳ���
            BaseSystemInfo.CompanyID = GetValue(xmlDocument, BaseConfiguration.COMPANYID);
            BaseSystemInfo.CompanyCode = GetValue(xmlDocument, BaseConfiguration.COMPANYCODE);
            BaseSystemInfo.CompanyName = GetValue(xmlDocument, BaseConfiguration.COMPANYNAME);
            BaseSystemInfo.CompanyName_EN = GetValue(xmlDocument, BaseConfiguration.COMPANYNAME_EN);

            BaseSystemInfo.FactoryID = GetValue(xmlDocument, BaseConfiguration.FACTORYID);
            BaseSystemInfo.FactoryCode = GetValue(xmlDocument, BaseConfiguration.FACTORYCODE);
            BaseSystemInfo.FactoryName = GetValue(xmlDocument, BaseConfiguration.FACTORYNAME);
            BaseSystemInfo.FactoryName_EN = GetValue(xmlDocument, BaseConfiguration.FACTORYNAME_EN);

            BaseSystemInfo.ProductLineID = GetValue(xmlDocument, BaseConfiguration.PRODUCTLINEID);
            BaseSystemInfo.ProductLineCode = GetValue(xmlDocument, BaseConfiguration.PRODUCTLINECODE);
            BaseSystemInfo.ProductLineName = GetValue(xmlDocument, BaseConfiguration.PRODUCTLINENAME);
            BaseSystemInfo.ProductLineName_EN = GetValue(xmlDocument, BaseConfiguration.PRODUCTLINENAME_EN);
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

            //����
            BaseSystemInfo.CurrentProcessCode = GetValue(xmlDocument, BaseConfiguration.CURRENTPROCESSCODE);
            BaseSystemInfo.CurrentProcessName = GetValue(xmlDocument, BaseConfiguration.CURRENTPROCESSNAME);
            BaseSystemInfo.CurrentProcessName_EN = GetValue(xmlDocument, BaseConfiguration.CURRENTPROCESSNAME_EN);
            BaseSystemInfo.CurrentPlanName = GetValue(xmlDocument, BaseConfiguration.CURRENTPLANNAME);
            //վ��
            BaseSystemInfo.CurrentStationNo1 = GetValue(xmlDocument, BaseConfiguration.CURRENTSTATIONNO1);
            BaseSystemInfo.CurrentStationNo2 = GetValue(xmlDocument, BaseConfiguration.CURRENTSTATIONNO2);
            BaseSystemInfo.CurrentStationNo3 = GetValue(xmlDocument, BaseConfiguration.CURRENTSTATIONNO3);
            BaseSystemInfo.CurrentStationNo4 = GetValue(xmlDocument, BaseConfiguration.CURRENTSTATIONNO4);
            //COM
            BaseSystemInfo.SerialPortName1 = GetValue(xmlDocument, BaseConfiguration.SERIALPORTNAME1);
            BaseSystemInfo.SerialPortName2 = GetValue(xmlDocument, BaseConfiguration.SERIALPORTNAME2);
            BaseSystemInfo.SerialPortName3 = GetValue(xmlDocument, BaseConfiguration.SERIALPORTNAME3);
            BaseSystemInfo.SerialPortName4 = GetValue(xmlDocument, BaseConfiguration.SERIALPORTNAME4);
            BaseSystemInfo.SerialPortName5 = GetValue(xmlDocument, BaseConfiguration.SERIALPORTNAME5);
            //PLC
            BaseSystemInfo.WeightAddressA1 = GetValue(xmlDocument, BaseConfiguration.WEIGHTADDRESSA1);
            BaseSystemInfo.WeightAddressA2 = GetValue(xmlDocument, BaseConfiguration.WEIGHTADDRESSA2);
            BaseSystemInfo.WeightAddressB1 = GetValue(xmlDocument, BaseConfiguration.WEIGHTADDRESSB1);
            BaseSystemInfo.WeightAddressB2 = GetValue(xmlDocument, BaseConfiguration.WEIGHTADDRESSB2);

            //��ע�����Ϣ��ȡ
            BaseSystemInfo.MonitorAddress1 = GetValue(xmlDocument, BaseConfiguration.MONITORADDRESS1);
            BaseSystemInfo.MonitorAddress2 = GetValue(xmlDocument, BaseConfiguration.MONITORADDRESS2);
            BaseSystemInfo.MonitorAddress3 = GetValue(xmlDocument, BaseConfiguration.MONITORADDRESS3);
            BaseSystemInfo.MonitorAddress4 = GetValue(xmlDocument, BaseConfiguration.MONITORADDRESS4);

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

            // �������
            SetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATEIP, BaseSystemInfo.AutoUpdateIP);
            SetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATEPORT, BaseSystemInfo.AutoUpdatePort);

            SetValue(xmlDocument, BaseConfiguration.APP_AUTOEXECUTENAME, BaseSystemInfo.AutoExecuteName);
            SetValue(xmlDocument, BaseConfiguration.APP_UPDATEINTERVAL, BaseSystemInfo.UpdateInterval.ToString());
            // SetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATEFINISH, BaseSystemInfo.AutoUpdateFinish.ToString());
            //  SetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATESUCCESS, BaseSystemInfo.AutoUpdateSuccess.ToString());

            //��֤���
            SetValue(xmlDocument, BaseConfiguration.RUN_LOGIN, BaseSystemInfo.RunLogin.ToString());
            SetValue(xmlDocument, BaseConfiguration.RUN_LOGOUT, BaseSystemInfo.RunLogout.ToString());

            //ϵͳ���
            SetValue(xmlDocument, BaseConfiguration.COMPANYID, BaseSystemInfo.CompanyID);
            SetValue(xmlDocument, BaseConfiguration.COMPANYCODE, BaseSystemInfo.CompanyCode);
            SetValue(xmlDocument, BaseConfiguration.COMPANYNAME, BaseSystemInfo.CompanyName);
            SetValue(xmlDocument, BaseConfiguration.COMPANYNAME_EN, BaseSystemInfo.CompanyName_EN);

            SetValue(xmlDocument, BaseConfiguration.FACTORYID, BaseSystemInfo.FactoryID);
            SetValue(xmlDocument, BaseConfiguration.FACTORYCODE, BaseSystemInfo.FactoryCode);
            SetValue(xmlDocument, BaseConfiguration.FACTORYNAME, BaseSystemInfo.FactoryName);
            SetValue(xmlDocument, BaseConfiguration.FACTORYNAME_EN, BaseSystemInfo.FactoryName_EN);

            SetValue(xmlDocument, BaseConfiguration.PRODUCTLINEID, BaseSystemInfo.ProductLineID);
            SetValue(xmlDocument, BaseConfiguration.PRODUCTLINECODE, BaseSystemInfo.ProductLineCode);
            SetValue(xmlDocument, BaseConfiguration.PRODUCTLINENAME, BaseSystemInfo.ProductLineName);
            SetValue(xmlDocument, BaseConfiguration.PRODUCTLINENAME_EN, BaseSystemInfo.ProductLineName_EN);
            //��¼�û�������κͰ���
            SetValue(xmlDocument, BaseConfiguration.CURRENTUSERID, BaseSystemInfo.CurrentUserID);
            SetValue(xmlDocument, BaseConfiguration.CURRENTUSERCODE, BaseSystemInfo.CurrentUserCode);
            SetValue(xmlDocument, BaseConfiguration.CURRENTUSERNAME, BaseSystemInfo.CurrentUserName);
            SetValue(xmlDocument, BaseConfiguration.CURRENTUSERNAME_EN, BaseSystemInfo.CurrentUserName_EN);

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