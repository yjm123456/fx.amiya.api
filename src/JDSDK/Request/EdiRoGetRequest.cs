using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiRoGetRequest : JdRequestBase<EdiRoGetResponse>
    {
                                                                                                                                              public  		Nullable<int>
              type
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
                get{return "jingdong.edi.ro.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("type", this.            type
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





        
 

