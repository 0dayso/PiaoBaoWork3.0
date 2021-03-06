﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using PbProject.Model;
using PbProject.Logic.ControlBase;
using PbProject.Logic;

public partial class UserContrl_ImportanterGongying : System.Web.UI.UserControl
{
    BaseDataManage Manage = new BaseDataManage();
    protected override void OnInit(EventArgs e)
    {
        BindDictionary();
        base.OnInit(e);
    }
    /// <summary>
    /// BindDictionary
    /// </summary>
    protected void BindDictionary()
    {
        string currentuserid = Request["currentuserid"] ?? string.Empty;
        if (!string.IsNullOrEmpty(currentuserid))
        {
            //if (Session[currentuserid] != null)
            if (Application[currentuserid] != null)
            {

                SessionContent sessionContent = new SessionContent();
                //sessionContent = Session[currentuserid] as SessionContent;
                sessionContent = Application[currentuserid] as SessionContent;
                string cpyno = sessionContent.COMPANY.UninCode.Substring(0, 12);
                //首选查询出平台给该运营商开启了那些接口
                string sql = " 1=1 and  CpyNo='" + cpyno + "' and setName='" + PbProject.Model.definitionParam.paramsName.kongZhiXiTong + "'";
                List<Bd_Base_Parameters> objList = Manage.CallMethod("Bd_Base_Parameters", "GetList", null, new object[] { sql }) as List<Bd_Base_Parameters>;
                StringBuilder childidSt = new StringBuilder("-1");
                if (objList != null && objList.Count > 0)
                {
                    #region 确认平台已经开启那些接口
                    if (objList[0].SetValue.Contains("|84|"))//517
                    {
                        childidSt.Append(",84");
                    }
                    if (objList[0].SetValue.Contains("|89|"))//51book
                    {
                        childidSt.Append(",89");
                    }
                    if (objList[0].SetValue.Contains("|85|"))//百拓
                    {
                        childidSt.Append(",85");
                    }
                    if (objList[0].SetValue.Contains("|88|"))//票盟
                    {
                        childidSt.Append(",88");
                    }
                    if (objList[0].SetValue.Contains("|86|"))//8000Y
                    {
                        childidSt.Append(",86");
                    }
                    if (objList[0].SetValue.Contains("|87|"))//今日
                    {
                        childidSt.Append(",87");
                    }
                    if (objList[0].SetValue.Contains("|93|"))//易行
                    {
                        childidSt.Append(",93");
                    }
                    if (objList[0].SetValue.Contains("|105|"))//航空公司B2B政策实时获取
                    {
                        childidSt.Append(",105");
                    }
                    #endregion
                }
                //查询字典表对应的数据
                string sql1 = "A1=1 and ParentName='权限标识管理 (重要标识)' and ChildID in (" + childidSt + ")";
                List<Bd_Base_Dictionary> objList1 = Manage.CallMethod("Bd_Base_Dictionary", "GetList", null, new object[] { sql1 }) as List<Bd_Base_Dictionary>;


                if (objList != null)
                {
                    foreach (Bd_Base_Dictionary item in objList1)
                    {
                        ListItem LItem = new ListItem();
                        LItem.Text = item.ChildName;
                        LItem.Value = item.ChildID.ToString();
                        LItem.Attributes.Add("title", item.ChildDescription);
                        ck_ImportBox.Items.Add(LItem);
                    }
                }

            }
        }
    }

    /// <summary>
    /// 获取和设置功能参数的值格式 "|"+值+"|"
    /// </summary>
    public string ImportantMarkStr
    {
        get
        {
            return getImportValue();
        }
        set
        {
            setImportValue(value);
        }
    }

    /// <summary>
    /// 设置供应商重要标志值 (功能参数重要标志)
    /// </summary>
    /// <returns></returns>
    private bool setImportValue(string ImportValueStr)
    {
        bool flag = false;
        try
        {
            if (!string.IsNullOrEmpty(ImportValueStr) && ImportValueStr.ToUpper() != "NULL")
            {
                List<string> listNum = new List<string>();
                string[] ImportArr = ImportValueStr.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                if (ImportArr.Length > 0)
                {
                    listNum.AddRange(ImportArr);
                    ListItemCollection listColl = ck_ImportBox.Items;
                    ListItem item = null;
                    for (int i = 0; i < listColl.Count; i++)
                    {
                        item = listColl[i];
                        if (listNum.Contains(item.Value.Trim()))
                        {
                            item.Selected = true;
                        }
                    }
                    flag = true;
                }
            }
        }
        catch (Exception ep)
        {
            flag = false;
        }
        return flag;
    }

    /// <summary>
    /// 机票获取重要标志的值(功能参数重要标志)
    /// </summary>
    /// <returns></returns>
    private string getImportValue()
    {
        string ImportStr = "";
        List<string> strlist = new List<string>();
        ListItemCollection listColl = ck_ImportBox.Items;
        if (listColl.Count > 0)
        {
            for (int i = 0; i < listColl.Count; i++)
            {
                if (listColl[i].Selected)
                {
                    strlist.Add(listColl[i].Value);
                }
            }
        }
        if (strlist.Count > 0)
        {
            ImportStr = "|" + string.Join("|", strlist.ToArray()).Trim('|') + "|";
        }
        return ImportStr;
    }
}