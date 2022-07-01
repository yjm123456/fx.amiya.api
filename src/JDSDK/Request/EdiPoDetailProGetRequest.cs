using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiPoDetailProGetRequest : JdRequestBase<EdiPoDetailProGetResponse>
    {
                                                                                                                                              public  		string
              purchaseOrderCode
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.edi.po.detail.pro.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("purchaseOrderCode", this.            purchaseOrderCode
);
                                                                                                                            }
    }
}





        
 

