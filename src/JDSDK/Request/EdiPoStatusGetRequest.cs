using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiPoStatusGetRequest : JdRequestBase<EdiPoStatusGetResponse>
    {
                                                                                                                                              public  		Nullable<DateTime>
              createTimeStart
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              createTimeEnd
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNum
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              purchaseOrderCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              bipLogicalDel
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              bipStatus
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.edi.po.status.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("createTimeStart", this.            createTimeStart
);
                                                                                                        parameters.Add("createTimeEnd", this.            createTimeEnd
);
                                                                                                        parameters.Add("pageNum", this.            pageNum
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("purchaseOrderCode", this.            purchaseOrderCode
);
                                                                                                        parameters.Add("bipLogicalDel", this.            bipLogicalDel
);
                                                                                                        parameters.Add("bipStatus", this.            bipStatus
);
                                                                                                                            }
    }
}





        
 

