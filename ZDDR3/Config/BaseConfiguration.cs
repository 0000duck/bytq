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
        public const string SERVERDATABASE_TYPE = "ServerDataBaseType";

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

       //�豸��� ��ص���Ҫ�豸����
        public const string COMPANYID = "CompanyID";
        public const string COMPANYCODE = "CompanyCode";
        public const string COMPANYNAME = "CompanyName";
        public const string FACTORYID = "FactoryID";
        public const string FACTORYCODE = "FactoryCode";
        public const string FACTORYNAME = "FactoryName";
        public const string PRODUCTLINEID = "ProductLineID";
        public const string PRODUCTLINECODE = "ProductLineCode";
        public const string PRODUCTLINENAME = "ProductLineName";

        public const string CURRENTPROCESSCODE = "CurrentProcessCode";
        public const string CURRENTPROCESSNAME = "CurrentProcessName";

        public const string CURRENTPROCESSCODE_SEC = "CurrentProcessCode_Sec";
        public const string CURRENTPROCESSNAME_SEC = "CurrentProcessName_Sec";

        public const string APPLICATIONSOURCE = "ApplicationSource";
        public const string APPLICATIONFORM = "ApplicationForm";
        public const string APPLICATIONTITLE = "ApplicationTitle";


        //��¼�û�������κͰ���
        public const string CURRENTUSERID = "CurrentUserID";
        public const string CURRENTUSERCODE = "CurrentUserCode";
        public const string CURRENTUSERNAME = "CurrentUserName";
        public const string CURRENTCLASSCODE = "CurrentClassCode";
        public const string CURRENTCLASSNAME = "CurrentClassName";
        public const string CURRENTSHIFTCODE = "CurrentShiftCode";
        public const string CURRENTSHIFTNAME = "CurrentShiftName";


        public const string SYSTEMTYPE = "SystemType";

        public const string PLCTYPE = "PLCType";

        public const string PLCUSEFLAG = "PLC_UseFlag";

        public const string MASTERPLCIP_FIRST = "MasterPLCIP_First";
        public const string MASTERPLCIP_SENCOND = "MasterPLCIP_Sencond";

        public const string MASTERPLCSTATION_FIRST = "MasterPLCStation_First";
        public const string MASTERPLCSTATION_SENCOND = "MasterPLCStation_Sencond";

        public const string SERIALPORTNAME1 = "SerialPortName1";
        public const string SERIALPORTNAME2 = "SerialPortName2";
        public const string SERIALPORTNAME3 = "SerialPortName3";
        public const string SERIALPORTNAME4 = "SerialPortName4";
        public const string SERIALPORTNAME5 = "SerialPortName5";

        //ɨ��IP���
        public const string BARSCANIP_1 = "BarScanIP_1";
        public const string BARSCANPORT_1 = "BarScanPort_1";

        public const string BARSCANIP_2 = "BarScanIP_2";
        public const string BARSCANPORT_2 = "BarScanPort_2";

        public const string BARSCANIP_3 = "BarScanIP_3";
        public const string BARSCANPORT_3 = "BarScanPort_3";

        public const string BARSCANIP_4 = "BarScanIP_4";
        public const string BARSCANPORT_4 = "BarScanPort_4";

        public const string BARSCANIP_5 = "BarScanIP_5";
        public const string BARSCANPORT_5 = "BarScanPort_5";

        //��ӡ���б�
        public const string ENERGYPRINTERNAME1 = "EnergyPrinterName1";
        public const string ENERGYPRINTERNAME2 = "EnergyPrinterName2";
        public const string ENERGYPRINTERNAME3 = "EnergyPrinterName3";



        public const string IPAddress1 = "IPAddress1";
        public const string IPEndPoint1 = "IPEndPoint1";

        //webservice�ӿڵ�ַ
        public const string webServiceAddress = "webServiceAddress";
        public const string FactoryNumber = "factoryNumber";

        //��¼��ǰ�Ŀ�λ��Ϣ,ǰһ����λ��Ϣ
        public const string CurrentStoreCode = "CurrentStoreCode";
        public const string PreviousStoreCode = "PreviousStoreCode";


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