using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiSdvSalesinfoGetRequest : JdRequestBase<EdiSdvSalesinfoGetResponse>
    {
                                                                                                                                              public  		string
              recordDate
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNum
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.edi.sdv.salesinfo.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("recordDate", this.            recordDate
);
                                                                                                        parameters.Add("pageNum", this.            pageNum
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                            }
    }
}





        
 

