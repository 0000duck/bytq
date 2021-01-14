//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Windows.Forms;

namespace Sys.DbUtilities
{
    using Sys.Config;

    /// <summary>
    /// DbHelper
    /// �й����ݿ����ӵķ�����
    /// 
    /// �޸ļ�¼
    /// 
    ///		2008.09.03 �汾��1.0  ������
    /// 
    /// �汾��1.2
    /// 
    /// <author>
    ///		<name></name>
    ///		<date>2008.08.26</date>
    /// </author> 
    /// </summary>
    public class DbHelper
    {
        /// <summary>
        /// ���ݿ����Ӵ���������Ϊ�˼�˼·
        /// </summary>
        public static string BusinessDbConnection = BaseSystemInfo.BusinessDbConnection;

        private static readonly IDbHelper dbHelper = DbHelperFactory.GetHelper();

        /// <summary> DbProviderFactory ʵ��
        /// DbProviderFactoryʵ��
        /// </summary>
        private static DbProviderFactory factory = null;

        /// <summary> DbFactoryʵ��
        /// DbFactoryʵ��
        /// </summary>
        public static DbProviderFactory Factory
        {
            get
            {
                if (factory == null)
                {
                    factory = dbHelper.GetInstance();
                }
                return factory;
            }
        }

        /// <summary> ���췽��
        /// ���췽��
        /// </summary>
        private DbHelper()
        {
        }

        /// <summary> ��ǰ���ݿ�����
        /// ��ǰ���ݿ�����
        /// </summary>
        public DataBaseType CurrentDataBaseType
        {
            get
            {
                return dbHelper.CurrentDataBaseType;
            }
        }

        #region public static string GetDBNow() ������ݿ�����ʱ��
        /// <summary>
        /// ������ݿ�����ʱ��
        /// </summary>
        /// <returns>����ʱ��</returns>
        public static string GetDBNow()
        {
            return dbHelper.GetDBNow();
        }
        #endregion

        #region public static string SqlSafe(string value) �������İ�ȫ��
        /// <summary>
        /// �������İ�ȫ��
        /// </summary>
        /// <param name="value">����</param>
        /// <returns>��ȫ�Ĳ���</returns>
        public static string SqlSafe(string value)
        {
            return dbHelper.SqlSafe(value);
        }
        #endregion

        #region string PlusSign(params string[] values)  ���Sql�ַ�����ӷ���
        /// <summary>
        ///  ���Sql�ַ�����ӷ���
        /// </summary>
        /// <param name="values">����ֵ</param>
        /// <returns>�ַ���</returns>
        public static string PlusSign(params string[] values)
        {
            return dbHelper.PlusSign(values);
        }
        #endregion

        #region public static string GetParameter(string parameter) ��ò���Sql���ʽ
        /// <summary>
        /// ��ò���Sql���ʽ
        /// </summary>
        /// <param name="parameter">��������</param>
        /// <returns>�ַ���</returns>
        public static string GetParameter(string parameter)
        {
            return dbHelper.GetParameter(parameter);
        }
        #endregion

        #region public static DbParameter MakeInParam(string targetFiled, object targetValue) ��ȡ����
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="targetFiled">Ŀ���ֶ�</param>
        /// <param name="targetValue">ֵ</param>
        /// <returns>����</returns>
        public static DbParameter MakeInParam(string targetFiled, object targetValue)
        {
            return dbHelper.MakeInParam(targetFiled, targetValue);
        }
        #endregion

        #region public static DbParameter[] MakeParameters(string targetFiled, object targetValue) ��ȡ����
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="targetFiled">Ŀ���ֶ�</param>
        /// <param name="targetValue">ֵ</param>
        /// <returns>������</returns>
        public static DbParameter[] MakeParameters(string targetFiled, object targetValue)
        {
            return dbHelper.MakeParameters(targetFiled, targetValue);
        }
        #endregion

        #region public static DbParameter[] MakeParameters(string[] targetFileds, Object[] targetValues) ��ȡ����
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="targetFiled">Ŀ���ֶ�</param>
        /// <param name="targetValue">ֵ</param>
        /// <returns>������</returns>
        public static DbParameter[] MakeParameters(string[] targetFileds, Object[] targetValues)
        {
            return dbHelper.MakeParameters(targetFileds, targetValues);
        }
        #endregion

