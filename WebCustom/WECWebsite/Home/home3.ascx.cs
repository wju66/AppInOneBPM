﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AgileFrame.Core.WebSystem;
using AgileFrame.AppInOne.CMS;
using AgileFrame.Orm.PersistenceLayer.Model;
using AgileFrame.Orm.PersistenceLayer.BLL.Base;

public partial class WECWebsite_Home_home3 : System.Web.UI.UserControl
{
    public string preUrl = "";
    protected string navigation = "";//导航
    protected string mainvalue = "";//主内容
    protected void Page_Load(object sender, EventArgs e)
    {
        preUrl = WebHelper.GetAppPath();
        int aid = Common.GetReqIntValue("aid") == 0 ? 1 : Common.GetReqIntValue("aid");
        //导航
        WEC_CUSTOM_CATEBANNER condner = new WEC_CUSTOM_CATEBANNER();
        condner.STATUS = 0;
        condner.AID = aid;
        condner.OrderBy(WEC_CUSTOM_CATEBANNER.Attribute.SORT_ID);
        List<WEC_CUSTOM_CATEBANNER> list = BLLTable<WEC_CUSTOM_CATEBANNER>.Select(new WEC_CUSTOM_CATEBANNER(), condner);
        if (list.Count != 0)
        {
            foreach (WEC_CUSTOM_CATEBANNER wr in list)
            {
               
                navigation = string.Format("{0} <li><a onclick=\"return false;\"><img src=\"{1}\" alt=\"{2}\" style=\"width:100%;\" /></a></li>", navigation, wr.PIC_URL, wr.NAME);
            }
        }
        //主内容
        WEC_CUSTOM_COLUMN cond = new WEC_CUSTOM_COLUMN();
        cond.STATUS = 0;
        cond.UP_FLAG = 1;
        cond.PID = "0";
        cond.AID = aid;
        cond.OrderBy(WEC_CUSTOM_COLUMN.Attribute.SORT_ID);
        List<WEC_CUSTOM_COLUMN> list1 = BLLTable<WEC_CUSTOM_COLUMN>.Select(new WEC_CUSTOM_COLUMN(), cond);
        int a=0;
        mainvalue = "<li>";
        foreach (WEC_CUSTOM_COLUMN wc in list1)
        {
            a=a+1;
            if(a==5)
            {
                a = 1;
                mainvalue = mainvalue + "</li><li>";
            }
            WEC_CUSTOM_COLUMN wn = new WEC_CUSTOM_COLUMN();
            wn.PID = wc.ID;
            string path = "";
            if (!BLLTable<WEC_CUSTOM_COLUMN>.Exists(wn))
            {
                path = "list.aspx?id=" + wc.ID + "&aid=" + aid;
            }
            else
            {
                path = "channel.aspx?id=" + wc.ID + "&aid=" + aid;
            }
            mainvalue = string.Format("{0}<a href=\"{1}\" class=\"shengyt-list-item\"> <img src=\"{2}\" alt=\"{3}\" /> <div>{3}</div> </a>", mainvalue, !string.IsNullOrEmpty(wc.OUT_URL) ? wc.OUT_URL : path, wc.PIC_URL, wc.COLUMN_NAME);
        }
            mainvalue = mainvalue + "</li>";

    }
}