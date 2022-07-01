using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscCollectionListRequest : JdRequestBase<AscCollectionListResponse>
    {
                                                                                                                                                                                                                                                 public  		string
              buId
 {get; set;}
                                                          
                                                          public  		string
              operatePin
 {get; set;}
                                                          
                                                          public  		string
              operateNick
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              jdInterveneFlag
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              balanceFlag
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              applyTimeBegin
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              applyTimeEnd
 {get; set;}
                                                          
                                                                                                                      public  		string
              pageNumber
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                                                           public  		string
              extJsonStr
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.collection.list";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                        parameters.Add("buId", this.            buId
);
                                                                                                        parameters.Add("operatePin", this.            operatePin
);
                                                                                                        parameters.Add("operateNick", this.            operateNick
);
                                                                                                        parameters.Add("jdInterveneFlag", this.            jdInterveneFlag
);
                                                                                                        parameters.Add("balanceFlag", this.            balanceFlag
);
                                                                                                        parameters.Add("applyTimeBegin", this.            applyTimeBegin
);
                                                                                                        parameters.Add("applyTimeEnd", this.            applyTimeEnd
);
                                                                                                                                                parameters.Add("pageNumber", this.            pageNumber
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                parameters.Add("extJsonStr", this.            extJsonStr
);
                                                                            }
    }
}





        
 

