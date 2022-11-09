﻿using Fx.Amiya.Dto.HuiShouQianPay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IHuiShouQianPaymentService
    {
        /// <summary>
        /// 验证慧收钱公共请求参数
        /// </summary>
        /// <param name="errmsg"></param>
        /// <returns></returns>
        bool CheckHSQCommonParams(HuiShouQianCommonInfo huiShouQianCommonInfo,out string errmsg);
        /// <summary>
        /// 验证慧收钱业务请求参数
        /// </summary>
        /// <param name="errmsg"></param>
        /// <returns></returns>
        bool CheckHSQRequestParam(HuiShouQianPayRequestInfo huiShouQianPayRequestInfo, out string errmsg);
        /// <summary>
        /// 验证慧收钱memo参数域
        /// </summary>
        /// <param name="errmsg"></param>
        /// <returns></returns>
        bool CheckHSQMemoParam(HuiShouQianMemoInfo huiShouQianMemoInfo,out string errmsg);
    }
}