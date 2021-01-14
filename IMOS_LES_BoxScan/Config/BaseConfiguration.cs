//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Globalization;

namespace Sys.Config
{
    /// <summary>
    /// BaseConfiguration
    /// �������á�
    /// 
    /// �޸ļ�¼
    /// 
    ///		2011.01.21 �汾��3.6  �Զ���¼���������ݿ����ӹ������ơ�
    ///		2008.06.08 �汾��3.5  ����ȡ�����ļ����з��롣
    ///		2008.05.08 �汾��3.4  ��ò�ͬ�����ݿ������ַ��� OracleConnection��SqlConnection��OleDbConnection��
    ///		2007.11.28 �汾��3.2  ������������ַ��������������ļ��Ķ��Ĵ���������ܡ�
    ///		2007.05.23 �汾��3.1  ���� public const string ���岿�֡�
    ///		2007.04.14 �汾��3.0  �������ʽͨ�������ٽ����޸�����������
    ///		2006.11.17 �汾��2.4  GetFromRegistryKey() ����������������ɾ����������á�
    ///		2006.05.02 �汾��2.3  GetFromConfig ���Ӵ������ļ���ȡ���ݿ����ӵķ�����
    ///		2006.04.18 �汾��2.2  ���µ��������Ĺ淶����
    ///		2006.02.02 �汾��2.0  ɾ�����ݿ����ӳص��뷨���޸������������淶���������ˡ� 
    ///		2005.12.29 �汾��1.0  �������ļ���ȡ���ݿ����ӡ�
    /// 
    /// �汾��3.5
    /// 
    /// <author>
    ///		<name></name>
    ///		<date>2008.06.08</date>
    /// </author> 
    /// </summary>
    public class BaseConfiguration
    {
        public const string CURRENT_LOGON_TO = "LogOnTo";


        public const string REMEMBER_PASSWORD = "RememberPassword";
        public const string CURRENT_USERNAME = "CurrentUserName";
        public const string CURRENT_PASSWORD = "CurrentPassword";
        public const string ALLOW_NULLPASSWORD = "AllowNullPassword";

        // �ͻ���Ϣ����
        public const string VERSION = "Version";

        // �����Ƿ�����������
        public const string SYSTEM_TYPE = "SystemType";

        public const string SERVICE_FACTORY = "ServiceFactory";
        public const string SERVICE_PATH = "ServicePath";
        public const string DBHELPER_CLASSNAME = "DbHelperClass";
        public const string DBHELPER_ASSMELY = "DbHelperAssmely";
        public const string RECORD_LOG = "RecordLog";

        // ��¼����

        public const string LOGON_ASSEMBLY = "LogOnAssembly";
        public const string LOGON_FORM = "LogOnForm";
        public const string MAIN_FORM = "MainForm";


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

        //����ɨ�����
        public const string BARCODESCANIP = "BarCodeScanIP";
        public const string BARCODESCANPORT = "BarCodeScanPort";       

        //��������
        public const string PRINTERIP = "PrinterIP";
        public const string PRINTERPORT = "PrinterPort";



        //����洢Ŀ¼
        public const string APP_ReportDir = "APP_ReportDir";
        //ϵͳ�����˳�����֤
        public const string RUN_LOGIN = "RunLogin";
        public const string RUN_LOGOUT = "RunLogout";

        public const string MENUCOUNT = "MenuCount";
        public const string MENUKEY = "SystemMenuName";
        public const string SOURVEKEY = "SystemMenuSource";
        public const string FORMKEY = "SystemMenuForm";
        public const string VISIBLEKEY = "SystemMenuVisible";

        //ͣ�����
        public const string BTNWIDTH = "BtnWidth";
        public const string BTNHEIGHT = "BtnHeight";

        //�豸��� ��ص���Ҫ�豸����
        public const string COMPANYID = "CompanyID";
        public const string COMPANYCODE = "CompanyCode";
        public const string COMPANYNAME = "CompanyName";
        public const string DEPTID = "DeptID";
        public const string DEPTCODE = "DeptCode";
        public const string DEPTNAME = "DeptName";
        public const string PRODUCTLINEID = "ProductLineID";
        public const string PRODUCTLINECODE = "ProductLineCode";
        public const string PRODUCTLINENAME = "ProductLineName";

        //��¼�û�������κͰ���
        public const string CURRENTUSERID = "CurrentUserID";
        public const string CURRENTUSERCODE = "CurrentUserCode";
        public const string CURRENTUSERNAME = "CurrentUserName";
        public const string CURRENTCLASSCODE = "CurrentClassCode";
        public const string CURRENTCLASSNAME = "CurrentClassName";
        public const string CURRENTSHIFTCODE = "CurrentShiftCode";
        public const string CURRENTSHIFTNAME = "CurrentShiftName";

        public const string LOCALPWD = "LocalPWD";

        public const string BOXBARFLAG = "BoxBarFlag";

        public const string SERIALPORTNAME = "SerialPortName";

        public const string SENDPRINTERFLAG = "SendPrinterFlag";

        public const string LINERINSCANIP = "LinerInScanIP";
        public const string LINERINSCANPORT = "LinerInScanPort";

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

            if (BaseSystemInfo.ConfigurationFrom == ConfigurationCategory.Configuration)
            {
                ConfigurationHelper.GetConfig();
            }
            if (BaseSystemInfo.ConfigurationFrom == ConfigurationCategory.UserConfig)
            {
                ConfigHelper.GetConfig();
            }
        }
        #endregion
    }
}