using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiRoDetailBatchGetRequest : JdRequestBase<EdiRoDetailBatchGetResponse>
    {
                                                                                                                                              public  		string
              returnOrderCode
 {get; set;}
                                                          
                                                          public  		string
              jdSku
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.edi.ro.detail.batch.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("returnOrderCode", this.            returnOrderCode
);
                                                                                                        parameters.Add("jdSku", this.            jdSku
);
                                                                                                                            }
    }
}





        
 

