using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiSdvStockinfoGetRequest : JdRequestBase<EdiSdvStockinfoGetResponse>
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
                get{return "jingdong.edi.sdv.stockinfo.get";}
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





        
 

