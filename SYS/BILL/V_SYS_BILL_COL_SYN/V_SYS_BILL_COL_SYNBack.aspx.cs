using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AgileFrame.Orm.PersistenceLayer.Model;
using AgileFrame.Orm.PersistenceLayer.BLL;
using AgileFrame.Orm.PersistenceLayer.BLL.Base;

public partial class V_SYS_BILL_COL_SYNBack : AgileFrame.AppInOne.Common.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //在列表里点击删除按钮，通过AJAX执行这里的后台代码，删除一条记录
        if (Request["DelCOL_SYNID"] != null)
        {
            int re = BLLTable<V_SYS_BILL_COL_SYN>.Factory(conn).Delete(V_SYS_BILL_COL_SYN.Attribute.COL_SYNID, Request["DelCOL_SYNID"]);
            if (re > 0)
            {
                Response.Write("1");//可以输出数字 大于0 表示操作成功，也可以直接输出 字符串，客户端将弹出此字符串信息作为提示
            }
            else
            {
                Response.Write("删除失败！");
            }
        }

        //在列表顶部点击删除按钮，通过AJAX执行这里的后台代码，删除多条记录
        if (Request["DelKeyIDS"] != null)
        {
            V_SYS_BILL_COL_SYN cond = new V_SYS_BILL_COL_SYN();
            cond.In(V_SYS_BILL_COL_SYN.Attribute.COL_SYNID, Request["DelKeyIDS"]);
            int re = BLLTable<V_SYS_BILL_COL_SYN>.Factory(conn).Delete(cond);
            if (re > 0)
            {
                Response.Write("1");//可以输出数字 大于0 表示操作成功，也可以直接输出 字符串，客户端将弹出此字符串信息作为提示
            }
            else
            {
                Response.Write("删除失败！");
            }
        }

        //在用户详细信息查看编辑页面，点保存时，通过AJAX执行这里的后台代码，实现部门字段的更新
        if (Request["saveInfo"] != null)
        {
            V_SYS_BILL_COL_SYN val = new V_SYS_BILL_COL_SYN();
            val.COL_SYNID = int.Parse(Request["FieldKeyID"]);
            List<AttributeItem> lstCol = val.af_AttributeItemList;
            for (int i = 0; i < lstCol.Count; i++)
            {
                if (!string.IsNullOrEmpty(Request["txt" + lstCol[i].FieldName])) {
                    val.SetValue(lstCol[i].FieldName,Request["txt" + lstCol[i].FieldName]);
                }
            }

            BLLTable<V_SYS_BILL_COL_SYN>.Factory(conn).Update(val, V_SYS_BILL_COL_SYN.Attribute.COL_SYNID);
            Response.Write("修改用户信息成功");

        }
        Response.End();
    }
}