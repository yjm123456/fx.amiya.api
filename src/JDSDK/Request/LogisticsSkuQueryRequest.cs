using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LogisticsSkuQueryRequest : JdRequestBase<LogisticsSkuQueryResponse>
    {
                                                                                  public  		string
                                                                                                                      joslGoodNo
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                                                      isvGoodNo
 {get; set;}
                                                                                                                                                          
                                             public override string ApiName
            {
                get{return "jingdong.logistics.sku.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("josl_good_no", this.                                                                                                                    joslGoodNo
);
                                                                                                        parameters.Add("isv_good_no", this.                                                                                                                    isvGoodNo
);
                                                                                                    }
    }
}





        
 