        #region public static DbParameter MakeParam(string paramName, DbType DbType, Int32 size, ParameterDirection direction, object value) ��ȡ����
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="paramName">��������</param>
        /// <param name="DbType">��������</param>
        /// <param name="size">��С</param>
        /// <param name="Direction">�������</param>
        /// <param name="Value">ֵ</param>
        /// <returns>������</returns>
        public static DbParameter MakeParam(string paramName, DbType DbType, Int32 size, ParameterDirection direction, object value)
        {
            return dbHelper.MakeParam(paramName, DbType, size, direction, value);
        }
        #endregion

        #region public static int ExecuteNonQuery(string commandText) ִ�в�ѯ������Ӱ�������, SQL BUILDER �������������������Ҫ����, ���ܶ�ʧ.
        /// <summary>
        /// ִ�в�ѯ������Ӱ�������, SQL BUILDER �������������������Ҫ����, ���ܶ�ʧ.
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <returns>Ӱ������</returns>
        public static int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, null);
        }
        #endregion

        #region public static int ExecuteNonQuery(string commandText, DbParameter[] dbParameters); ִ�в�ѯ������Ӱ�������
        /// <summary>
        /// ִ�в�ѯ������Ӱ�������
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>Ӱ������</returns>
        public static int ExecuteNonQuery(string commandText, DbParameter[] dbParameters)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, dbParameters);
        }
        #endregion

        #region public static int ExecuteNonQuery(CommandType commandType, string commandText, DbParameter[] dbParameters) ִ�в�ѯ������Ӱ�������
        /// <summary>
        /// ִ�в�ѯ������Ӱ�������
        /// </summary>
        /// <param name="CommandType">�������</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>Ӱ������</returns>
        public static int ExecuteNonQuery(CommandType commandType, string commandText, DbParameter[] dbParameters)
        {
            int returnValue = 0;
            dbHelper.Open(BusinessDbConnection);
            returnValue = dbHelper.ExecuteNonQuery(commandType, commandText, dbParameters);
            dbHelper.Close();
            return returnValue;
        }
        #endregion

        #region static public object ExecuteScalar(string commandText) ִ�в�ѯ��������������
        /// <summary>
        /// ִ�в�ѯ��������������
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(CommandType.Text, commandText, null);
        }
        #endregion

        #region static public object ExecuteScalar(string commandText, DbParameter[] dbParameters) ִ�в�ѯ��������������
        /// <summary>
        /// ִ�в�ѯ��������������
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>Object</returns>
        public static object ExecuteScalar(string commandText, DbParameter[] dbParameters)
        {
            return ExecuteScalar(CommandType.Text, commandText, dbParameters);
        }
        #endregion

        #region public static object ExecuteScalar(CommandType commandType, string commandText, DbParameter[] dbParameters) ִ�в�ѯ��������������
        /// <summary>
        /// ִ�в�ѯ��������������
        /// </summary>
        /// <param name="CommandType">�������</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>Object</returns>
        public static object ExecuteScalar(CommandType commandType, string commandText, DbParameter[] dbParameters)
        {
            object returnValue = null;
            dbHelper.Open(BusinessDbConnection);
            returnValue = dbHelper.ExecuteScalar(commandType, commandText, dbParameters);
            dbHelper.Close();
            return returnValue;
        }
        #endregion

        #region public static IDataReader ExecuteReader(string commandText) ִ�в�ѯ����DataReader
        /// <summary>
        /// ִ�в�ѯ����DataReader
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <returns>�������</returns>
        public static IDataReader ExecuteReader(string commandText)
        {
            dbHelper.Open(BusinessDbConnection);
            dbHelper.AutoOpenClose = true;
            return dbHelper.ExecuteReader(commandText);
        }
        #endregion

        #region public static IDataReader ExecuteReader(string commandText, DbParameter[] dbParameters); ִ�в�ѯ����DataReader
        /// <summary>
        /// ִ�в�ѯ����DataReader
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>�������</returns>
        public static IDataReader ExecuteReader(string commandText, DbParameter[] dbParameters)
        {
            return ExecuteReader(CommandType.Text, commandText, dbParameters);
        }
        #endregion

        #region public IDataReader ExecuteReader(string commandText, List<DbParameter> dbParameters); ִ�в�ѯ����DataReader
        /// <summary>
        /// ִ�в�ѯ����DataReader
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>�������</returns>
        public IDataReader ExecuteReader(string commandText, List<DbParameter> dbParameters)
        {
            return ExecuteReader(CommandType.Text, commandText, dbParameters.ToArray());
        }
        #endregion

        #region public static IDataReader ExecuteReader(CommandType commandType, string commandText, DbParameter[] dbParameters) ִ�в�ѯ����DataReader
        /// <summary>
        /// ִ�в�ѯ����DataReader
        /// </summary>
        /// <param name="commandType">�������</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>�������</returns>
        public static IDataReader ExecuteReader(CommandType commandType, string commandText, DbParameter[] dbParameters)
        {
            dbHelper.Open(BusinessDbConnection);
            dbHelper.AutoOpenClose = true;
            return dbHelper.ExecuteReader(commandType, commandText, dbParameters);
        }
        #endregion

        #region public static IDataReader ExecuteReader(CommandType commandType, string commandText, DbParameter[] dbParameters) ִ�в�ѯ����DataReader
        /// <summary>
        /// ִ�в�ѯ����DataReader
        /// </summary>
        /// <param name="commandType">�������</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>�������</returns>
        public static IDataReader ExecuteReader(CommandType commandType, string commandText, List<DbParameter> dbParameters)
        {
            return ExecuteReader(commandType, commandText, dbParameters.ToArray());
        }
        #endregion

        #region public static DataTable Fill(string commandText) ������ݱ�
        /// <summary>
        /// ������ݱ�
        /// </summary>
        /// <param name="commandText">��ѯ</param>
        /// <returns>���ݱ�</returns>
        public static DataTable Fill(string commandText)
        {
            DataTable dataTable = new DataTable();
            Fill(dataTable, CommandType.Text, commandText, null);
            return dataTable;
        }
        #endregion

        #region public static DataTable Fill(DataTable dataTable, string commandText) ������ݱ�
        /// <summary>
        /// ������ݱ�
        /// </summary>
        /// <param name="dataTable">Ŀ�����ݱ�</param>
        /// <param name="commandText">��ѯ</param>
        /// <returns>���ݱ�</returns>
        public static DataTable Fill(DataTable dataTable, string commandText)
        {
            return Fill(dataTable, CommandType.Text, commandText, null);
        }
        #endregion

        #region public static DataTable Fill(string commandText, DbParameter[] dbParameters) ������ݱ�
        /// <summary>
        /// ������ݱ�
        /// </summary>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>���ݱ�</returns>
        public static DataTable Fill(string commandText, DbParameter[] dbParameters)
        {
            return dbHelper.Fill(CommandType.Text, commandText, dbParameters);
        }
        #endregion

        #region public static DataTable Fill(DataTable dataTable, string commandText, DbParameter[] dbParameters) ������ݱ�
        /// <summary>
        /// ������ݱ�
        /// </summary>
        /// <param name="dataTable">Ŀ�����ݱ�</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>���ݱ�</returns>
        public static DataTable Fill(DataTable dataTable, string commandText, DbParameter[] dbParameters)
        {
            return dbHelper.Fill(dataTable, CommandType.Text, commandText, dbParameters);
        }
        #endregion

        #region public static DataTable Fill(DataTable dataTable, CommandType commandType, string commandText, DbParameter[] dbParameters) ������ݱ�
        /// <summary>
        /// ������ݱ�
        /// </summary>
        /// <param name="dataSet">Ŀ�����ݱ�</param>
        /// <param name="CommandType">�������</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="dbParameters">������</param>
        /// <returns>���ݱ�</returns>
        public static DataTable Fill(DataTable dataTable, CommandType commandType, string commandText, DbParameter[] dbParameters)
        {
            dbHelper.Open(BusinessDbConnection);
            dbHelper.Fill(dataTable, commandType, commandText, dbParameters);
            dbHelper.Close();
            return dataTable;
        }
        #endregion

        #region public static DataTable FillSchema(string dataTableName) ������ݱ�ṹ
        /// <summary>
        /// ������ݱ�ṹ
        /// </summary>
        /// <param name="dataTableName">Ŀ�����ݱ�����</param>
        /// <returns>���нṹ�Ŀ����ݱ�</returns>
        public static DataTable FillSchema(string dataTableName)
        {
            dbHelper.Open(BusinessDbConnection);
            DataTable dataTable = dbHelper.FillSchema(dataTableName);
            dbHelper.Close();
            return dataTable;
        }
        #endregion

        #region public static DataSet Fill(DataSet dataSet, string commandText, string tableName) ������ݼ�
        /// <summary>
        /// ������ݼ�
        /// </summary>
        /// <param name="dataSet">Ŀ�����ݼ�</param>
        /// <param name="commandText">��ѯ</param>
        /// <param name="tableName">����</param>
        /// <returns>���ݼ�</returns>
        public static DataSet Fill(DataSet dataSet, string commandText, string tableName)
        {
            dbHelper.Open(BusinessDbConnection);
            dbHelper.Fill(dataSet, commandText, tableName);
            dbHelper.Close();
            return dataSet;
        }
        #endregion

        #region static public DataSet Fill(DataSet dataSet, string commandText, string tableName, DbParameter[] dbParameters) ������ݼ�
        /// <summary>
        /// ������ݼ�
        /// </summary>
        /// <param name="dataSet">���ݼ�</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="tableName">����</param>
        /// <param name="dbParameters">������</param>
        /// <returns>���ݼ�</returns>
        public static DataSet Fill(DataSet dataSet, string commandText, string tableName, DbParameter[] dbParameters)
        {
            return Fill(dataSet, CommandType.Text, commandText, tableName, dbParameters);
        }
        #endregion

        #region public static DataSet Fill(DataSet dataSet, CommandType commandType, string commandText, string tableName, DbParameter[] dbParameters) ������ݼ�
        /// <summary>
        /// ������ݼ�
        /// </summary>
        /// <param name="dataSet">���ݼ�</param>
        /// <param name="CommandType">�������</param>
        /// <param name="commandText">sql��ѯ</param>
        /// <param name="tableName">����</param>
        /// <param name="dbParameters">������</param>
        /// <returns>���ݼ�</returns>
        public static DataSet Fill(DataSet dataSet, CommandType commandType, string commandText, string tableName, DbParameter[] dbParameters)
        {
            dbHelper.Open(BusinessDbConnection);
            dbHelper.Fill(dataSet, commandType, commandText, tableName, dbParameters);
            dbHelper.Close();
            return dataSet;
        }
        #endregion

        #region public static int ExecuteProcedure(string procedureName) ִ�д洢����
        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="procedureName">�洢����</param>
        /// <returns>int</returns>
        public static int ExecuteProcedure(string procedureName)
        {
            return ExecuteProcedure(procedureName, null);
        }
        #endregion

        #region public static int ExecuteProcedure(string procedureName, DbParameter[] dbParameters) ִ�д洢����
        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="procedureName">�洢������</param>
        /// <param name="dbParameters">������</param>
        /// <returns>Ӱ������</returns>
        public static int ExecuteProcedure(string procedureName, DbParameter[] dbParameters)
        {
            int returnValue = 0;
            dbHelper.Open(BusinessDbConnection);
            returnValue = dbHelper.ExecuteProcedure(procedureName, dbParameters);
            dbHelper.Close();
            return returnValue;
        }
        #endregion

        #region public static DataSet ExecuteProcedureForDataTable(string procedureName, string tableName, DbParameter[] dbParameters) ִ�д洢���̷������ݱ�
        /// <summary>
        /// ִ�д洢���̷������ݱ�
        /// </summary>
        /// <param name="dataSet">���ݼ�</param>
        /// <param name="procedureName">�洢����</param>
        /// <param name="tableName">����</param>
        /// <param name="dbParameters">������</param>
        /// <returns>���ݼ�</returns>
        public static DataTable ExecuteProcedureForDataTable(string procedureName, string tableName, DbParameter[] dbParameters)
        {
            dbHelper.Open(BusinessDbConnection);
            DataTable dataTable = dbHelper.ExecuteProcedureForDataTable(procedureName, tableName, dbParameters);
            dbHelper.Close();
            return dataTable;
        }
        #endregion

    }
}