//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System.Reflection;

namespace Sys.DbUtilities
{
    using Sys.Config;

    /// <summary>
    /// DbHelperFactory
    /// ���ݿ���񹤳���
    /// 
    /// �޸ļ�¼
    /// 
    ///		2009.07.23 �汾��1.2  ÿ�ζ���ȡһ���µ����ݿ����ӣ���������������⡣
    ///		2008.09.23 �汾��1.1  �Ż��Ľ�Ϊ��ʵ��ģʽ��
    ///		2008.08.26 �汾��1.0  �������ݿ���񹤳���
    /// 
    /// �汾��1.2
    /// 
    /// <author>
    ///		<name></name>
    ///		<date>2009.07.23</date>
    /// </author> 
    /// </summary>
    public class DbHelperFactory
    {
        #if (DEBUG)
            private static IDbHelper helper;
            private static object locker = new Object();
        #endif

        public static IDbHelper GetHelper()
        {
            // д�������Ϣ
            #if (DEBUG)
                ����ÿ�ζ����Ѿ���ȡ�������ݿ�����
                if (helper == null)
                {
                    lock (locker)
                    {
                        if (helper == null)
                        {
                            helper = (IDbHelper)Assembly.Load(BaseSystemInfo.DbHelperAssmely).CreateInstance(BaseSystemInfo.DbHelperClass, true);
                        }
                    }
                }
                return helper;
            #else
                // ������ÿ�ζ���ȡ�µ����ݿ�����
                // IDbHelper dbHelper = (IDbHelper)Assembly.Load(DbHelperAssmely).CreateInstance(DbHelperClass, true);
                // dbHelper.ConnectionString = DbHelper.ConnectionString;
                // return dbHelper;
                return (IDbHelper)Assembly.Load(BaseSystemInfo.DbHelperAssmely).CreateInstance(BaseSystemInfo.DbHelperClass, true);
            #endif
        }
    }
}