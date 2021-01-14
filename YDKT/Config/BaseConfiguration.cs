//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Globalization;

namespace Sys.Config
{
    /// <summary>
    /// 
    /// <author>
    ///		<name></name>
    ///		<date>2008.06.08</date>
    /// </author> 
    /// </summary>
    public class BaseConfiguration
    {
        // ���ݿ�����
        public const string SERVER_DBCONNECTION = "ServerDbConnection";
        public const string BUSINESS_DBCONNECTION = "BusinessDbConnection";

        public const string DATABASE_TYPE = "DataBaseType";
        public const string REGISTER_KEY = "RegisterKey";

        public const string SERVERIP = "ServerIP";
        public const string SERVERUSER = "ServerUser";
        public const string SERVERPWD = "ServerPwd";
        public const string SERVERDB = "ServerDB";
        // ��������
        public const string APP_AUTOUPDATEIP = "App_AutoUpdateIP";
        public const string APP_AUTOUPDATEPORT = "App_AutoUpdatePort";
        public const string APP_AUTOUPDATEDIR = "App_AutoUpdateDir";
        public const string APP_AUTOEXECUTENAME = "App_AutoExecuteName";
        public const string APP_UPDATEINTERVAL = "App_UpdateInterval";
        public const string APP_AUTOUPDATEFINISH = "App_AutoUpdateFinish";
        public const string APP_AUTOUPDATESUCCESS = "App_AutoUpdateSuccess";
        public const string APP_VERSION = "App_Version";

        //����洢Ŀ¼
        public const string APP_ReportDir = "APP_ReportDir";
        //ϵͳ�����˳�����֤
        public const string RUN_LOGIN = "RunLogin";
        public const string RUN_LOGOUT = "RunLogout";

        //ͣ�����
        public const string BTNWIDTH = "BtnWidth";
        public const string BTNHEIGHT = "BtnHeight";

        //�豸��� ��ص���Ҫ�豸����
        public const string COMPANYID = "CompanyID";
        public const string COMPANYCODE = "CompanyCode";
        public const string COMPANYNAME = "CompanyName";
        public const string COMPANYNAME_EN = "CompanyName_EN";
        public const string FACTORYID = "FactoryID";
        public const string FACTORYCODE = "FactoryCode";
        public const string FACTORYNAME = "FactoryName";
        public const string FACTORYNAME_EN = "FactoryName_EN";
        public const string PRODUCTLINEID = "ProductLineID";
        public const string PRODUCTLINECODE = "ProductLineCode";
        public const string PRODUCTLINENAME = "ProductLineName";
        public const string PRODUCTLINENAME_EN = "ProductLineName_EN";

        //��¼�û�������κͰ���
        public const string CURRENTUSERID = "CurrentUserID";
        public const string CURRENTUSERCODE = "CurrentUserCode";
        public const string CURRENTUSERNAME = "CurrentUserName";
        public const string CURRENTUSERNAME_EN = "CurrentUserName_EN";

        public const string CURRENTCLASSCODE = "CurrentClassCode";
        public const string CURRENTCLASSNAME = "CurrentClassName";
        public const string CURRENTSHIFTCODE = "CurrentShiftCode";
        public const string CURRENTSHIFTNAME = "CurrentShiftName";

        //
      


        //����
        public const string CURRENTPROCESSCODE = "CurrentProcessCode";
        public const string CURRENTPROCESSNAME = "CurrentProcessName";
        public const string CURRENTPROCESSNAME_EN = "CurrentProcessName_EN";
        public const string CURRENTPLANNAME = "CurrentPlanName";
        //վ��
        public const string CURRENTSTATIONNO1 = "CurrentStationNo1";
        public const string CURRENTSTATIONNO2 = "CurrentStationNo2";
        public const string CURRENTSTATIONNO3 = "CurrentStationNo3";
        public const string CURRENTSTATIONNO4 = "CurrentStationNo4";

        //����
        public const string SERIALPORTNAME1 = "SerialPortName1";
        public const string SERIALPORTNAME2 = "SerialPortName2";
        public const string SERIALPORTNAME3 = "SerialPortName3";
        public const string SERIALPORTNAME4 = "SerialPortName4";
        public const string SERIALPORTNAME5 = "SerialPortName5";

        //PLC
        public const string WEIGHTADDRESSA1 = "WeightAddressA1";
        public const string WEIGHTADDRESSA2 = "WeightAddressA2";
        public const string WEIGHTADDRESSB1 = "WeightAddressB1";
        public const string WEIGHTADDRESSB2 = "WeightAddressB2";

        //��ע�����Ϣ��ȡ
        public static string MONITORADDRESS1 = "MonitorAddress1";
        public static string MONITORADDRESS2 = "MonitorAddress2";
        public static string MONITORADDRESS3 = "MonitorAddress3";
        public static string MONITORADDRESS4 = "MonitorAddress4";

        public const string LOCALPWD = "LocalPWD";

        public const string SYSTEMTYPE = "SystemType";

        public const string PLCTYPE = "PLCType";


        #region public BaseConfiguration()
        /// <summary>
        /// ���췽��
        /// </summary>
        public BaseConfiguration()
        {
        }
        #endregion

        #region public static ConfigurationCategory GetConfiguration(string configuration)
        /// <summary>
        /// ������Ϣ�������ж�
        /// </summary>
        /// <param name="configuration">������Ϣ����</param>
        /// <returns>������Ϣ����</returns>
        public static ConfigurationCategory GetConfiguration(string configuration)
        {
            ConfigurationCategory returnValue = ConfigurationCategory.Configuration;
            foreach (ConfigurationCategory configurationCategory in Enum.GetValues(typeof(ConfigurationCategory)))
            {
                if (configurationCategory.ToString().Equals(configuration))
                {
                    returnValue = configurationCategory;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static void GetSetting()
        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        public static void GetSetting()
        {
                ConfigurationHelper.GetConfig();
        }
        #endregion
    }
}