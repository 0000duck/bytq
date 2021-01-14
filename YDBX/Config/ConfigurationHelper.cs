//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Configuration;
using System.Globalization;

namespace Sys.Config
{
    /// <summary>
    /// ConfigurationHelper
    /// �������á�
    /// 
    /// �޸ļ�¼
    /// 
    ///		2008.06.08 �汾��1.0  ������� BaseConfiguration �����˷��롣
    /// 
    /// �汾��1.0
    /// 
    /// <author>
    ///		<name></name>
    ///		<date>2008.06.08</date>
    /// </author> 
    /// </summary>
    public class ConfigurationHelper
    {
         #region public static void GetConfig()
        /// <summary>
        /// ��������Ϣ��ȡ������Ϣ
        /// </summary>
        /// <param name="configuration">����</param>
        public static void GetConfig()
        {

            //BaseSystemInfo.Version = ConfigurationManager.AppSettings[BaseConfiguration.VERSION];

            //BaseSystemInfo.LogOnAssembly = ConfigurationManager.AppSettings[BaseConfiguration.LOGON_ASSEMBLY];
            //BaseSystemInfo.LogOnForm = ConfigurationManager.AppSettings[BaseConfiguration.LOGON_FORM];
            //BaseSystemInfo.MainForm = ConfigurationManager.AppSettings[BaseConfiguration.MAIN_FORM];

            // ���ݿ�����
            BaseSystemInfo.BusinessDbConnectionString = ConfigurationManager.AppSettings[BaseConfiguration.BUSINESS_DBCONNECTION];
            BaseSystemInfo.ServerDbConnectionString = ConfigurationManager.AppSettings[BaseConfiguration.SERVER_DBCONNECTION];


            BaseSystemInfo.DataBaseType = ConfigurationManager.AppSettings[BaseConfiguration.DATABASE_TYPE];
        }
        #endregion
    }
}