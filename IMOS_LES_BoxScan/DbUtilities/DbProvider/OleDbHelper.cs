﻿//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace Sys.DbUtilities
{
    

	/// <summary>
    /// OleDbHelper
	/// 有关数据库连接的方法。
	/// 
	/// 修改纪录
    ///
    ///		2011.01.22 版本：5.6  参数首字母大小写规范化。
    ///		2008.08.26 版本：5.5  修改 Open 时的错误反馈。
    ///		2008.06.01 版本：5.4  数据库连接获得方式进行改进，构造函数获得调通。
    ///		2008.05.31 版本：5.3  参数命名 param 前缀替换为小写字母开始。
    ///		2008.05.09 版本：5.2  InTransaction 命名改进。
    ///		2008.05.07 版本：5.1  AddParameter 方法改进。
    ///		2008.03.27 版本：5.1  完善写日志功能。
    ///		2008.02.24 版本：5.0  修改函数名为 OleDbHelper， 增加日志功能， 增加异步调用功能， 增加 DataReader 功能。
    ///		2008.02.23 版本：4.9  增加 OleDbTransaction 事务处理功能。
    ///		2008.02.21 版本：4.8  函数获得服务器时间函数 GetDBDateTime()。
    ///		2007.12.25 版本：4.7  函数增加 TimeFormat 时间格式定义。
    ///		2007.11.29 版本：4.6  SqlSafe() 函数增加，判断参数的安全性。
    ///		2007.11.28 版本：4.5  Open() 时间不需要每次都读配置信息，只读取一次就够了。
    ///		2007.10.26 版本：4.4  增加填充 DataTable 功能。
    ///		2007.07.30 版本：4.2  配置信息从 Instance 读取。
    ///		2007.07.20 版本：4.1  修改 IsUseTransaction 标志信息错误。
    ///		2007.06.23 版本：4.0  改进 ExecuteScalar，ExecuteNonQuery 方法，完善方法。
    ///		2007.05.23 版本：3.9  改进 Environment.TickCount 方法，性能改进。
    ///		2007.05.07 版本：3.8  改进 BeginTransaction() 方法，满足更灵活的需求。
    ///		2007.04.14 版本：3.7  检查程序格式通过，不再进行修改主键操作。
    ///     2007.01.07 版本：3.6  增加简单的注册功能部分。
    ///     2006.11.17 版本：3.5  改进使用事务部分。
    ///     2006.09.11 版本：3.4  改进使用存储过程的。
    ///     2006.04.18 版本：3.3  重新调整主键的规范化。
    ///		2006.02.04 版本：3.2  用 System.DateTime.Now.Ticks 进行性能测试用。
    ///		2006.02.04 版本：3.1  #if (DEBUG) #endif(ok) 添加条件编译选项。
    ///		2006.02.02 版本：3.0  删除数据库连接池的想法(ok)。
    ///		2006.02.01 版本：2.9  还想改进成支持事务类型的(ok)。
    ///		2005.12.29 版本：2.8  数据库类型等用枚举类型的方式进行改进。
	///		2005.08.19 版本：2.7  主键继续改进一次。
    ///		2005.08.14 版本：2.6  参数有效化。
    ///		2005.08.08 版本：2.5  修改注册表读写方法。
    ///		2005.07.10 版本：2.4  改进类名称。
    ///		2005.03.07 版本：2.3  改进排版根式。
    ///		2004.11.18 版本：2.2  改进主键编排格式。
    ///		2004.08.24 版本：2.1  增加 Access 连接字符串。
    ///		2004.08.22 版本：2.0  增加空的构造方法。
    ///		2004.07.30 版本：1.9  改进数据库连接池功能。
    ///		2004.06.09 版本：1.8  改进数据库了连接池功能，得经过一段时间的测试比较好。
    ///		2004.03.21 版本：1.7  改进读取注册表的方法，可以不从注册表读取参数，可以指定参数。
    ///		2004.02.17 版本：1.6  重新整理一些方法，命名方式等适当修改，全局变量，局部变量等重新命名。
    ///		2004.02.17 版本：1.5  将变量名字中的_符号尽量去掉了，局部变量采用_开头的变量名。
    ///		2004.02.17 版本：1.4  并且采用了 String.Format 方法，字符串看起来更顺眼，加强了抛出异常throw的方法。
    ///		2003.11.26 版本：1.3  数据库丢失连接的改进，设置过期时间，为了提高运行效率仍然使用保持连接方式。
    ///		2003.10.24 版本：1.2  数据库不采用保持连接的方式，注释文件的编写方式改变。
    ///		2003.10.24 版本：1.1  将类改进为静太方式，不用创建新的类，就可以获得数据库连接。
    ///		2003.10.14 版本：1.0  改进成以后可以扩展到多种数据库的结构形式。
    /// 
    /// 版本：5.5
	/// 
	/// <author>
    ///		<name></name>
    ///		<date>2008.08.26</date>
	/// </author> 
	/// </summary>
    public class OleDbHelper : BaseDbHelper, IDbHelper
	{
        public override DbProviderFactory GetInstance()
        {
            return OleDbFactory.Instance;
        }

        #region 当前数据库类型
        /// <summary>
        /// 当前数据库类型
        /// </summary>
        public DataBaseType CurrentDataBaseType
        {
            get
            {
                return DataBaseType.Access;
            }
        }
        #endregion 

        #region public OleDbHelper() 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public OleDbHelper()
		{
            FileName = "OleDbHelper.txt";   // sql查询句日志
		}
		#endregion

        #region public OleDbHelper(string connectionString) 构造方法
        /// <summary>
		/// 构造方法
		/// </summary>
        /// <param name="connectionString">数据连接</param>
        public OleDbHelper(string connectionString) : this()
		{
            this.ConnectionString = connectionString;
		}
		#endregion

        #region public string GetDBNow() 获得数据库日期时间
        /// <summary>
        /// 获得数据库日期时间
        /// </summary>
        /// <returns>日期时间</returns>
        public string GetDBNow()
        {
            string returnValue = " Getdate() ";
            switch (this.CurrentDataBaseType)
            {
                case DataBaseType.Access:
                    returnValue = "'" + DateTime.Now.ToString() + "'";
                    break;
                case DataBaseType.SqlServer:
                    returnValue = " GetDate() ";
                    break;
                case DataBaseType.Oracle:
                    returnValue = " SYSDATE ";
                    break;
                case DataBaseType.MySql:
                    returnValue = " NOW() ";
                    break;
            }
            return returnValue;
        }
        #endregion

        #region public string GetDBDateTime() 获得数据库日期时间
        /// <summary>
        /// 获得数据库日期时间
        /// </summary>
        /// <returns>日期时间</returns>
        public string GetDBDateTime()
        {
            string commandText = " SELECT " + this.GetDBNow();
            if (this.CurrentDataBaseType.Equals(DataBaseType.Oracle))
            {
                commandText += " FROM DUAL ";
            }
            this.Open();
            string dateTime = this.ExecuteScalar(CommandType.Text, commandText, new DbParameter[0]).ToString();
            this.Close();
            return dateTime;
        }
        #endregion

        #region public string SqlSafe(string value) 检查参数的安全性
        /// <summary>
        /// 检查参数的安全性
        /// </summary>
        /// <param name="value">参数</param>
        /// <returns>安全的参数</returns>
        public string SqlSafe(string value)
        {
            value = value.Replace("'", "''");
            // value = value.Replace("%", "'%");
            return value;
        }
        #endregion

        #region public DbParameter MakeInParam(string targetFiled, object targetValue) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="targetFiled">目标字段</param>
        /// <param name="targetValue">值</param>
        /// <returns>参数</returns>
        public DbParameter MakeInParam(string targetFiled, object targetValue)
        {
            return new OleDbParameter(targetFiled, targetValue);
        }
        #endregion

        #region public DbParameter[] MakeParameters(string targetFiled, object targetValue) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="targetFiled">目标字段</param>
        /// <param name="targetValue">值</param>
        /// <returns>参数集</returns>
        public DbParameter[] MakeParameters(string targetFiled, object targetValue)
        {
            DbParameter[] dbParameters = null;
            if (targetFiled != null && targetValue != null)
            {
                dbParameters = new DbParameter[1];
                dbParameters[0] = this.MakeInParam(targetFiled, targetValue);
            }
            return dbParameters;
        }
        #endregion

        #region public DbParameter[] MakeParameters(string[] targetFileds, Object[] targetValues) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="targetFiled">目标字段</param>
        /// <param name="targetValue">值</param>
        /// <returns>参数集</returns>
        public DbParameter[] MakeParameters(string[] targetFileds, Object[] targetValues)
        {
            DbParameter[] dbParameters = new DbParameter[0];
            if (targetFileds != null && targetValues != null)
            {
                dbParameters = new DbParameter[targetFileds.Length];
                for (int i = 0; i < targetFileds.Length; i++)
                {
                    if (targetFileds[i] != null && targetValues[i] != null)
                    {
                        dbParameters[i] = this.MakeInParam(targetFileds[i], targetValues[i]);
                    }
                }
            }
            return dbParameters;
        }
        #endregion

        #region  public DbParameter MakeOutParam(string paramName, DbType dbType, int size)  获取输出参数
        /// <summary>
        /// 获取输出参数
        /// </summary>
        /// <param name="paramName">参数</param>
        /// <param name="dbType">数据类型</param>
        /// <param name="size">长度</param>
        /// <returns></returns>
        public DbParameter MakeOutParam(string paramName, DbType dbType, int size)
        {
            return MakeParam(paramName, dbType, size, ParameterDirection.Output, null);
        }
        #endregion 

        #region   public DbParameter MakeInParam(string paramName, DbType dbType, int size, object value) 获取输入参数
        /// <summary>
        /// 获取输入参数
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="dbType">数据类型</param>
        /// <param name="size">长度</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public DbParameter MakeInParam(string paramName, DbType dbType, int size, object value)
        {
            return MakeParam(paramName, dbType, size, ParameterDirection.Input, value);
        }
        #endregion 

        #region public DbParameter MakeParam(string paramName, DbType dbType, Int32 size, ParameterDirection direction, object paramValue) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="paramName">参数</param>
        /// <param name="dbType">数据类型</param>
        /// <param name="size">长度</param>
        /// <param name="direction">参数类型</param>
        /// <param name="paramValue">值</param>
        /// <returns></returns>
        public DbParameter MakeParam(string paramName, DbType dbType, Int32 size, ParameterDirection direction, object paramValue)
        {
            OleDbParameter parameter;

            if (size > 0)
            {
                parameter = new OleDbParameter(paramName, (OleDbType)dbType, size);
            }
            else
            {
                parameter = new OleDbParameter(paramName, (OleDbType)dbType);
            }

            parameter.Direction = direction;
            if (!(direction == ParameterDirection.Output && paramValue == null))
            {
                parameter.Value = paramValue;
            }

            return parameter;
        }
        #endregion

        #region public string GetParameter(string parameter) 获得参数Sql表达式
        /// <summary>
        /// 获得参数Sql表达式
        /// </summary>
        /// <param name="parameter">参数名称</param>
        /// <returns>字符串</returns>
        public string GetParameter(string parameter)
        {
            return " ? ";
        }
        #endregion

        #region string PlusSign(params string[] values) 获得Sql字符串相加符号
        /// <summary>
        ///  获得Sql字符串相加符号
        /// </summary>
        /// <param name="values">参数值</param>
        /// <returns>字符加</returns>
        public string PlusSign(params string[] values)
        {
            string returnValue = string.Empty;
            switch (this.CurrentDataBaseType)
            {
                case DataBaseType.Access:
                case DataBaseType.SqlServer:
                    if (!String.IsNullOrEmpty(returnValue))
                    {
                        returnValue = returnValue.Substring(0, returnValue.Length - 3);
                    }
                    else
                    {
                        returnValue = " + ";
                    }
                    break;
                case DataBaseType.MySql:
                    returnValue = " CONCAT(";
                    for (int i = 0; i < values.Length; i++)
                    {
                        returnValue += values[i] + " ,";
                    }
                    returnValue = returnValue.Substring(0, returnValue.Length - 2);
                    returnValue += ")";
                    break;
                case DataBaseType.Oracle:
                    for (int i = 0; i < values.Length; i++)
                    {
                        returnValue += values[i] + " || ";
                    }
                    if (!String.IsNullOrEmpty(returnValue))
                    {
                        returnValue = returnValue.Substring(0, returnValue.Length - 4);
                    }
                    else
                    {
                        returnValue = " || ";
                    }
                    break;
            }
            return returnValue;
        }
        #endregion

        #region public string PlusSign() 字符串相加符号
        /// <summary>
        /// 字符串相加符号
        /// </summary>
        /// <returns>字符加</returns>
        public string PlusSign()
        {
            string returnValue = " + ";
            
            return returnValue;
        }
        #endregion
    }
}