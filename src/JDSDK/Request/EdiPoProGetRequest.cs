using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiPoProGetRequest : JdRequestBase<EdiPoProGetResponse>
    {
                                                                                                                                              public  		Nullable<int>
              orderStatus
 {get; set;}
                                                          
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
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.edi.po.pro.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderStatus", this.            orderStatus
);
                                                                                                        parameters.Add("createTimeStart", this.            createTimeStart
);
                                                                                                        parameters.Add("createTimeEnd", this.            createTimeEnd
);
                                                                                                        parameters.Add("pageNum", this.            pageNum
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                            }
    }
}





        
 

